using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace MeshCollision.Calculations
{
  public class PointsCalculations
  {
    public static HashSet<Point> GetExtemumPoints(List<Point> inputPoints)
    {
        var xes = inputPoints.GroupBy(val => val.X).ToList();
        var yes = inputPoints.GroupBy(val => val.Y).ToList();

        var points = new HashSet<Point>();

        foreach (var x in xes)
        {
          var max = x.Max(val => val.Y);
          var min = x.Min(val => val.Y);

          if (max == min)
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

          if (min == max)
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
          if (!mozhno)
            continue;

          points.Add(new Point(min, y.Key));
          points.Add(new Point(max, y.Key));
        }

      return points;
    }
  }
}
