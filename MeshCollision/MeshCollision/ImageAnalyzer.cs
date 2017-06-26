using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using MeshCollision.ColorSpaces;

namespace MeshCollision
{
  public class ImageAnalyzer
  {
    public UnsafeBitmap Bitmap;
    private List<Line> _chasherRawMesh = new List<Line>(); 

    private static readonly int _linesCount = 15;

    public ImageAnalyzer(Image image)
    {
      Bitmap = new UnsafeBitmap(new Bitmap(image));

      Bitmap.Unlock();//??
    }

    private List<Line> GetHitLines(List<IColorSpace> colors) {
      if (colors == null || colors.Count == 0) {
        return new List<Line>();
      }

      var rawMesh = MeshCollideObject.GetRawMesh(Bitmap.Bitmap, _linesCount);
      
      var similarMesh = new List<Line>();
      var clonedBuffer = new UnsafeBitmap((Bitmap)Bitmap.Bitmap.Clone());

      foreach (var color in colors) {
        var searchLine = new Line();

        clonedBuffer.Lock();

        foreach (var line in rawMesh) {
          foreach (var point in line.Points) {
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

      _chasherRawMesh = rawMesh;
      return similarMesh;
    }

    public Task<Bitmap> Analize(SelectionElement element)
    {
      var buffer = Bitmap.Bitmap;

      return Task.Factory.StartNew(() =>
      {
        var points = new List<Point>();

        var colors = SetColors(element, element.SelectedMin, element.SelectedMax);

        var hitLines = GetHitLines(colors);
        var brush = new SolidBrush(element.LinesColor);

        using (var g = Graphics.FromImage(buffer))
        {
          foreach (var line in hitLines)
          {
            foreach (var point in line.Points)
            {
              if (!points.Contains(point))
              {
                points.Add(point);
                g.FillRectangle(brush, point.X, point.Y, 1, 1);
              }
            }
          }
        }

        var emptyList = new List<Point>();

        foreach (var line in _chasherRawMesh)
        {
          foreach (var p in line.Points)
          {
            if (!points.Contains(p))
            {
              emptyList.Add(p);
            }
          }
        }

        using (var g = Graphics.FromImage(buffer))
        {
          foreach (var point in emptyList)
          {
            g.FillRectangle(Brushes.Red, point.X, point.Y, 1, 1);
          }
        }
        return buffer;
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
}
