using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace nAlpha
{
    public class AlphaShapeCalculator
    {
        public bool CloseShape { get; set; }
        public double Radius { get; set; }

    private List<Tuple<int, int>> resultingEdges = new List<Tuple<int, int>>();
        private List<PointA> resultingVertices = new List<PointA>();
        private PointA[] points;

        public Shape CalculateShape(PointA[] points)
        {
            SetData(points);
            CalculateShape();
            if (CloseShape)
            {
                CloseShapeImpl();
            }
            return GetShape();
        }

      public Shape CalculateShape(Point[] point)
      {
        var ps = point.Select(p => new PointA(p.X, p.Y)).ToArray();
        return CalculateShape(ps);
      }

    private void CloseShapeImpl()
        {
            var vertexCounter = CountVertices();
            var vertexIndices = vertexCounter.GetIndicesByCount(1);

      if(vertexIndices.Length > 1) //CUSTOM
            AddClosingEdges(vertexIndices);
        }

        private void AddClosingEdges(int[] vertexIndices)
        {
            foreach (var vertexIndex in vertexIndices)
            {
                var nearestPendingVertex = GetNearestPendingVertex(vertexIndices, vertexIndex);
                AddEdge(resultingVertices[vertexIndex], resultingVertices[nearestPendingVertex]);
            }
        }

        private void SetData(PointA[] points)
        {
            resultingEdges.Clear();
            resultingVertices.Clear();
            this.points = points;
        }

        private void CalculateShape()
        {
            foreach (var point in points)
            {
                ProcessPoint(point);
            }
        }

        private VertexCounter CountVertices()
        {
            
            VertexCounter counter = new VertexCounter();

            foreach (var edge in resultingEdges)
            {
                counter.IncreaseForIndex(edge.Item1);
                counter.IncreaseForIndex(edge.Item2);
            }

            return counter;
        }

        private int GetNearestPendingVertex(int[] vertices, int vertexIndex)
        {
            var vertexPoint = GetVertex(vertexIndex);
            var vertexIndicesWithDistance =
                vertices.Where(v => v != vertexIndex).Select(v => new {Index = v, Distance = resultingVertices[v].DistanceTo(vertexPoint)});
            return vertexIndicesWithDistance.Aggregate((a, b) => a.Distance < b.Distance ? a : b).Index;
        }

        private PointA GetVertex(int vertexIndex)
        {
            return resultingVertices[vertexIndex];
        }

        private void ProcessPoint(PointA point)
        {
            foreach (var otherPoint in NearbyPoints(point))
            {
                Tuple<PointA, PointA> alphaDiskCenters = CalculateAlphaDiskCenters(point, otherPoint);

                if (!DoOtherPointsFallWithinDisk(alphaDiskCenters.Item1, point, otherPoint)
                    || !DoOtherPointsFallWithinDisk(alphaDiskCenters.Item2, point, otherPoint))
                {
                    AddEdge(point, otherPoint);
                }
            }
        }

        private bool DoOtherPointsFallWithinDisk(PointA center, PointA p1, PointA p2)
        {
            return NearbyPoints(center).Count(p => p != p1 && p != p2) > 0;
        }

        private void AddEdge(PointA p1, PointA p2)
        {
            int indexP1;
            int indexP2;

            indexP1 = AddVertex(p1);
            indexP2 = AddVertex(p2);

            AddEdge(indexP1, indexP2);
        }

        private void AddEdge(int indexP1, int indexP2)
        {
            if (!resultingEdges.Contains(new Tuple<int, int>(indexP1, indexP2))
                && !resultingEdges.Contains(new Tuple<int, int>(indexP2, indexP1)))
                resultingEdges.Add(new Tuple<int, int>(indexP1, indexP2));
        }

        private int AddVertex(PointA p)
        {
            int index;
            if (!resultingVertices.Contains(p))
            {
                resultingVertices.Add(p);
            }
            index = resultingVertices.IndexOf(p);
            return index;
        }

        private PointA[] NearbyPoints(PointA point)
        {
            var nearbyPoints = points.Where(p => p.DistanceTo(point) <= Radius && p != point).ToArray();
            return nearbyPoints;
        }

        private Tuple<PointA, PointA> CalculateAlphaDiskCenters(PointA p1, PointA p2)
        {
            double distanceBetweenPoints = p1.DistanceTo(p2);
            double distanceFromConnectionLine = Math.Sqrt(Radius*Radius - distanceBetweenPoints*distanceBetweenPoints/4);

            PointA centerOfConnectionLine = p1.CenterTo(p2);
            PointA vector = p1.VectorTo(p2);

            return GetAlphaDiskCenters(vector, centerOfConnectionLine, distanceFromConnectionLine);
        }

        private static Tuple<PointA, PointA> GetAlphaDiskCenters(PointA vector, PointA center, double distanceFromConnectionLine)
        {
            PointA normalVector = new PointA(vector.Y, -vector.X);
            return
                new Tuple<PointA, PointA>(
                    new PointA(center.X + normalVector.X*distanceFromConnectionLine,
                        center.Y + normalVector.Y*distanceFromConnectionLine),
                    new PointA(center.X - normalVector.X*distanceFromConnectionLine,
                        center.Y - normalVector.Y*distanceFromConnectionLine));
        }

        private Shape GetShape()
        {
            return new Shape(resultingVertices.ToArray(), resultingEdges.ToArray());
        }


  }
}
