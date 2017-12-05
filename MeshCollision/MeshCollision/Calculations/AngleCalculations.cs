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
    public static PointsOrientation CalculatePointsOrientation(List<Point> points,
      Point firstPoint, Point lastPoint, double distance)
    {
      var angle = AngleBetweenLineAndHorisontalAxis(firstPoint, lastPoint);
      
      return new PointsOrientation
      {
        Angles = Math.Round(angle).ToString(CultureInfo.InvariantCulture) + "°",
        AnglesPosition = new Point((firstPoint.X + lastPoint.X) / 2,
          (firstPoint.Y + lastPoint.Y) / 2),
        FirstPoint = firstPoint,
        SecondPoint = lastPoint
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