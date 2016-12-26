using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeshCollision
{
    public class Line
    {
        public List<Point> Points;

        public Point FirstPoint => Points[0];
        public Point LastPoint => Points[Points.Count - 1];

        public Line(Point firstPoint, Point lastPoint)
        {
            Points = new List<Point>();
            ConstructLine(firstPoint, lastPoint);
        }

        private void ConstructLine(Point fPoint, Point sPoint)
        {
            var quantity = 20;

            var ydiff = sPoint.Y - fPoint.Y;
            var xdiff = sPoint.X - fPoint.X;

            var slope = (double) (sPoint.Y - fPoint.Y)/(sPoint.X - fPoint.X);
            double x, y;

            quantity--;

            for (var i = 0; i < quantity; i++)
            {
                y = slope == 0 ? 0 : ydiff*(i/quantity);
                x = slope == 0 ? xdiff*(i/quantity) : y/slope;
                var point = new Point((int) Math.Round(x) + fPoint.X, (int) Math.Round(y) + fPoint.Y);

                Points.Add(point);
            }

            Points[quantity] = sPoint;
        }
    }
}
