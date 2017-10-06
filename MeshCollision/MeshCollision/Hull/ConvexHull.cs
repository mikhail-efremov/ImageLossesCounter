using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace MeshCollision.Hull
{
  public static class ConvexHull
  {
    public static IEnumerable<Point> Calculate(List<Point> mPoints)
    {
      if (mPoints.Count >= 3)
      {
        // Get the convex hull.
        var hull = Geometry.MakeConvexHull(mPoints.ToList());

        // Draw the MinMax quadrilateral.
        //   e.Graphics.DrawPolygon(Pens.Red, Geometry.g_MinMaxCorners);

        // Draw the culling box.
        //    e.Graphics.DrawRectangle(Pens.Orange, Geometry.g_MinMaxBox);

        // Draw the convex hull.
        if (hull == null)
          return null;

        var hullPoints = new Point[hull.Count];
        hull.CopyTo(hullPoints);

        return hullPoints;
      }
      return null;
    }
  }
}