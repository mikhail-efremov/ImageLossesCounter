using System;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;

namespace MeshCollision
{
  public partial class Form1 : Form
  {
    public static UnsafeBitmap Bitmap;
    private readonly List<MeshCollideObject> _meshCollideObjects = new List<MeshCollideObject>();
    private readonly List<Color> _colors = new List<Color>();

    private static int _linesCount = 10;

    public Form1()
    {
      InitializeComponent();
      LoadImage();
      colorGetPictureBox.BackColor = Color.Black;

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
    
    private void pictureBox1_Paint(object sender, PaintEventArgs e)
    {
      var graphics = e.Graphics;
      DrawWithRanges(graphics);
      PaintHslCointeinerPictureBox();
      InvalidateImage();
    }
    
    private void DrawWithRanges(Graphics graphics)
    {
      if(_colors == null)
        return;

      linesCountTextBox.Text = _linesCount.ToString();
      var lines = MeshCollideObject.GetRawMesh(Bitmap, _linesCount);
      foreach (var color in _colors)
      {
        var similarLines = GetSimilarMesh(lines, Bitmap, color, 50);
        if (similarLines.Any())
        {
          /*
          var coincidence = CoincidenceAnalyth.GetCoincidence(similarLines);
          meshCollideObject.CoincidencesWithoutInterrupt = coincidence.Count;

          int average = 0;
          coincidence.ForEach(line => average = average + line.Points.Count);
          if (average != 0)
            average = average / coincidence.Count;
          meshCollideObject.AverageCoincidences = average;
          */
          int hits = 0;
          similarLines.ForEach(line => hits = hits + line.Points.Count);
          
          selectionRangeSlider1.CurrentSelectionElement.Hits = hits;
          DrawLines(similarLines, graphics, new SolidBrush(selectionRangeSlider1.CurrentSelectionElement.LinesColor));
        }
      }
      if(selectionRangeSlider1.CurrentSelectionElement != null)
        hitsTextBox.Text = selectionRangeSlider1.CurrentSelectionElement.Hits.ToString();
    }
    
    private List<Line> GetSimilarMesh(IEnumerable<Line> lines, UnsafeBitmap bitmap, Color color, byte sens)
    {
      var similarMesh = new List<Line>();
      
      Bitmap.Lock();
      foreach (var line in lines)
      {
        {
          var searchLine = new Line();
          foreach (var point in line.Points)
          {
            if (StaticMethods.ColorSimilar(color, bitmap.GetPixel(point.X, point.Y), sens))
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
    
    private void PaintHslCointeinerPictureBox() {
      if (selectionRangeSlider1.CurrentSelectionElement == null)
        return;

      var image = new Bitmap(hslCointeinerPictureBox.InitialImage, hslCointeinerPictureBox.Size);
      var width = hslCointeinerPictureBox.Size.Width;
      
      for (var i = 0; i < width; i++)
      {
        var color = Hsl.ColorFromHsl((double)i / width,
          selectionRangeSlider1.CurrentSelectionElement.SValue1,
          selectionRangeSlider1.CurrentSelectionElement.LValue1);

        for (var j = 0; j < image.Size.Height; j++)
        {
          image.SetPixel(i, j, color);
        }
      }

      hslCointeinerPictureBox.Image = image;
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

    private void buttonLoadImage_Click(object sender, EventArgs e)
    {
      LoadImage();
      InvalidateImage();
    }

    private void SuperSliderAddeder(SelectionRangeSlider slider) {
      var mMin = 0;
      var mMax = 360;

      foreach (var sli in slider.Sliders) {
        if (sli.SelectedMin == 0 && sli.SelectedMax == mMax) {
          return;
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
      var slide = new SelectionElement(slider.Width, slider.Height, mMax, mMin, colorGetPictureBox.BackColor);
      slider.AddSelectionElement(slide);

      slide.SelectionChanged += OnSlideSelectionChanged;
      slide.ElementSelected += OnSliderElementSelected;
      OnSlideSelectionChanged(slide, null);
    }

    private void OnSlideSelectionChanged(object sender, EventArgs eventArgs) {
      selectionRangeSlider1.Invalidate();
      
      var element = (SelectionElement) sender;
      SetColors(element, element.SelectedMin, element.SelectedMax);
      SetMinMaxColorBoxes(element);
    }

    private void OnSliderElementSelected(object sender, EventArgs eventArgs) {
      var element = (SelectionElement)sender;
      linesCountTextBox.Text = element.LinesCount.ToString();
      colorGetPictureBox.BackColor = element.LinesColor;
      sValueTrackBar.Value = element.SValue1000;
      lValueTrackBar.Value = element.LValue1000;
      OnSlideSelectionChanged(sender, eventArgs);
      hitsTextBox.Text = element.Hits.ToString();
    }

    private void SetMinMaxColorBoxes(SelectionElement element)
    {
      var min = element.SelectedMin;
      var max = element.SelectedMax;

      var minColor = Hsl.ColorFromHsl((double)min / element.Max, element.SValue1, element.LValue1);
      var maxColor = Hsl.ColorFromHsl((double)max / element.Max, element.SValue1, element.LValue1);

      SetColorPictureBox(maxPictureBox, maxColor);
      SetColorPictureBox(minPictureBox, minColor);
    }

    private void SetColorPictureBox(PictureBox pictureBox, Color color)
    {
      var newPic = new Bitmap(pictureBox.InitialImage);

      for (var i = 0; i < newPic.Width; i++) {
        for (var j = 0; j < newPic.Height; j++) {
          newPic.SetPixel(i, j, color);
        }
      }
      pictureBox.Image = newPic;
    }

    private void button1_Click_1(object sender, EventArgs e)
    {
      SuperSliderAddeder(selectionRangeSlider1);
    }

    private void sValueTrackBar_ValueChanged(object sender, EventArgs e)
    {
      if (selectionRangeSlider1.CurrentSelectionElement == null) return;
      selectionRangeSlider1.CurrentSelectionElement.SValue1000 = sValueTrackBar.Value;
      OnSlideSelectionChanged(selectionRangeSlider1.CurrentSelectionElement, null);
    }

    private void lValueTrackBar_ValueChanged(object sender, EventArgs e) 
    {
      if (selectionRangeSlider1.CurrentSelectionElement == null) return;
      selectionRangeSlider1.CurrentSelectionElement.LValue1000 = lValueTrackBar.Value;
      OnSlideSelectionChanged(selectionRangeSlider1.CurrentSelectionElement, null);
    }

    private static bool _firstClick = true;
    private static MouseEventArgs _firstClickData = null;
    private void pictureBox1_Click(object sender, EventArgs e)
    {
      if (_firstClick)
      {
        _firstClickData = (MouseEventArgs) e;
        _firstClick = false;
        return;
      }
      if (_firstClickData == null)
        return;
      var secondClickData = (MouseEventArgs) e;

      Bitmap.Lock();
      var firstPixel = Bitmap.GetPixel(_firstClickData.X, _firstClickData.Y);
      var secondPixel = Bitmap.GetPixel(secondClickData.X, secondClickData.Y);
      Bitmap.Unlock();

      var firstHsl = Hsl.FromRGB(firstPixel.R, firstPixel.G, firstPixel.B);
      var secondHsl = Hsl.FromRGB(secondPixel.R, secondPixel.G, secondPixel.B);
      
      var maxH = firstHsl.H > secondHsl.H ? firstHsl.H : secondHsl.H;
      var minH = firstHsl.H < secondHsl.H ? firstHsl.H : secondHsl.H;

      if (selectionRangeSlider1.CurrentSelectionElement == null)
        return;
      SetColors(selectionRangeSlider1.CurrentSelectionElement, (int)minH, (int)maxH);

      selectionRangeSlider1.CurrentSelectionElement.SelectedMin = (int)minH;
      selectionRangeSlider1.CurrentSelectionElement.SelectedMax = (int)maxH;

      selectionRangeSlider1.Invalidate();
    }

    private void SetColors(SelectionElement element, int min, int max)
    {
      _colors.Clear();

      if (selectionRangeSlider1.Sliders.Count < 1)
        return;

      _firstClick = true;

      for (; min < max; min++) {
        _colors.Add(Hsl.ColorFromHsl((double)min / element.Max, element.SValue1, element.LValue1));
      }
    }

    private void buttonGetLinesCount_Click(object sender, EventArgs e)
    {
      var count = 0;
      if (int.TryParse(linesCountTextBox.Text, out count))
      {
        _linesCount = count;
        selectionRangeSlider1.CurrentSelectionElement.LinesCount = count;
      }
    }

    private void colorGetPictureBox_Click(object sender, EventArgs e) {
      var form = ActiveForm;
      if (form == null) return;
      form.Hide();
      var cd = new ColorDialog();
      cd.ShowDialog();
      colorGetPictureBox.BackColor = cd.Color;
      form.Show();
      if(selectionRangeSlider1.CurrentSelectionElement == null)
        return;
      selectionRangeSlider1.CurrentSelectionElement.LinesColor = cd.Color;
    }
  }
}