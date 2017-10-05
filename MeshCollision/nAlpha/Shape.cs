using System;

namespace nAlpha
{
    public class Shape
    {
        public Shape(PointA[] vertices, Tuple<int, int>[] edges)
        {
            Vertices = vertices;
            Edges = edges;
        }

        public PointA[] Vertices { get; private set; }
        public Tuple<int, int>[] Edges { get; private set; }
    }
}