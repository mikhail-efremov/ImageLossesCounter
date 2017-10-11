using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace MeshCollision.Calculations
{
  public class PointInPolygonChecker
  {
    private readonly List<Point> _points;

    public PointInPolygonChecker(List<Point> points)
    {
      _points = points;
    }

    // Return True if the point is in the polygon.
    public bool PointInPolygon(float X, float Y)
    {
      // Get the angle between the point and the
      // first and last vertices.
      int max_point = _points.Count - 1;
      float total_angle = GetAngle(
        _points[max_point].X, _points[max_point].Y,
        X, Y,
        _points[0].X, _points[0].Y);

      // Add the angles from the point
      // to each other pair of vertices.
      for (int i = 0; i < max_point; i++)
      {
        total_angle += GetAngle(
          _points[i].X, _points[i].Y,
          X, Y,
          _points[i + 1].X, _points[i + 1].Y);
      }

      // The total angle should be 2 * PI or -2 * PI if
      // the point is in the polygon and close to zero
      // if the point is outside the polygon.
      return (Math.Abs(total_angle) > 0.000001);
    }

    // Return the angle ABC.
    // Return a value between PI and -PI.
    // Note that the value is the opposite of what you might
    // expect because Y coordinates increase downward.
    public static float GetAngle(float Ax, float Ay,
      float Bx, float By, float Cx, float Cy)
    {
      // Get the dot product.
      float dot_product = DotProduct(Ax, Ay, Bx, By, Cx, Cy);

      // Get the cross product.
      float cross_product = CrossProductLength(Ax, Ay, Bx, By, Cx, Cy);

      // Calculate the angle.
      return (float)Math.Atan2(cross_product, dot_product);
    }

    // Return the dot product AB · BC.
    // Note that AB · BC = |AB| * |BC| * Cos(theta).
    private static float DotProduct(float Ax, float Ay,
      float Bx, float By, float Cx, float Cy)
    {
      // Get the vectors' coordinates.
      float BAx = Ax - Bx;
      float BAy = Ay - By;
      float BCx = Cx - Bx;
      float BCy = Cy - By;

      // Calculate the dot product.
      return (BAx * BCx + BAy * BCy);
    }

    public static float CrossProductLength(float Ax, float Ay,
      float Bx, float By, float Cx, float Cy)
    {
      // Get the vectors' coordinates.
      float BAx = Ax - Bx;
      float BAy = Ay - By;
      float BCx = Cx - Bx;
      float BCy = Cy - By;

      // Calculate the Z coordinate of the cross product.
      return (BAx * BCy - BAy * BCx);
    }
  }
}