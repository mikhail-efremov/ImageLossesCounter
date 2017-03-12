using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace MeshCollision
{
  public partial class Form1 : Form
  {
    public static Bitmap Bitmap;
    private readonly List<MeshCollideObject> _meshCollideObjects = new List<MeshCollideObject>();
    private readonly List<Color> _colors = new List<Color>();

    public Form1()
    {
      InitializeComponent();
      LoadImage();

      panel1.AutoScroll = false;
      panel1.HorizontalScroll.Enabled = false;
      panel1.HorizontalScroll.Visible = false;
      panel1.HorizontalScroll.Maximum = 0;
      panel1.AutoScroll = true;
    }

    private void LoadImage()
    {
      Image image = UploadImage();
			
			if (image == null)
        return;

      pictureBox1.Image = image;
      Bitmap = new Bitmap(image);
    }

    private void InvalidateImage()
    {
      if (Bitmap == null)
        return;
      pictureBox1.Invalidate();
    }

    public Bitmap UploadImage()
    {
      var open = new OpenFileDialog
      {
        Filter = @"Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp"
      };

      return open.ShowDialog() == DialogResult.OK ? new Bitmap(open.FileName) : null;
    }

    private void pictureBox1_Paint(object sender, PaintEventArgs e)
    {
      var graphics = e.Graphics;
//      DrawWithRanges(graphics);
      PaintColorCointeinerPictureBox();
      InvalidateImage();
    }

    private void DrawWithRanges(Graphics graphics)
    {
      if(_colors == null)
        return;

      var lines = MeshCollideObject.GetRawMesh(Bitmap);
      foreach (var color in _colors)
      {
        var similarLines = GetSimilarMesh(lines, Bitmap, color);
        DrawLines(similarLines, graphics, Brushes.Red);
      }
    }
    
    private IEnumerable<Line> GetSimilarMesh(IEnumerable<Line> lines, Bitmap bitmap, Color color)
    {
      var similarMesh = new List<Line>();

      foreach (var line in lines) {
        var searchLine = new Line();
        foreach (Point point in line.Points) {
          if (StaticMethods.ColorEqual(color, bitmap.GetPixel(point.X, point.Y))) {
            if (!similarMesh.Contains(searchLine)) {
              similarMesh.Add(searchLine);
            }
            similarMesh[similarMesh.IndexOf(searchLine)].Points.Add(point);
          }
        }
      }
      return similarMesh;
    }

    private void PaintColorCointeinerPictureBox() {
      var image = new Bitmap(colorCointeinerPictureBox.InitialImage, colorCointeinerPictureBox.Size);
      var width = colorCointeinerPictureBox.Size.Width;
      
      for (var i = 0; i < width; i++)
      {
        var color = Hsl.ColorFromHsl((double)i / width, 1d, .5d);

        for (int j = 0; j < image.Size.Height; j++)
        {
          image.SetPixel(i, j, color);
        }
      }

      colorCointeinerPictureBox.Image = image;
    }

    private void DrawWithSingleColor(Graphics graphics)
    {
      foreach (var meshCollideObject in _meshCollideObjects) {
        var brush = new SolidBrush(meshCollideObject.MeshColor);

        var lines = MeshCollideObject.GetRawMesh(Bitmap);
        var similarLines = meshCollideObject.GetSimilarMesh(lines, Bitmap, _meshCollideObjects);

        var coincidence = CoincidenceAnalyth.GetCoincidence(similarLines);

        meshCollideObject.CoincidencesWithoutInterrupt = coincidence.Count;

        int average = 0;
        coincidence.ForEach(line => average = average + line.Points.Count);
        if (average != 0)
          average = average / coincidence.Count;
        meshCollideObject.AverageCoincidences = average;

        DrawLines(similarLines, graphics, brush);

        int hits = 0;
        similarLines.ForEach(line => hits = hits + line.Points.Count);

        meshCollideObject.Hits = hits;
      }
    }

    private static void DrawLines(IEnumerable<Line> lines, Graphics graphics, Brush brush)
    {
      foreach (var line in lines)
      {
        foreach (var point in line.Points)
        {
          graphics.FillRectangle(brush, point.X, point.Y, 1, 1);
        }
      }
    }

    private void buttonDraw_Click(object sender, EventArgs e)
    {
      InvalidateImage();
    }

    private void buttonLoadImage_Click(object sender, EventArgs e)
    {
      LoadImage();
      InvalidateImage();
    }
		
		private static int _nextLocation = 0;
		private void button1_Click(object sender, EventArgs e) {
			var meshObj = new MeshCollideObject();
			_meshCollideObjects.Add(meshObj);

			var controlls = meshObj.GetControlls();
			foreach (var control in controlls)
			{
			  if (!string.IsNullOrEmpty(control.Description))
			  {
			    var label = new Label
			    {
			      Text = control.Description,
			      Location = new Point(12, _nextLocation)
			    };
			    control.Control.Location = new Point(label.Size.Width + 10, _nextLocation);

			    panel1.Controls.Add(label);
			    panel1.Controls.Add(control.Control);
			  }
			  else
			  {
          control.Control.Location = new Point(10, _nextLocation);
          panel1.Controls.Add(control.Control);
        }

			  _nextLocation += 24;
			}
      
      _nextLocation += 24;
		}

    private void trackBar1_Scroll(object sender, EventArgs e)
    {
      var strin = trackBar1.Value.ToString();
      if (strin.Length < 2)
        strin += "0";

      string normal = new string(strin.ToCharArray(), 0, strin.Length - 1);
      var inta = 0;
      if (strin == "-1")
        inta = -1;
      else
        inta = Convert.ToInt32(normal);

      var color = Hsl.ColorFromHsl(inta / 360d, 1d, 0.5d);
      pictureBox2.BackColor = color;
    }

    private void SuperSliderAddeder(SelectionRangeSlider Slider) {
      Brush b = new SolidBrush(Color.Black);

      var mMin = 0;
      var mMax = 360;

      foreach (var sli in Slider.Sliders) {
        if (sli.SelectedMin == 0 && sli.SelectedMax == mMax) {
          MessageBox.Show(@"You wonna add slider to full slider's range, realy?", @"Error");
        }
        if (sli.SelectedMax != mMax)
          if (sli.SelectedMax > mMin) {
            mMin = sli.SelectedMax + 1;
            continue;
          }
        if (sli.SelectedMin != 0)
          if (sli.SelectedMin < mMax) {
            mMax = sli.SelectedMin - 1;
          }
      }
      var slide = new Slider(Slider.Width, Slider.Height, b, mMax, mMin);
      Slider.Sliders.Add(slide);

      slide.SelectionChanged += OnSlideSelectionChanged;
    }
    
    private void OnSlideSelectionChanged(object sender, EventArgs eventArgs)
    {
      var slider = (Slider) sender;
      
      var min = slider.SelectedMin;
      var max = slider.SelectedMax;
      
      var minColor = Hsl.ColorFromHsl((double) min / slider.Max, 1d, .5d);
      var maxColor = Hsl.ColorFromHsl((double) max / slider.Max, 1d, .5d);

      var maxPic = new Bitmap(maxPictureBox.InitialImage);

      for (var i = 0; i < maxPic.Width; i++)
      {
        for (var j = 0; j < maxPic.Height; j++)
        {
          maxPic.SetPixel(i, j, maxColor);
        }
      }
      maxPictureBox.Image = maxPic;

      var minPic = new Bitmap(minPictureBox.InitialImage);

      for (var i = 0; i < minPic.Width; i++) {
        for (var j = 0; j < minPic.Height; j++) {
          minPic.SetPixel(i, j, minColor);
        }
      }
      minPictureBox.Image = minPic;
    }

    private void button1_Click_1(object sender, EventArgs e)
    {
      SuperSliderAddeder(selectionRangeSlider1);
    }
  }
}