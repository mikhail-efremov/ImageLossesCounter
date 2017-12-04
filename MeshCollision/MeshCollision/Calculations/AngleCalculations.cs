using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using MeshCollision.Clustering;

namespace MeshCollision.Calculations
{
  public class PointsOrientation
  {
    public string Angles;
    public Point AnglesPosition;
    public Point FirstPoint;
    public Point SecondPoint;
  }

  public class AngleCalculations
  {
    public static PointsOrientation CalculatePointsOrientation(List<Point> points)
    {
      var firstPoint = new Point();
      var secondPoint = new Point();
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
            secondPoint = secondP;
          }
        }
      }

      var angle = AngleBetweenLineAndHorisontalAxis(firstPoint, secondPoint);
      
      return new PointsOrientation
      {
        Angles = Math.Round(angle).ToString(CultureInfo.InvariantCulture) + "°",
        AnglesPosition = new Point((firstPoint.X + secondPoint.X) / 2,
          (firstPoint.Y + secondPoint.Y) / 2),
        FirstPoint = firstPoint,
        SecondPoint = secondPoint
      };
    }

    private static double AngleBetweenLineAndHorisontalAxis(Point p1, Point p2)
    {
      var deltaY = p2.Y - p1.Y;
      var deltaX = p2.X - p1.X;

      var angle = Math.Atan2(deltaY, deltaX) * 180 / Math.PI;

      if (angle < 0)
        return angle + 180;
      return angle;
    }
  }
}