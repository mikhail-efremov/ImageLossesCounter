using System;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using System.Linq;
using System.Resources;
using System.Threading;
using System.Threading.Tasks;
using MeshCollision.ColorSpaces;

namespace MeshCollision
{
  public partial class Form1 : Form
  {
    public static UnsafeBitmap Bitmap;
    private static int _linesCount = 15;

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
      PaintHslCointeinerPictureBox();
      InvalidateImage();
    }

    private List<Line> GetHitLines(List<IColorSpace> colors)
    {
      if (colors == null || colors.Count == 0) {
        selectionRangeSlider1.CurrentSelectionElement.Hits = 0;

        return new List<Line>();
      }

      var lines = MeshCollideObject.GetRawMesh(Bitmap.Bitmap, _linesCount);
      if (selectionRangeSlider1.CurrentSelectionElement != null)
        selectionRangeSlider1.CurrentSelectionElement.Hits = 0;


      var similarMesh = new List<Line>();
      var clonedBuffer = new UnsafeBitmap((Bitmap)Bitmap.Bitmap.Clone());

      foreach (var color in colors)
      {
        var searchLine = new Line();

        clonedBuffer.Lock();

        foreach (var line in lines) {
          foreach (var point in line.Points)
          {
             if (color.ColorSimilar(point, clonedBuffer, 100)) {
                 if (!similarMesh.Contains(searchLine)) {
                 similarMesh.Add(searchLine);
             }
             if (similarMesh.Contains(searchLine))
                          similarMesh[similarMesh.IndexOf(searchLine)].Points.Add(point);
            }
          }
        }

        clonedBuffer.Unlock();
      }

      return similarMesh;
    }

    private void PaintHslCointeinerPictureBox() 
    {
      if (selectionRangeSlider1.CurrentSelectionElement == null)
        return;

      var image = new Bitmap(hslCointeinerPictureBox.InitialImage, hslCointeinerPictureBox.Size);
      var width = hslCointeinerPictureBox.Size.Width;
      
      for (var i = 0; i < width; i++)
      {
        var color = HslColorSpace.ColorFromHsl((double)i / width,
          selectionRangeSlider1.CurrentSelectionElement.SValue1,
          selectionRangeSlider1.CurrentSelectionElement.LValue1);

        for (var j = 0; j < image.Size.Height; j++)
        {
          image.SetPixel(i, j, color);
        }
      }

      hslCointeinerPictureBox.Image = image;
    }

    private  void DrawLines(IEnumerable<Line> lines, Graphics graphics, Brush brush)
    {
      foreach (var line in lines)
      {
        DrawLines(line.Points, graphics, brush);
      }
    }

    private  void DrawLines(IEnumerable<Point> points, Graphics graphics, Brush brush)
    {
      foreach (var point in points) {
        graphics.FillRectangle(brush, point.X, point.Y, 1, 1);
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
      SetMinMaxColorBoxes(element);
    }

    private void DrawMesh(SelectionRangeSlider selectionRangeSlider, int minH, int maxH)
    {
      var element = selectionRangeSlider.CurrentSelectionElement;

      element.SelectedMin = minH;
      element.SelectedMax = maxH;

      selectionRangeSlider.Invalidate();
    }

    private void OnSliderElementSelected(object sender, EventArgs eventArgs) {
      var element = (SelectionElement)sender;
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

      var minColor = HslColorSpace.ColorFromHsl((double)min / element.Max, element.SValue1, element.LValue1);
      var maxColor = HslColorSpace.ColorFromHsl((double)max / element.Max, element.SValue1, element.LValue1);

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

      var firstHsl = HslColorSpace.FromRGB(firstPixel.R, firstPixel.G, firstPixel.B);
      var secondHsl = HslColorSpace.FromRGB(secondPixel.R, secondPixel.G, secondPixel.B);
      
      var maxH = firstHsl.H > secondHsl.H ? firstHsl.H : secondHsl.H;
      var minH = firstHsl.H < secondHsl.H ? firstHsl.H : secondHsl.H;

      DrawMesh(selectionRangeSlider1, (int)minH, (int)maxH);
    }

    private List<IColorSpace> SetColors(SelectionElement element, int min, int max)
    {
      var colors = new List<IColorSpace>();

      if (selectionRangeSlider1.Sliders.Count < 1)
        return null;

      _firstClick = true;

      for (; min < max; min++) {
        colors.Add(new RgbColorSpace(
          HslColorSpace.ColorFromHsl((double)min / element.Max, element.SValue1, element.LValue1)));
      }

      return colors;
    }

    private List<IColorSpace> SetHslColor(SelectionElement element, int min, int max)
    {
      var colors = new List<IColorSpace>();

      if (selectionRangeSlider1.Sliders.Count < 1)
        return null;

      _firstClick = true;

      for (; min < max; min++) {
        colors.Add(new HslColorSpace((float)min / element.Max, (float)element.SValue1, (float)element.LValue1));
      }

      return colors;
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

    private void buttonDraw_Click(object sender, EventArgs e)
    {
      Draw();
    }
    
    public void Draw() {
      var buffer = Bitmap.Bitmap;

      Task.Factory.StartNew(() =>
      {
        var element = selectionRangeSlider1.CurrentSelectionElement;
        var colors = SetColors(element, element.SelectedMin, element.SelectedMax);

        var hitLines = GetHitLines(colors);
        var brush = new SolidBrush(selectionRangeSlider1.CurrentSelectionElement.LinesColor);

        using (var g = Graphics.FromImage(buffer)) {
            foreach (var line in hitLines) 
          {
            foreach (var point in line.Points)
            {
              g.FillRectangle(brush, point.X, point.Y, 1, 1);
            }
          }
        }
        pictureBox1.Invoke(new Action(() =>
        {
          pictureBox1.Image = buffer;
        }));
      });
    }
  }
}