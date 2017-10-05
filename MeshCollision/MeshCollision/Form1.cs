using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using howto_convex_hull;
using MeshCollision.Clustering;
using MeshCollision.ColorSpaces;
using Newtonsoft.Json;
using utorials.Clustering.Hard;
using nAlpha;

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

      PaintExampleImage(sender, e);
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
      using (var g = Graphics.FromImage(analythPictureBox.Image))
      {
        g.DrawImage(_initialBitmap, 0, 0);
      }

      AnalizeImageAsync();
    }

    private async void AnalizeImageAsync()
    {
      analythPictureBox.Image = new Bitmap(_initialBitmap);
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
            Size = new Size(sizeOfPaint, sizeOfPaint)
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
#warning DRAW POINT IN THS POSITION
        /*
        var brush = new SolidBrush(colorGetPictureBox.BackColor);

        using (var g = Graphics.FromImage(analythPictureBox.Image))
        {
          foreach (var p in hitPoints)
          {
            g.FillRectangle(brush, p.X, p.Y,
              1, 1);
          }
        }
        */
        analizedResult.Points = hitPoints;
        _analyzedPoints = hitPoints;

        array_Points = SimpleClustering.GetCluesters(_analyzedPoints, 3);//7

        analythPictureBox.Invalidate();
      }
    }

    private List<HashSet<Point>> array_Points = new List<HashSet<Point>>();

    //минимальные выпуклые оболочки
    private void PaintExampleImage(object sender, PaintEventArgs e)
    {
      var angles = new List<string>();

      foreach (var m_Points in array_Points)
      {
        if (m_Points.Count < 25)
          continue;

        foreach (var pt in m_Points)
        {
          //  e.Graphics.FillEllipse(Brushes.Cyan, pt.X - 3, pt.Y - 3, 7, 7);
        }

        List<Point> hull = null;
        if (m_Points.Count >= 3)
        {
          // Get the convex hull.
          hull = Geometry.MakeConvexHull(m_Points.ToList());

          // Draw.
          // Fill the non-culled points.
          foreach (Point pt in Geometry.g_NonCulledPoints)
          {
            //   e.Graphics.FillEllipse(Brushes.White, pt.X - 3, pt.Y - 3, 7, 7);
          }
        }

        // Draw all of the points.
        foreach (var pt in m_Points)
        {
 //           e.Graphics.DrawEllipse(Pens.Red, pt.X, pt.Y, 1, 1);
        }

        var xes = m_Points.GroupBy(val => val.X).ToList();
        var yes = m_Points.GroupBy(val => val.Y).ToList();

        var points = new HashSet<Point>();

        foreach (var x in xes)
        {
          var max = x.Max(val => val.Y);
          var min = x.Min(val => val.Y);

          if(max == min)
            continue;
          
          var mozhno = true;
          foreach (var p in points)
          {
            if (p.Y == min || p.Y == max)
            {
              mozhno = false;
              break;
            }
          }
          if (!mozhno)
            continue;

          points.Add(new Point(x.Key, min));
          points.Add(new Point(x.Key, max));
        }
        foreach (var y in yes)
        {
          var min = y.Min(val => val.X);
          var max = y.Max(val => val.X);

          if(min == max)
            continue;

          var mozhno = true;
          foreach (var p in points)
          {
            if (p.X == min || p.X == max)
            {
              mozhno = false;
              break;
            }
          }
          if(!mozhno)
            continue;

          points.Add(new Point(min, y.Key));
          points.Add(new Point(max, y.Key));
        }
        
        foreach (var pt in points)
        {

            e.Graphics.DrawEllipse(Pens.Black, pt.X, pt.Y, 1, 1);
        }

        GetAlphaShapeCalculator(points.ToList(), e.Graphics);

 //       var s = ConcaveHull.Calc(points.ToList(), 3).ToArray();

        //     e.Graphics.DrawPolygon(Pens.Red, s); //Pens.Blue, hull_points);

        //     e.Graphics.DrawPolygon(Pens.Red, points.ToArray());
        
        if (m_Points.Count >= 3)
        {
          // Draw the MinMax quadrilateral.
          //   e.Graphics.DrawPolygon(Pens.Red, Geometry.g_MinMaxCorners);

          // Draw the culling box.
          //    e.Graphics.DrawRectangle(Pens.Orange, Geometry.g_MinMaxBox);

          // Draw the convex hull.
          if (hull == null)
            continue;

          var hullPoints = new Point[hull.Count];
          hull.CopyTo(hullPoints);
#warning e.Graphics.DrawPolygon(Pens.Red, hullPoints); //Pens.Blue, hull_points);


          //find remoted points in figure
          var firstPoint = new Point();
          var secondPoint = new Point();
          var distance = 0;

          foreach (var targetP in hullPoints)
          {
            for (var hullIndex = 0; hullIndex < hullPoints.Length; hullIndex++)
            {
              var distBetweetPoints = targetP.DistanceSquared(hullPoints[hullIndex]);

              if (distBetweetPoints > distance)
              {
                distance = distBetweetPoints;
                firstPoint = targetP;
                secondPoint = hullPoints[hullIndex];
              }
            }
          }

          var angle = AngleBetweenLineAndHorisontalAxis(firstPoint, secondPoint);
          angles.Add(angle.ToString(CultureInfo.InvariantCulture));
         

          var stringPoint = new Point((firstPoint.X + secondPoint.X) / 2,
            (firstPoint.Y + secondPoint.Y) / 2);
          e.Graphics.DrawString(Math.Round(angle).ToString(CultureInfo.InvariantCulture) + "°", 
            DefaultFont, Brushes.Black, stringPoint);

          e.Graphics.DrawLine(Pens.Black, firstPoint, secondPoint);
        }
      }
      if (angles.Count > 0 && !writed)
      {
        writed = true;        
        DrawToFIle(angles);
      }
    }

    private void GetAlphaShapeCalculator(List<Point> points, Graphics g)
    {
      AlphaShapeCalculator shapeCalculator = new AlphaShapeCalculator();
      shapeCalculator.Alpha = (double)55 / Width;
      shapeCalculator.CloseShape = true;

      var shape = shapeCalculator.CalculateShape(points.ToArray());

      var vertices1 = shape.Vertices;
      foreach (var edge in shape.Edges)
      {
        g.DrawLine(Pens.Red, (float)vertices1[edge.Item1].X, (float)vertices1[edge.Item1].Y,
          (float)vertices1[edge.Item2].X, (float)vertices1[edge.Item2].Y);
      }
    }

    private void Hull(HashSet<Point> points, Graphics g)
    {
  //    ConcaveHull.Init.GenerateHull(points);

 //     foreach (var line in ConcaveHull.Hull.hull_concave_edges)
   //   {
     //   g.DrawLine(Pens.Red, (float)line.nodes[0].x, (float)line.nodes[0].y,
       //   (float)line.nodes[1].x, (float)line.nodes[1].y);
      //}
    }

    private bool writed = false;
    private void DrawToFIle(List<string> values)
    {
      var path = "angles.txt";

      using (var w = File.AppendText(path))
      {
        for (var index = 0; index < values.Count; index++)
        {
          var s = values[index];
          w.WriteLine($"{index}: {s}");
        }
      }
    }

    private double AngleBetweenLineAndHorisontalAxis(Point p1, Point p2)
    {
      var p3 = new Point(0, 0);
      var p4 = new Point(100, 0);

      var angle1 = (float)Math.Atan2(p2.Y - p1.Y, p1.X - p2.X);
      var angle2 = (float)Math.Atan2(p4.Y - p3.Y, p3.X - p4.X);
      var calculatedAngle = (angle1 - angle2) * (float)(180.0 / Math.PI);
      if (calculatedAngle < 0)
        calculatedAngle += 360;

      return calculatedAngle - 180;//
    }

    private void examplePictureBox_Paint(object sender, PaintEventArgs e)
    {
      var brush = new SolidBrush(colorGetPictureBox.BackColor);

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
        Size = new Size(sizeOfPaint, sizeOfPaint)
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
        Size = new Size(sizeOfPaint, sizeOfPaint)
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

    private const int sizeOfPaint = 1;
  }
}