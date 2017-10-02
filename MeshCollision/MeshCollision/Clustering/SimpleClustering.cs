﻿using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace MeshCollision.Clustering
{
  public class SimpleClustering
  {
    public static List<HashSet<Point>> GetCluesters(List<Point> basePoints, double distance)
    {
      if (basePoints.Count < 1)
        return new List<HashSet<Point>>();

      var powDistance = distance * distance;

      var clusters = GetCluster(basePoints, powDistance);
      return clusters.ToList();
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
      var result = new HashSet<Point> {origin}; //wath out
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




    private List<Point> GetCluster(List<Point> basePoints, Point startPoint, double powDistance)
    {
      var cluster = new List<Point>();

      var findedPoints = basePoints
        .Where(p => p.DistanceSquared(startPoint) < powDistance)
        .ToList();

      basePoints.RemoveAll(p => cluster.Contains(p));

      if (findedPoints.Count < 1)
        return cluster;
      
      var b = findedPoints[0];
      findedPoints.Remove(b);
      cluster.Add(b);

      cluster.AddRange(GetCluster(basePoints, b, powDistance));

      return cluster;
    }
  }
}