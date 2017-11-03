using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using MeshCollision.Calculations;
using MeshCollision.Calculations.Hull;
using MeshCollision.Clustering;
using MeshCollision.ColorSpaces;
using MeshCollision.Controlls;
using nAlpha;

namespace MeshCollision
{
  public partial class Form1 : Form
  {
    private const int IMAGES_OFFSET = 15;

    private Bitmap _clearImage;
    
    private readonly List<Point> _exampleImagePoints = new List<Point>();

    private bool _inDrawProcess;

    public Form1()
    {
      InitializeComponent();

      sValueTrackBar.Value = 1000;
      lValueTrackBar.Value = 500;

      if (!UploadImage())
        Environment.Exit(0);
    }
    
    private bool UploadImage()
    {
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
      _clearImage = image.Clone(cloneRect, format);

      analythPictureBox.Size = image.Size;
      analythPictureBox.Image = image;
      
      var exampleImage = new Bitmap(fileName);
      examplePictureBox.Size = exampleImage.Size;
      examplePictureBox.Image = exampleImage;
      
      analythPictureBox.Location = new Point(analythPictureBox.Size.Width + IMAGES_OFFSET, examplePictureBox.Location.Y);

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
      InvalidateImage();
    }

    private void PaintHslCointeinerPictureBox()
    {
      var element = selectionRangeSlider1.CurrentSelectionElement;
      if (element == null)
        return;

      var image = new Bitmap(hslCointeinerPictureBox.InitialImage, hslCointeinerPictureBox.Size);
      var width = hslCointeinerPictureBox.Size.Width;
      
      for (var i = 0; i < width; i++)
      {
        var color = HslColorSpace.ColorFromHsl((double)i / width,
          element.SValue1,
          element.LValue1);

        for (var j = 0; j < image.Size.Height; j++)
        {
          image.SetPixel(i, j, color);
        }
      }

      labelTestValues.Text = $@"H:[{element.SelectedMin}:{element.SelectedMax}] S:{element.SValue1} L{element.LValue1}";

      hslCointeinerPictureBox.Image = image;
    }

    private void buttonLoadImage_Click(object sender, EventArgs e)
    {
      UploadImage();
      InvalidateImage();
    }

    private void SuperSliderAddeder(SelectionRangeSlider slider)
    {
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
      var slide = new SelectionElement(mMax, mMin, Color.Black);
      slider.AddSelectionElement(slide);

      slide.SelectionChanged += OnSlideSelectionChanged;
      slide.ElementSelected += OnSliderElementSelected;
      OnSlideSelectionChanged(slide, null);

      PaintHslCointeinerPictureBox();
    }

    private void OnSlideSelectionChanged(object sender, EventArgs eventArgs)
    {
      selectionRangeSlider1.Invalidate();
      
      var element = (SelectionElement) sender;
      SetMinMaxColorBoxes(element);

      labelTestValues.Text = $@"H:[{element.SelectedMin}:{element.SelectedMax}] S:{element.SValue1} L{element.LValue1}";
    }

    private void sValueTrackBar_ValueChanged(object sender, EventArgs e)
    {
      if (selectionRangeSlider1.CurrentSelectionElement == null) return;
      selectionRangeSlider1.CurrentSelectionElement.SValue1000 = sValueTrackBar.Value;
      OnSlideSelectionChanged(selectionRangeSlider1.CurrentSelectionElement, null);
      PaintHslCointeinerPictureBox();
    }

    private void lValueTrackBar_ValueChanged(object sender, EventArgs e)
    {
      if (selectionRangeSlider1.CurrentSelectionElement == null) return;
      selectionRangeSlider1.CurrentSelectionElement.LValue1000 = lValueTrackBar.Value;
      OnSlideSelectionChanged(selectionRangeSlider1.CurrentSelectionElement, null);
      PaintHslCointeinerPictureBox();
    }

