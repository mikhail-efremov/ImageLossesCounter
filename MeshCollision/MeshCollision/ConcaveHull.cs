using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace MeshCollision
{
  class ConcaveHull
  {
    public static List<Point> Calc(List<Point> pointsList, int numberOfNeighbours)
    {
      var kk = Math.Max(numberOfNeighbours, 3);

      var dataSet = pointsList; //TODO: remove equal points
      if (dataSet.Count < 3)
        return null; //a minimum of 3 dissimilar points is required

      if (dataSet.Count == 3)
        return dataSet;

      kk = Math.Min(kk, dataSet.Count - 1);

      var firstPoint = FindMinYPoint(dataSet);
      var hull = new List<Point> {firstPoint};

      var currentPoint = firstPoint;
      dataSet.Remove(firstPoint);

      var previousAngle = 0;
      var step = 2;

      while ((currentPoint != firstPoint || step == 2) && (dataSet.Count > 0))
      {
        if (step == 5)
        {
          dataSet.Add(firstPoint);
        }

        var kNearestPoints = NearestPoints(dataSet, currentPoint, kk); //check order
//        var cPoints = SortByAngle(kNearestPoints, currentPoint);//, prevAngle); //check order
        var cPoints = new List<Point>(kNearestPoints);

        var its = true;
        var i = 0;

        var lastPoint = 0;

        while ((its) && (i < cPoints.Count))
        {
          i++;
          if (cPoints[i] == firstPoint)
            lastPoint = 0;
          else
            lastPoint = 1;
          var j = 2;
          its = false;

          while ((its == false) && (j < hull.Count - lastPoint) && (step - 1) < hull.Count)//CUSTOM
          {
            var start = hull[step - 1];
            var end = cPoints[i];

            var r = new RectangleF(Math.Min(start.X, end.X),
              Math.Min(start.Y, end.Y),
              Math.Abs(start.X - end.X),
              Math.Abs(start.Y - end.Y));

            var start1 = hull[step - 1 - j];
            var end1 = hull[step - j];

            var r1 = new RectangleF(Math.Min(start1.X, end1.X),
              Math.Min(start1.Y, end1.Y),
              Math.Abs(start1.X - end1.X),
              Math.Abs(start1.Y - end1.Y));

            its = IntersectsQ(r, r1);
            j++;
          }

          if (its)
            return Calc(pointsList, kk + 1);
        }
        currentPoint = cPoints[i];

        hull.Add(currentPoint);

        //       var prevAngle ← Angle[hullstep, hullstep - 1]
        dataSet.Remove(currentPoint);
        step++;
        
      var allInside = true;
      i = dataSet.Count;

      while ((allInside) && (i > 0) && i < dataSet.Count) //CUSTOM
      {
        allInside = PointInPolygonQ(dataSet[i], hull);
        i--;
      }
      if (allInside == false)
        return Calc(pointsList, kk + 1);
        
      }
      return hull;
    }

    private static bool PointInPolygonQ(Point point, List<Point> points)
    {
      var coef = points.Skip(1).Select((p, i) =>
          (point.Y - points[i].Y) * (p.X - points[i].X)
          - (point.X - points[i].X) * (p.Y - points[i].Y))
        .ToList();

      if (coef.Any(p => p == 0))
        return true;

      for (int i = 1; i < coef.Count(); i++)
      {
        if (coef[i] * coef[i - 1] < 0)
          return false;
      }
      return true;
    }



    /*
    14: While ((currentPoint≠firstPoint)or(step=2))and(Length[dataset]>0)
    15: If step=5
    16: dataset ← AddPoint[dataset,firstPoint] ► add the firstPoint again
    17: kNearestPoints ← NearestPoints[dataset,currentPoint,kk] ► find the nearest neighbours
    18: cPoints ← SortByAngle[kNearestPoints,currentPoint,prevAngle] ► sort the candidates
    (neighbours) in descending order of right-hand turn
    19: its ← True
    20: i ← 0
    21: While (its=True)and(i<Length[cPoints]) ► select the first candidate that does not intersects any
    of the polygon edges
    22: i++
    23: If cPointsi=firstPoint
    24: lastPoint ← 1
    25: else
    26: lastPoint ← 0
    27: j ← 2
    28: its ← False
    29: While (its=False)and(j<Length[hull]-lastPoint)
    30: its ← IntersectsQ[{hullstep-1,cPointsi},{hullstep-1-j,hullstep-j}]
    31: j++
    32: If its=True ► since all candidates intersect at least one edge, try again with a higher number of neighbours
    33: Return[ConcaveHull[pointsList,kk+1]]
    34: currentPoint ← cPointsi
    35: hull ← AddPoint[hull,currentPoint] ► a valid candidate was found
    36: prevAngle ← Angle[hullstep,hullstep-1]
    37: dataset ← RemovePoint[dataset,currentPoint]
    38: step++
    39: allInside ← True
    40: i ← Length[dataset]
    41: While (allInside=True)and(i>0) ► check if all the given points are inside the computed polygon
    42: allInside ← PointInPolygonQ[dataseti,hull]
    43: i--
    44: If allInside=False
    45: Return[ConcaveHull[pointsList,kk+1]] ► since at least one point is out of the computed polygon,
    try again with a higher number of neighbours
    46: Return[hull] ► a valid hull was found!
       */

    private static bool IntersectsQ(RectangleF seg1, RectangleF seg2)
    {
      return seg1.IntersectsWith(seg2);
    }

    private static Point FindMinYPoint(List<Point> points)
    {
      var min = int.MaxValue;
      var point = points[0];

      foreach (var p in points)
      {
        if (p.Y < min)
        {
          min = p.Y;
          point = p;
        }
      }
      return point;
    }

    private static List<Point> NearestPoints(List<Point> dataSet, Point centerPoint, int count)
    {
      if (count >= dataSet.Count)
        return dataSet;//CUSTOM

      var sorted = dataSet.OrderBy(p => p.DistanceSquared(centerPoint)).ToList();
      return sorted.GetRange(0, count);
    }
  }
}