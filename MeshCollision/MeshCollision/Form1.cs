using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;
using MeshCollision.Calculations;
using MeshCollision.Clustering;
using MeshCollision.ColorSpaces;
using MeshCollision.Controlls;

namespace MeshCollision
{
  public partial class Form1 : Form
  {
    private const int IMAGES_OFFSET = 15;
    private const int SIZE_OF_PAINT = 5;

    private Bitmap _clearImage;
    private Bitmap _clearExample;
    
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
      _clearExample = image.Clone(cloneRect, format);
        
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
          if (sli.SelectedMax > mMin)
          {
            mMin = sli.SelectedMax + 1;
            continue;
          }
        if (sli.SelectedMin != 0)
          if (sli.SelectedMin < mMax)
          {
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

    private void buttonVisualDraw_Click(object sender, EventArgs e)
    {
      analythPictureBox.Image = new Bitmap(_clearImage);
      var imageAnalyzer = new ImageAnalyzer(_clearImage);

      var sens = byte.Parse(textBoxColorSens.Text);

      executionInformation.Text = @"Points analize in progress 10%";
      var analizedResult = imageAnalyzer.Analize(selectionRangeSlider1.CurrentSelectionElement, sens).Result;

      executionInformation.Text = @"Claster analyth in progress 30%";
      var clusters = SimpleClustering.GetCluesters(analizedResult, double.Parse(clusterDistanceTextBox.Text));

      DrawVisualImage(clusters.Result, 15);
    }

    private async void AnalizeImageAsync()
    {
      analythPictureBox.Image = new Bitmap(_clearImage);
      var imageAnalyzer = new ImageAnalyzer(_clearImage);

      var sens = byte.Parse(textBoxColorSens.Text);

      executionInformation.Text = @"Points analize in progress 10%";
      var analizedResult = await imageAnalyzer.Analize(selectionRangeSlider1.CurrentSelectionElement, sens);

      executionInformation.Text = @"Claster analyth in progress 30%";
      var clusters = await SimpleClustering.GetCluesters(analizedResult, double.Parse(clusterDistanceTextBox.Text));
      
      executionInformation.Text = @"Find hulls orientation and draw 60%";
      DrawHallAndCalculateOrientation(clusters, 15, Pens.DarkRed, true);
      executionInformation.Text = @"Done 100%";

      analythPictureBox.Invalidate();
      examplePictureBox.Invalidate();
    }

    private void DrawHallAndCalculateOrientation(HashSet<HashSet<Point>> clasters, int pointsInClasterThreshold,
      Pen linesPen, bool showAngles)
    {
      examplePictureBox.Image = _clearExample;

      if (pointsInClasterThreshold < 2)
        pointsInClasterThreshold = 2;

      var g = Graphics.FromImage(analythPictureBox.Image);
      var c = Graphics.FromImage(examplePictureBox.Image);

      var examplesPoints = new List<Point>(_exampleImagePoints);
      var hitPoints = new List<Point>();

      foreach (var points in clasters)
      {
        if (points.Count < pointsInClasterThreshold)
          continue;

        var hull = ConcaveHull.Hull.Generate(points.ToList(), double.Parse(concaveTextBox.Text), 1, true);

        foreach (var line in hull)
        {
          g.DrawLine(linesPen, (float) line.nodes[0].x, (float) line.nodes[0].y,
            (float) line.nodes[1].x, (float) line.nodes[1].y);
        }

        var maxDistance = GetMaxLine(points, out var maxFirstPoint, out var maxLastPoint);
        var midDistance = GetMiddleLine(points);
        var orientation =
          AngleCalculations.CalculatePointsOrientation(points.ToList(), maxFirstPoint, maxLastPoint, maxDistance);

        if (showAngles)
        {
          g.DrawLine(Pens.Black, orientation.FirstPoint, orientation.SecondPoint);
          g.DrawString(orientation.Angles, DefaultFont, Brushes.Black, orientation.AnglesPosition);
        }

        var extremum = PointsCalculations.GetExtemumPoints(points);
        var extremumHull = ConcaveHull.Hull.Generate(extremum.ToList(), double.Parse(concaveTextBox.Text), 1, true);
        foreach (var ex in examplesPoints)
        {
          var res = PointInRegion(ex, extremumHull);

          if (res)
          {
            hitPoints.Add(ex);
          }
          else
          {
            if (!paintModeCheckBox.Checked)
              c.FillRectangle(Brushes.Black, ex.X, ex.Y, 1, 1);
          }
        }

        continue;
        StatsWriter.Write(new StatsWriter.Stat
          {
            Angle = orientation.Angles,
            Max = Math.Round(maxDistance, 2).ToString(CultureInfo.InvariantCulture),
            Mid = Math.Round(midDistance, 2).ToString(CultureInfo.InvariantCulture),
            S = points.Count.ToString()
          }
        );
      }

      foreach (var h in hitPoints)
      {
        examplesPoints.Remove(h);
        if (!paintModeCheckBox.Checked)
          c.FillRectangle(Brushes.White, h.X, h.Y, 1, 1);
      }

      var sum = hitPoints.Count + examplesPoints.Count;
      var persent = (float)hitPoints.Count / sum * 100;
      exampleToAnalythLabel.Text = hitPoints.Count + " из " + sum +". " + persent + "%";
    }

    private void DrawVisualImage(HashSet<HashSet<Point>> clasters, int pointsInClasterThreshold)
    {
      cuttingPictureBox.Image =
        new Bitmap(analythPictureBox.Width, analythPictureBox.Height, PixelFormat.Format24bppRgb);
      var analBitmap = new Bitmap(analythPictureBox.Image);
      using (var grp = Graphics.FromImage(cuttingPictureBox.Image))
      {
        grp.FillRectangle(
          Brushes.White, 0, 0, analythPictureBox.Width, analythPictureBox.Height);
      }

      cuttingPictureBox.Location = new Point(cuttingPictureBox.Size.Width + 380, analythPictureBox.Location.Y);

      var allPoints = MeshCollideObject.GetPoints(new Bitmap(analythPictureBox.Image), 1);
      var hits = new HashSet<Point>();

      foreach (var points in clasters)
      {
        if (points.Count < pointsInClasterThreshold)
          continue;

        var hulls = ConcaveHull.Hull.Generate(points.ToList(), double.Parse(concaveTextBox.Text), 1, true);

        foreach (var ex in allPoints)
        {
          var res = PointInRegion(ex, hulls);

          if (res)
          {
            hits.Add(ex);
          }
        }
      }
      using (var grp = Graphics.FromImage(cuttingPictureBox.Image))
      {
        foreach (var pt in hits)
        {
          grp.FillRectangle(new SolidBrush(analBitmap.GetPixel(pt.X, pt.Y)), pt.X, pt.Y, 1, 1);
        }
      }

      cuttingPictureBox.Invalidate();
    }

    private bool PointInRegion(Point point, IEnumerable<ConcaveHull.Line> hull)
    {
      var res = false;
      var hitidLines = new List<ConcaveHull.Line>();

      foreach (var line in hull)
      {
        var p0X = Convert.ToInt32(line.nodes[0].x);
        var p0Y = Convert.ToInt32(line.nodes[0].y);
        var p1X = Convert.ToInt32(line.nodes[1].x);
        var p1Y = Convert.ToInt32(line.nodes[1].y);

        var p2X = 0;
        var p2Y = 0;
        var p3X = point.X;
        var p3Y = point.Y;

        if (Intersects(p0X, p0Y, p1X, p1Y, p2X, p2Y, p3X, p3Y))
        {
          hitidLines.Add(line);
          res = !res;
        }
      }

      foreach (var line in hull)
      {
        var p0X = Convert.ToInt32(line.nodes[0].x);
        var p0Y = Convert.ToInt32(line.nodes[0].y);
        var p1X = Convert.ToInt32(line.nodes[1].x);
        var p1Y = Convert.ToInt32(line.nodes[1].y);

        var p2X = 1;
        var p2Y = 1;
        var p3X = point.X;
        var p3Y = point.Y;

        if (Intersects(p0X, p0Y, p1X, p1Y, p2X, p2Y, p3X, p3Y))
        {
          res = !res;
        }
      }
      if (res) return false;

      var ulRes = false;
      foreach (var line in hull)
      {
        var p0X = Convert.ToInt32(line.nodes[0].x);
        var p0Y = Convert.ToInt32(line.nodes[0].y);
        var p1X = Convert.ToInt32(line.nodes[1].x);
        var p1Y = Convert.ToInt32(line.nodes[1].y);

        var p2X = 0;
        var p2Y = 0;
        var p3X = point.X;
        var p3Y = point.Y;

        if (Intersects(p0X, p0Y, p1X, p1Y, p2X, p2Y, p3X, p3Y))
        {
          ulRes = !ulRes;
        }
      }

      return ulRes;
    }

    private double GetMaxLine(IReadOnlyCollection<Point> points, out Point firstPoint, out Point lastPoint)
    {
      firstPoint = new Point();
      lastPoint = new Point();
      var distance = 0;

      foreach (var firstP in points)
      {
        foreach (var secondP in points)
        {
          var distBetweetPoints = firstP.DistanceSquared(secondP);

          if (distBetweetPoints > distance)
          {
            distance = distBetweetPoints;
            firstPoint = firstP;
            lastPoint = secondP;
          }
        }
      }
      return Math.Sqrt(distance);
    }

    private double GetMiddleLine(IReadOnlyCollection<Point> points)
    {
      var distance = 0d;
      var count = 0;

      foreach (var firstP in points)
      {
        foreach (var secondP in points)
        {
          distance += firstP.DistanceSquared(secondP);
          count++;
        }
      }
      return Math.Sqrt(distance/count);
    }

    //https://stackoverflow.com/questions/9043805/test-if-two-lines-intersect-javascript-function
    private static bool Intersects(int p01x, int p01y, int p02x, int p02y, int p03x, int p03y, int p04x, int p04y)
    {
      var det = (p02x - p01x) * (p04y - p03y) - (p04x - p03x) * (p02y - p01y);
      if (det == 0)//parallel or equal
      {
        return false;
      }

      var lambda = (float)((p04y - p03y) * (p04x - p01x) + (p03x - p04x) * (p04y - p01y)) / det;
      var gamma = (float)((p01y - p02y) * (p04x - p01x) + (p02x - p01x) * (p04y - p01y)) / det;
      return (0 <= lambda && lambda <= 1) && (0 <= gamma && gamma <= 1);
    }

    private void DrawPoints(Brush brush, IEnumerable<Point> points, int size, Graphics g)
    {
      foreach (var pt in points)
      {
        g.FillRectangle(brush, pt.X, pt.Y, size, size);
      }
    }

    private void examplePictureBox_Paint(object sender, PaintEventArgs e)
    {
      if(!paintModeCheckBox.Checked)
        return;

      var g = e?.Graphics ?? examplePictureBox.CreateGraphics();
      
      DrawPoints(new SolidBrush(Color.Red), _exampleImagePoints, 1, g);
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

    private void paintModeCheckBox_CheckedChanged(object sender, EventArgs e)
    {
      examplePictureBox_Paint(sender, null);
    }
  }
}