    private void OnSliderElementSelected(object sender, EventArgs eventArgs) 
    {
      var element = (SelectionElement)sender;
      sValueTrackBar.Value = element.SValue1000;
      lValueTrackBar.Value = element.LValue1000;
      OnSlideSelectionChanged(sender, eventArgs);
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

    private void buttonDraw_Click(object sender, EventArgs e)
    {
      using (var g = Graphics.FromImage(analythPictureBox.Image))
      {
        g.DrawImage(_clearImage, 0, 0);
      }

      AnalizeImageAsync();
    }

    private async void AnalizeImageAsync()
    {
      analythPictureBox.Image = new Bitmap(_clearImage);
      var imageAnalyzer = new ImageAnalyzer(_clearImage);

      var sens = byte.Parse(textBoxColorSens.Text);

      var analizedResult = await imageAnalyzer.Analize(selectionRangeSlider1.CurrentSelectionElement, inProgressLabel, sens);
      
      //need to correct error calculation
      var hitPoints = new List<Point>();
        
      foreach (var point in analizedResult.Points)
      {
        var rectangle = new Rectangle
        {
          Location = point,
          Size = new Size(SIZE_OF_PAINT, SIZE_OF_PAINT)
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

      analizedResult.Points = hitPoints;
      var arrayPoints = SimpleClustering.GetCluesters(hitPoints, 3);//7
      
      DrawHallAndCalculateError(arrayPoints);

      analythPictureBox.Invalidate();
    }

    private void DrawHallAndCalculateError(HashSet<HashSet<Point>> points)
    {
      var g = Graphics.FromImage(analythPictureBox.Image);

      var examplesPoints = new List<Point>(_exampleImagePoints);
      var hitPoints = new List<Point>();

      foreach (var mPoints in points)
      {
        if (mPoints.Count < 50)
          continue;

        var extremum = PointsCalculations.GetExtemumPoints(mPoints.ToList());
        DrawPoints(Pens.Blue, extremum, 1, g);

        // CustConcaveHull(extremum, g);
          UnityConcaveHull(extremum, g);
        //AlphaFilterConcaveHull(extremum, g, Int32.Parse(textBoxRadius.Text));

        var orientation = AngleCalculations.CalculatePointsOrientation(extremum.ToList());

        g.DrawLine(Pens.Black, orientation.FirstPoint, orientation.SecondPoint);
        g.DrawString(orientation.Angles, DefaultFont, Brushes.Black, orientation.AnglesPosition);
        
        var analizator = new PointInPolygonChecker(mPoints.ToList());
        
        foreach (var p in examplesPoints)
        {
          if (analizator.PointInPolygon(p.X, p.Y))
          {
            hitPoints.Add(p);
          }
        }
        foreach (var h in hitPoints)
        {
          examplesPoints.Remove(h);
        }
      }

      var sum = hitPoints.Count + examplesPoints.Count;
      var persent = (float)hitPoints.Count / sum * 100;
      exampleToAnalythLabel.Text = hitPoints.Count + " из " + sum +". " + persent + "%";
    }

    private void AlphaFilterConcaveHull(HashSet<Point> points, Graphics g, double radius)
    {
      var shapeCalculator = new AlphaShapeCalculator
      {
        Radius = radius,
        CloseShape = true
      };

      var shape = shapeCalculator.CalculateShape(points.ToArray());

      var vertices1 = shape.Vertices;
      foreach (var edge in shape.Edges)
      {
        g.DrawLine(Pens.Red, (float)vertices1[edge.Item1].X, (float)vertices1[edge.Item1].Y,
          (float)vertices1[edge.Item2].X, (float)vertices1[edge.Item2].Y);
      }
    }

    private void UnityConcaveHull(HashSet<Point> points, Graphics g)
    {
      ConcaveHull.Init.generateHull(points.ToList());
      
      foreach (var line in ConcaveHull.Hull.hull_concave_edges)
      {
        g.DrawLine(Pens.Red, (float)line.nodes[0].x, (float)line.nodes[0].y,
          (float)line.nodes[1].x, (float)line.nodes[1].y);
      }
    }

    private void CustConcaveHull(HashSet<Point> points, Graphics g)
    {
      var custom = CustomConcaveHull.Calc(points.ToList(), 3);

      if(custom != null)
        g.DrawPolygon(Pens.Red, custom.ToArray());
    }

    private void DrawPoints(Pen pen, IEnumerable<Point> points, int size, Graphics g)
    {
      foreach (var pt in points)
      {
        g.DrawEllipse(pen, pt.X, pt.Y, size, size);
      }
    }

    private void examplePictureBox_Paint(object sender, PaintEventArgs e)
    {
      var brush = new SolidBrush(Color.Red);

      for (var i = 0; i < _exampleImagePoints.Count; i++)
      {
        e.Graphics.FillRectangle(brush,
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

    private void examplePictureBox_MouseUp(object sender, MouseEventArgs e)
    {
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

    private void examplePictureBox_MouseLeave(object sender, EventArgs e)
    {
      _inDrawProcess = false;
    }

    private void AddPointAndInvalidate(Point point, PictureBox picture)
    {
      var rectangle = new Rectangle
      {
        Location = point,
        Size = new Size(SIZE_OF_PAINT, SIZE_OF_PAINT)
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
        Size = new Size(SIZE_OF_PAINT, SIZE_OF_PAINT)
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

      var analizator = new Calculations.PointInPolygonChecker(examples);

      var inHere = 0;
      var outHere = 0;

      foreach (var p in examples)
      {
        if (analizator.PointInPolygon(p.X, p.Y))
          inHere++;
        else
        {
          outHere++;
        }
      }
    }

    private const int SIZE_OF_PAINT = 5;
  }
}