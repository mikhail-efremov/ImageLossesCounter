using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using MeshCollision.ColorSpaces;

namespace MeshCollision
{
  public partial class Form1 : Form
  {
    private ImageAnalyzer _imageAnalyzer;

    private Bitmap _initialBitmap;


    private readonly List<Point> _exampleImagePoints = new List<Point>();
    private List<Point> _analyzedPoints = new List<Point>();

    private bool _inDrawProcess;

    public Form1()
    {
      InitializeComponent();
      
      colorGetPictureBox.BackColor = Color.Black;
      
      sValueTrackBar.Value = 1000;
      lValueTrackBar.Value = 500;

      UploadImage();
    }
    
    private bool UploadImage() {
      var open = new OpenFileDialog
      {
        Filter = @"Image Files(*.jpg; *.jpeg; *.gif; *.bmp)|*.jpg; *.jpeg; *.gif; *.bmp"
      };
      
      var image = open.ShowDialog() == DialogResult.OK ? new Bitmap(open.FileName) : null;

      if (image == null)
        return false;

      var fileName = open.FileName;

      var cloneRect = new Rectangle(0, 0, image.Width, image.Height);
      var format = image.PixelFormat;
      _initialBitmap = image.Clone(cloneRect, format);

      _imageAnalyzer = new ImageAnalyzer(image);

      analythPictureBox.Size = image.Size;
      analythPictureBox.Image = image;
      
      var exampleImage = new Bitmap(fileName);
      examplePictureBox.Size = exampleImage.Size;
      examplePictureBox.Image = exampleImage;
      return true;
    }

    private void InvalidateImage()
    {
      if (analythPictureBox.Image == null)
        return;
      analythPictureBox.Invalidate();
    }
    
    private void pictureBox1_Paint(object sender, PaintEventArgs e)
    {
      PaintHslCointeinerPictureBox();
      InvalidateImage();
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

    private void buttonLoadImage_Click(object sender, EventArgs e)
    {
      UploadImage();
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
      var slide = new SelectionElement(mMax, mMin, colorGetPictureBox.BackColor);
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

    private void OnSliderElementSelected(object sender, EventArgs eventArgs) 
    {
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
      AnalizeImageAsync();
    }

    private async void AnalizeImageAsync()
    {
      analythPictureBox.Image = _initialBitmap;
      _imageAnalyzer = new ImageAnalyzer(_initialBitmap);

      var analizedResult = await _imageAnalyzer.Analize(selectionRangeSlider1.CurrentSelectionElement, inProgressLabel);
      if (analizedResult.Bitmap != null)
      {
        var hitPoints = new List<Point>();

        foreach (var point in analizedResult.Points)
        {
          var rectangle = new Rectangle
          {
            Location = point,
            Size = new Size(5, 5)
          };

          for (var x = 0; x < examplePictureBox.Size.Width; x++)
            for (var y = 0; y < examplePictureBox.Size.Height; y++)
            {
            var p = new Point(x, y);

            if (rectangle.Contains(p) && !hitPoints.Contains(p))
            {
              hitPoints.Add(p);
            }
          }
        }
        
        using (var g = Graphics.FromImage(analythPictureBox.Image))
        {
          foreach (var p in hitPoints)
          {
            g.FillRectangle(Brushes.Black, p.X, p.Y,
              1, 1);
          }
        }

        analizedResult.Points = hitPoints;
        _analyzedPoints = hitPoints;
      }
    }

    private void examplePictureBox_Paint(object sender, PaintEventArgs e)
    {
      for (var i = 0; i < _exampleImagePoints.Count; i++)
      {
        e.Graphics.FillRectangle(Brushes.Black,
          _exampleImagePoints[i].X, _exampleImagePoints[i].Y, 1, 1);
      }
    }

    private void examplePictureBox_MouseDown(object sender, MouseEventArgs e)
    {
      _inDrawProcess = true;

      var point = new Point(e.X, e.Y);

      if (e.Button == MouseButtons.Right)
      {
        RemovePointAndInvalidate(point, examplePictureBox);
        return;
      }
      
      AddPointAndInvalidate(point, examplePictureBox);
    }

    private void examplePictureBox_MouseMove(object sender, MouseEventArgs e)
    {
      if (!_inDrawProcess)
        return;

      var point = new Point(e.X, e.Y);

      if (e.Button == MouseButtons.Right) {
        RemovePointAndInvalidate(point, examplePictureBox);
      }
      else if(e.Button == MouseButtons.Left)
      {
        AddPointAndInvalidate(point, examplePictureBox);
      }
    }

    private void examplePictureBox_MouseUp(object sender, MouseEventArgs e) {
      if (!_inDrawProcess)
        return;

      var point = new Point(e.X, e.Y);

      if (e.Button == MouseButtons.Right) {
        RemovePointAndInvalidate(point, examplePictureBox);
        return;
      }

      AddPointAndInvalidate(point, examplePictureBox);
      _inDrawProcess = false;
    }

    private void examplePictureBox_MouseLeave(object sender, EventArgs e) {
      _inDrawProcess = false;
    }

    private void AddPointAndInvalidate(Point point, PictureBox picture)
    {
      var rectangle = new Rectangle
      {
        Location = point,
        Size = new Size(5, 5)
      };
      
      for (var i = 0; i < examplePictureBox.Size.Height; i++)
        for (var j = 0; j < examplePictureBox.Size.Width; j++)
        {
          var p = new Point(j, i);
          if (rectangle.Contains(p) && !_exampleImagePoints.Contains(p))
          {
            _exampleImagePoints.Add(p);
          }
        }
      
      picture.Invalidate();
    }

    private void RemovePointAndInvalidate(Point point, PictureBox picture)
    {
      var rectangle = new Rectangle
      {
        Location = point,
        Size = new Size(5, 5)
      };

      for (var i = 0; i < examplePictureBox.Size.Height; i++)
        for (var j = 0; j < examplePictureBox.Size.Width; j++) {
          if (rectangle.Contains(new Point(j, i))) {
          _exampleImagePoints.Remove(new Point(j, i));
          }
        }

      picture.Invalidate();
    }

    private void compareImagesButton_Click(object sender, EventArgs e)
    {
      var examples = new List<Point>(_exampleImagePoints);
      var analyzed = new List<Point>(_analyzedPoints);

      analyzed.RemoveAll(x => examples.Contains(x));
      var percent = analyzed.Count / ((float)_analyzedPoints.Count / 100);

      var examples1 = new List<Point>(_exampleImagePoints);
      var analyzed1 = new List<Point>(_analyzedPoints);

      examples1.RemoveAll(x => analyzed1.Contains(x));
      var percent1 = examples1.Count / ((float)_exampleImagePoints.Count / 100);

      var ne = (percent + percent1) / 2;

      exampleToAnalythLabel.Text = Math.Round(ne, 2) + "%";
    }
  }
}