using System.Drawing;

namespace MeshCollision
{
  public static class PointExt
  {
    public static int DistanceSquared(this Point p1, Point p2)
    {
      var diffX = p2.X - p1.X;
      var diffY = p2.Y - p1.Y;
      return diffX * diffX + diffY * diffY;
    }
  }
}