using System;
using System.Collections.Generic;
using System.Linq;

namespace ConcaveHull
{
  public static class GrahamScan
  {
    private const int TURN_LEFT = 1;

    public static int Turn(Node p, Node q, Node r)
    {
      return ((q.x - p.x) * (r.y - p.y) - (r.x - p.x) * (q.y - p.y)).CompareTo(0);
    }

    public static void KeepLeft(List<Node> hull, Node r)
    {
      while (hull.Count > 1 && Turn(hull[hull.Count - 2], hull[hull.Count - 1], r) != TURN_LEFT)
      {
        hull.RemoveAt(hull.Count - 1);
      }
      if (hull.Count == 0 || hull[hull.Count - 1] != r)
      {
        hull.Add(r);
      }
    }

    public static double GetAngle(Node p1, Node p2)
    {
      var xDiff = p2.x - p1.x;
      var yDiff = p2.y - p1.y;
      return Math.Atan2(yDiff, xDiff) * 180.0 / Math.PI;
    }

    public static List<Node> MergeSort(Node p0, List<Node> arrPoint)
    {
      if (arrPoint.Count == 1)
      {
        return arrPoint;
      }
      var arrSortedInt = new List<Node>();
      var middle = arrPoint.Count / 2;
      var leftArray = arrPoint.GetRange(0, middle);
      var rightArray = arrPoint.GetRange(middle, arrPoint.Count - middle);
      leftArray = MergeSort(p0, leftArray);
      rightArray = MergeSort(p0, rightArray);
      var leftptr = 0;
      var rightptr = 0;
      for (var i = 0; i < leftArray.Count + rightArray.Count; i++)
      {
        if (leftptr == leftArray.Count)
        {
          arrSortedInt.Add(rightArray[rightptr]);
          rightptr++;
        }
        else if (rightptr == rightArray.Count)
        {
          arrSortedInt.Add(leftArray[leftptr]);
          leftptr++;
        }
        else if (GetAngle(p0, leftArray[leftptr]) < GetAngle(p0, rightArray[rightptr]))
        {
          arrSortedInt.Add(leftArray[leftptr]);
          leftptr++;
        }
        else
        {
          arrSortedInt.Add(rightArray[rightptr]);
          rightptr++;
        }
      }
      return arrSortedInt;
    }

    public static List<Node> ConvexHull(List<Node> points)
    {
      Node p0 = null;
      foreach (var value in points)
      {
        if (p0 == null)
          p0 = value;
        else
        {
          if (p0.y > value.y)
            p0 = value;
        }
      }
      var order = points.Where(value => p0 != value).ToList();

      order = MergeSort(p0, order);
      var result = new List<Node>
      {
        p0
      };
      if(order.Count > 0)
        result.Add(order[0]);
      if (order.Count > 1)
        result.Add(order[1]);

      if (order.Count > 0)
        order.RemoveAt(0);
      if (order.Count > 0)
        order.RemoveAt(0);
      foreach (var value in order)
      {
        KeepLeft(result, value);
      }
      return result;
    }
  }
}