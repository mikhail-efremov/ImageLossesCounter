using System;
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
        
        public static bool ColorSimilar(Color c1, Color c2, byte sens)
        {
            if (sens >= 255)
                return true;
            try
            {
                if (c1.B > c2.B - sens && c1.B < c2.B + sens
                    && c1.G > c2.G - sens && c1.G < c2.G + sens
                    && c1.R > c2.R - sens && c1.R < c1.R + sens)
                    return true;
            }
            catch (Exception)
            {
                // ignored
            }
            return false;
        }
    }
}