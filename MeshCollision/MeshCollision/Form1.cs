using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace MeshCollision
{
  public partial class Form1 : Form
  {
    public static UnsafeBitmap Bitmap;
    private readonly List<MeshCollideObject> _meshCollideObjects = new List<MeshCollideObject>();
    private readonly List<Color> _colors = new List<Color>();

    private static int linesCount = 10;

    public Form1()
    {
      InitializeComponent();
      LoadImage();

      panel1.AutoScroll = false;
      panel1.HorizontalScroll.Enabled = false;
      panel1.HorizontalScroll.Visible = false;
      panel1.HorizontalScroll.Maximum = 0;
      panel1.AutoScroll = true;

      sValueTrackBar.Value = 1000;
      lValueTrackBar.Value = 500;
    }

    private void LoadImage()
    {
      Image image = UploadImage();
			
			if (image == null)
        return;

      Bitmap = new UnsafeBitmap(new Bitmap(image));

      Bitmap.Unlock();
      pictureBox1.Image = Bitmap.Bitmap;
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

    Stopwatch sw = Stopwatch.StartNew();
    private void pictureBox1_Paint(object sender, PaintEventArgs e)
    {
      var graphics = e.Graphics;
      DrawWithRanges(graphics);
      PaintHslCointeinerPictureBox();
      InvalidateImage();
    }
    
    private double lastUsage = 0f;
    private void DrawWithRanges(Graphics graphics)
    {
      //if (sw.ElapsedMilliseconds > lastUsage + 3000)
      //  lastUsage = sw.ElapsedMilliseconds;
      //else
      //{
      //  return;
      //} 

      if(_colors == null)
        return;

      var lines = MeshCollideObject.GetRawMesh(Bitmap, linesCount);
      foreach (var color in _colors)
      {
        var similarLines = GetSimilarMesh(lines, Bitmap, color);
        if(similarLines.Count() > 0)
          DrawLines(similarLines, graphics, Brushes.Red);
      }
    }
    
    private IEnumerable<Line> GetSimilarMesh(IEnumerable<Line> lines, UnsafeBitmap bitmap, Color color)
    {
      var similarMesh = new List<Line>();
      
      Bitmap.Lock();
   //   Parallel.ForEach(lines, line =>
             foreach (var line in lines)
      {
        {
          var searchLine = new Line();
          foreach (Point point in line.Points)
          {
            //          if (StaticMethods.ColorEqual(color, bitmap.GetPixel(point.X, point.Y))) {
            if (StaticMethods.ColorSimilar(color, bitmap.GetPixel(point.X, point.Y), 50))
            {
              if (!similarMesh.Contains(searchLine))
              {
                similarMesh.Add(searchLine);
              }
              if (similarMesh.Contains(searchLine))
                similarMesh[similarMesh.IndexOf(searchLine)].Points.Add(point);
            }
          }
        }
      }
      Bitmap.Unlock();
      return similarMesh;
    }

    private static double SValue = 1d;
    private static double LValue = .5d;

    private bool hslPainted = false;
    private void PaintHslCointeinerPictureBox() {
      if(hslPainted)
        return;
      hslPainted = true;
      var image = new Bitmap(hslCointeinerPictureBox.InitialImage, hslCointeinerPictureBox.Size);
      var width = hslCointeinerPictureBox.Size.Width;
      
      for (var i = 0; i < width; i++)
      {
        var color = Hsl.ColorFromHsl((double)i / width, SValue, LValue);

        for (int j = 0; j < image.Size.Height; j++)
        {
          image.SetPixel(i, j, color);
        }
      }

      hslCointeinerPictureBox.Image = image;
    }

    private void DrawWithSingleColor(Graphics graphics)
    {
      foreach (var meshCollideObject in _meshCollideObjects) {
        var brush = new SolidBrush(meshCollideObject.MeshColor);

        var lines = MeshCollideObject.GetRawMesh(Bitmap, 1);
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
      int count = 0;
      if(Int32.TryParse(linesCountTextBox.Text, out count))
        linesCount = count;
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

      var color = Hsl.ColorFromHsl(inta / 360d, SValue, LValue);
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
      OnSlideSelectionChanged(slide, null);
    }
    
    private void OnSlideSelectionChanged(object sender, EventArgs eventArgs)
    {
      var slider = (Slider) sender;
      
      var min = slider.SelectedMin;
      var max = slider.SelectedMax;

      SetColors(min, max);
      
      var minColor = Hsl.ColorFromHsl((double) min / slider.Max, SValue, LValue);
      var maxColor = Hsl.ColorFromHsl((double) max / slider.Max, SValue, LValue);

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

    private void sValueTrackBar_ValueChanged(object sender, EventArgs e)
    {
      SValue = sValueTrackBar.Value / 1000d;
      if(selectionRangeSlider1.Sliders.Count > 0)
        OnSlideSelectionChanged(selectionRangeSlider1.Sliders[0], null);
    }

    private void lValueTrackBar_ValueChanged(object sender, EventArgs e)
    {
      LValue = lValueTrackBar.Value / 1000d;
      if (selectionRangeSlider1.Sliders.Count > 0)
        OnSlideSelectionChanged(selectionRangeSlider1.Sliders[0], null);
    }

    private static bool firstClick = true;
    private static MouseEventArgs firstClickData = null;
    private void pictureBox1_Click(object sender, EventArgs e)
    {
      if (firstClick)
      {
        firstClickData = (MouseEventArgs) e;
        firstClick = false;
        return;
      }
      if (firstClickData == null)
        return;
      var secondClickData = (MouseEventArgs) e;

      Bitmap.Lock();
      var firstPixel = Bitmap.GetPixel(firstClickData.X, firstClickData.Y);
      var secondPixel = Bitmap.GetPixel(secondClickData.X, secondClickData.Y);
      Bitmap.Unlock();

      var firstHsl = Hsl.FromRGB(firstPixel.R, firstPixel.G, firstPixel.B);
      var secondHsl = Hsl.FromRGB(secondPixel.R, secondPixel.G, secondPixel.B);
      
      var maxH = firstHsl.H > secondHsl.H ? firstHsl.H : secondHsl.H;
      var minH = firstHsl.H < secondHsl.H ? firstHsl.H : secondHsl.H;

      SetColors((int)minH, (int)maxH);
    }

    private void SetColors(int min, int max)
    {
      _colors.Clear();

      if (selectionRangeSlider1.Sliders.Count < 1)
        return;

      if(selectionRangeSlider1.Sliders[0].SelectedMin != min)
        selectionRangeSlider1.Sliders[0].SelectedMin = min;
      if (selectionRangeSlider1.Sliders[0].SelectedMax != max)
        selectionRangeSlider1.Sliders[0].SelectedMax = max;

      selectionRangeSlider1.Invalidate();
      firstClick = true;

      for (; min < max; min++) {
        _colors.Add(Hsl.ColorFromHsl(min / 360d, SValue, LValue));
      }
    }
  }
}