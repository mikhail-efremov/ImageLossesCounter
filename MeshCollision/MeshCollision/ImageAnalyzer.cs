using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using MeshCollision.ColorSpaces;

namespace MeshCollision
{
  public struct AnalyzeResult
  {
    public Bitmap Bitmap;
    public List<Point> Points;
  }

  public class ImageAnalyzer
  {
    public UnsafeBitmap Bitmap;
    
    private static readonly int _linesCount = 70;

    public ImageAnalyzer(Image image)
    {
      Bitmap = new UnsafeBitmap(new Bitmap(image));

      Bitmap.Unlock();
    }

    private List<Line> GetHitLines(List<IColorSpace> colors) {
      if (colors == null || colors.Count == 0) {
        return new List<Line>();
      }

      var rawMesh = MeshCollideObject.GetRawMesh(Bitmap.Bitmap, _linesCount);
      
      var similarMesh = new List<Line>();
      var clonedBuffer = new UnsafeBitmap((Bitmap)Bitmap.Bitmap.Clone());

      clonedBuffer.Lock();

      Parallel.ForEach(colors, color =>
      {
        var searchLine = new Line();

        foreach (var line in rawMesh) {
          foreach (var point in line.Points) {
            if (color.ColorSimilar(point, clonedBuffer, 100)) {
              if (similarMesh.Contains(searchLine))
              {
                similarMesh[similarMesh.IndexOf(searchLine)].Points.Add(point);
              }
              else
              {
                similarMesh.Add(searchLine);
              }
            }
          }
        }
      });
      return similarMesh;
    }

    public Task<AnalyzeResult> Analize(SelectionElement element, Label inProgressLabel)
    {
      var buffer = Bitmap.Bitmap;
      inProgressLabel.Text = "in progress";
      
      return Task.Factory.StartNew(() =>
      {
        var result = new AnalyzeResult { Bitmap = buffer};
        
        var points = new List<Point>();

        var colors = SetColors(element, element.SelectedMin, element.SelectedMax);

        var hitLines = GetHitLines(colors);
        foreach (var line in hitLines)
        {
          foreach (var point in line.Points)
          {
            if (!points.Contains(point))
            {
              points.Add(point);
            }
          }
        }

        result.Points = points;
        inProgressLabel.Invoke((MethodInvoker)(() => inProgressLabel.Text = "no progress"));
        return result;
      });
    }
    
    private List<IColorSpace> SetColors(SelectionElement element, int min, int max) {
      var colors = new List<IColorSpace>();
      
      for (; min < max; min++) {
        colors.Add(new RgbColorSpace(
          HslColorSpace.ColorFromHsl((double)min / element.Max, element.SValue1, element.LValue1)));
      }

      return colors;
    }

    private List<IColorSpace> SetHslColor(SelectionElement element, int min, int max) {
      var colors = new List<IColorSpace>();
      
      for (; min < max; min++) {
        colors.Add(new HslColorSpace((float)min / element.Max, (float)element.SValue1, (float)element.LValue1));
      }

      return colors;
    }
  }


  public static class PointExt
  {
    public static Decimal GetDistance(this Point p1, Point p2)
    {
      return Convert.ToDecimal(Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2)));
    }
  }
}
