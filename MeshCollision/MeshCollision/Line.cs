using System;
using System.Collections.Generic;
using System.Drawing;

namespace MeshCollision
{
    public class Line
    {
        public List<Point> Points;

        public Point FirstPoint => Points[0];
        public Point LastPoint => Points[Points.Count - 1];

        public Line(Point firstPoint, Point lastPoint, int count)
        {
            Points = ConstructLine(firstPoint, lastPoint, count);
        }

        private List<Point> ConstructLine(Point pointA, Point pointB, int count)
        {
            List<Point> points = new List<Point>(count);

            int min, max;

            if (pointA.X == pointB.X)
            {
                min = Math.Min(pointA.Y, pointB.Y);
                max = Math.Max(pointA.Y, pointB.Y);
            }
            else
            {
                min = Math.Min(pointA.X, pointB.X);
                max = Math.Max(pointA.X, pointB.X);
            }

            for (int i = min; i < max; ++i)
            {
                if (pointA.X == pointB.X)
                {
                    points.Add(new Point(pointA.X, i));
                }
                else
                {
                    points.Add(new Point(i, pointA.Y));
                }
            }
            return points;
        }
    }
}
