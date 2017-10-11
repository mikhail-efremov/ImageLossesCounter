using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;

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

      foreach (var targetP in points)
      {
        for (var hullIndex = 0; hullIndex < points.Count; hullIndex++)
        {
          var distBetweetPoints = targetP.DistanceSquared(points[hullIndex]);

          if (distBetweetPoints > distance)
          {
            distance = distBetweetPoints;
            firstPoint = targetP;
            secondPoint = points[hullIndex];
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
    {/*
      var p3 = new Point(0, 0);
      var p4 = new Point(100, 0);

      var angle1 = (float)Math.Atan2(p2.Y - p1.Y, p1.X - p2.X);
      var angle2 = (float)Math.Atan2(p4.Y - p3.Y, p3.X - p4.X);
      var calculatedAngle = (angle1 - angle2) * (float)(180.0 / Math.PI);
      if (calculatedAngle < 0)
        calculatedAngle += 360;

      return calculatedAngle - 180;//
      */
      var deltaY = p2.Y - p1.Y;
      var deltaX = p2.X - p1.X;

      var angle = Math.Atan2(deltaY, deltaX) * 180 / Math.PI;

      if (angle < 0)
        return angle + 180;
      return angle;
    }
  }
}