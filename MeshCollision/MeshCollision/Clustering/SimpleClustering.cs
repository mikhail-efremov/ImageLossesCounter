using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;

namespace MeshCollision.Clustering
{
  public class SimpleClustering
  {
    public static Task<HashSet<HashSet<Point>>> GetCluesters(HashSet<Point> basePoints, double distance)
    {
      return Task.Factory.StartNew(() =>
      {
        if (basePoints.Count < 1)
          return new HashSet<HashSet<Point>>();

        var powDistance = distance * distance;

        var clusters = new HashSet<HashSet<Point>>(GetCluster(basePoints, powDistance));
        return clusters;
      });
    }

    private static IEnumerable<HashSet<Point>> GetCluster(IEnumerable<Point> basePoints, double powDistance)
    {
      var points = new List<Point>(basePoints);

      while (points.Count > 0)
      {
        var cluser = GetPoints(points[0], points, powDistance);
        points.RemoveAll(p => cluser.Contains(p));
        yield return cluser;
      }
    }

    public static HashSet<Point> GetPoints(Point origin, List<Point> points, double powDistance)
    {
      var result = new HashSet<Point>
      {
        origin
      };
      var found = new Queue<Point>();
      found.Enqueue(origin);

      while (found.Count > 0)
      {
        var current = found.Dequeue();
        var candidates = points
          .Where(p => !result.Contains(p) &&
                      p.DistanceSquared(current) <= powDistance);

        foreach (var p in candidates)
        {
          result.Add(p);
          found.Enqueue(p);
        }
      }

      return result;
    }
  }
}