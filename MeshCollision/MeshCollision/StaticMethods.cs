using System.Drawing;

namespace MeshCollision
{
  public class StaticMethods
  {
    public static bool PointIsBeside(Point p1, Point p2)
    {
        if (p1.X == p2.X && p1.Y == p2.Y + 1)
            return true;
        if (p1.X == p2.X && p1.Y == p1.Y - 1)
            return true;
        if (p1.X == p2.X && p1.Y == p2.Y)
            return true;
        if (p1.X == p2.X + 1 && p1.Y == p2.Y)
            return true;
        if (p1.X == p2.X - 1 && p1.Y == p2.Y)
            return true;
        if (p1.X == p2.X + 1 && p1.Y == p2.Y + 1)
            return true;
        if (p1.X == p2.X + 1 && p1.Y == p2.Y - 1)
            return true;
        if (p1.X == p2.X - 1 && p1.Y == p2.Y + 1)
            return true;
        if (p1.X == p2.X - 1 && p1.Y == p2.Y - 1)
            return true;
        return false;
    }
  }
}