using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using MeshCollision.ColorSpaces;
using MeshCollision.Controlls;

namespace MeshCollision.Calculations
{
  public class ImageAnalyzer
  {
    public UnsafeBitmap Bitmap;

    public readonly int LineWeight = 6;
    public readonly int LineHeight = 6;

    private const float INDENT = 10;

    public ImageAnalyzer(Image image)
    {
      Bitmap = new UnsafeBitmap(new Bitmap(image));

      Bitmap.Unlock();
    }

    public Task<HashSet<Point>> Analize(SelectionElement element, byte sens)
    {
      return Task.Factory.StartNew(() =>
      {
        var points = new HashSet<Point>();

        var colors = SetColors(element);

        var hitLines = GetHitLines(colors, sens);
        foreach (var line in hitLines)
        {
          if (line == null) continue;
          foreach (var point in line.Points)
          {
            if (!points.Contains(point))
            {
              points.Add(point);
            }
          }
        }

        return points;
      });
    }

    private List<Line> GetHitLines(List<IColorSpace> colors, byte sens)
    {
      if (colors == null || colors.Count == 0)
      {
        return new List<Line>();
      }

      var rawMesh = MeshCollideObject.GetRawMesh(Bitmap.Bitmap, INDENT);
      
      var similarMesh = new List<Line>();
      var clonedBuffer = new UnsafeBitmap((Bitmap)Bitmap.Bitmap.Clone());

      clonedBuffer.Lock();

      Parallel.ForEach(colors, color =>
      {
        var searchLine = new Line();

        foreach (var line in rawMesh) {
          foreach (var point in line.Points) {
            if (color.ColorSimilar(point, clonedBuffer, sens)) {
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
    
    private List<IColorSpace> SetColors(SelectionElement element)
    {
      var colors = new List<IColorSpace>();

      var curMax = element.SelectedMax;
      var curMin = element.SelectedMin;

      var max = element.Max;

      var sValue = element.SValue1;
      var lValue = element.LValue1;
      
      for (; curMin < curMax; curMin++) {
        colors.Add(new RgbColorSpace(
          HslColorSpace.ColorFromHsl((double)curMin / max, sValue, lValue)));
      }

      return colors;
    }
  }

  public static class PointExt
  {
    public static decimal GetDistance(this Point p1, Point p2)
    {
      return Convert.ToDecimal(Math.Sqrt(Math.Pow(p1.X - p2.X, 2) + Math.Pow(p1.Y - p2.Y, 2)));
    }
  }
}
