using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace ConcaveHull
{
  public static class Hull
  {
    private static int _scaleFactor;

    public static List<Line> Generate(List<Point> dotList, double concavity /*-1..1*/,
      int scaleFactor, bool isSquareGrid)
    {
      return SetConcaveHull(dotList, Math.Round(Convert.ToDecimal(concavity), 2), scaleFactor, isSquareGrid);
    }

    private static List<Line> SetConcaveHull(IReadOnlyList<Point> dotList, decimal concavity, int scaleFactor, bool isSquareGrid)
    {
       /* Concavity is a value used to restrict the concave angles 
       * it can go from -1 to 1 (it wont crash if you go further)
       * */

      var nodes = CunstructNodes(dotList);
      var convecsHullEdges = SetConvHull(nodes, out var unusedNodes);

      _scaleFactor = scaleFactor;
      var hullConcaveEdges = new List<Line>(convecsHullEdges.OrderByDescending(a => Line.getLength(a.nodes[0], a.nodes[1])).ToList());
      bool listIsModified;
      do
      {
        listIsModified = false;
        var count = 0;
        var listOriginalSize = hullConcaveEdges.Count;
        while (count < listOriginalSize)
        {
          var selectedEdge = hullConcaveEdges[0];
          hullConcaveEdges.RemoveAt(0);
          var aux = new List<Line>();
          if (!selectedEdge.isChecked)
          {
            var nearbyPoints = HullFunctions.getNearbyPoints(selectedEdge, unusedNodes, _scaleFactor);
            aux.AddRange(HullFunctions.setConcave(selectedEdge, nearbyPoints, hullConcaveEdges, concavity, isSquareGrid));
            listIsModified = listIsModified || aux.Count > 1;

            if (aux.Count > 1)
            {
              foreach (var node in aux[0].nodes)
              {
                if (unusedNodes.Find(a => a.id == node.id) != null)
                {
                  unusedNodes.Remove(unusedNodes.First(a => a.id == node.id));
                }
              }
            }
            else
            {
              aux[0].isChecked = true;
            }
          }
          else
          {
            aux.Add(selectedEdge);
          }
          hullConcaveEdges.AddRange(aux);
          count++;
        }
        hullConcaveEdges = hullConcaveEdges.OrderByDescending(a => Line.getLength(a.nodes[0], a.nodes[1])).ToList();
      } while (listIsModified);

      return hullConcaveEdges;
    }

    private static IEnumerable<Line> GetHull(List<Node> nodes)
    {
      var exitLines = new List<Line>();

      var convexH = new List<Node>();
      convexH.AddRange(GrahamScan.convexHull(nodes));
      for (var i = 0; i < convexH.Count - 1; i++)
      {
        exitLines.Add(new Line(convexH[i], convexH[i + 1]));
      }
      exitLines.Add(new Line(convexH[0], convexH[convexH.Count - 1]));
      return exitLines;
    }

    private static List<Line> SetConvHull(List<Node> nodes, out List<Node> unusedNodes)
    {
      var hullEdges = new List<Line>();
      unusedNodes = new List<Node>();
      
      unusedNodes.AddRange(nodes);
      hullEdges.AddRange(GetHull(nodes));
      foreach (var line in hullEdges)
      {
        foreach (var node in line.nodes)
        {
          if (unusedNodes.Find(a => a.id == node.id) != null)
          {
            unusedNodes.Remove(unusedNodes.First(a => a.id == node.id));
          }
        }
      }
      return hullEdges;
    }

    private static List<Node> CunstructNodes(IReadOnlyList<Point> points)
    {
      var nodes = new List<Node>();
     
      for (var x = 0; x < points.Count; x++)
      {
        nodes.Add(new Node(points[x].X, points[x].Y, x));
      }
      //Delete repeated nodes
      for (var pivotPosition = 0; pivotPosition < nodes.Count; pivotPosition++)
      {
        for (var position = 0; position < nodes.Count; position++)
          if (nodes[pivotPosition].x == nodes[position].x && nodes[pivotPosition].y == nodes[position].y
              && nodes[pivotPosition].id != nodes[position].id)
          {
            nodes.RemoveAt(position);
            position--;
          }
      }
      return nodes;
    }
  }
}