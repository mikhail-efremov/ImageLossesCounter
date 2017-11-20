using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace ConcaveHull
{
  public static class Hull
  {
    private static int _scaleFactor;
    private static readonly List<Node> _unusedNodes = new List<Node>();
    private static readonly List<Line> _hullEdges = new List<Line>();
    private static List<Line> _hullConcaveEdges = new List<Line>();

    private static readonly List<Node> _list = new List<Node>(); //i dont know why this need

    public static List<Line> Generate(List<Point> dotList, double concavity /*-1..1*/,
      int scaleFactor, bool isSquareGrid)
    {
      return SetConcaveHull(dotList, Math.Round(Convert.ToDecimal(concavity), 2), scaleFactor, isSquareGrid);
    }

    private static List<Line> SetConcaveHull(IReadOnlyList<Point> dotList, decimal concavity, int scaleFactor, bool isSquareGrid)
    {
      /* Run setConvHull before! 
       * Concavity is a value used to restrict the concave angles 
       * it can go from -1 to 1 (it wont crash if you go further)
       * */
      TestModel(dotList);
      SetConvHull(_list);

      _scaleFactor = scaleFactor;
      _hullConcaveEdges = new List<Line>(_hullEdges.OrderByDescending(a => Line.getLength(a.nodes[0], a.nodes[1])).ToList());
      bool listIsModified;
      do
      {
        listIsModified = false;
        var count = 0;
        var listOriginalSize = _hullConcaveEdges.Count;
        while (count < listOriginalSize)
        {
          var selectedEdge = _hullConcaveEdges[0];
          _hullConcaveEdges.RemoveAt(0);
          var aux = new List<Line>();
          if (!selectedEdge.isChecked)
          {
            var nearbyPoints = HullFunctions.getNearbyPoints(selectedEdge, _unusedNodes, _scaleFactor);
            aux.AddRange(HullFunctions.setConcave(selectedEdge, nearbyPoints, _hullConcaveEdges, concavity, isSquareGrid));
            listIsModified = listIsModified || aux.Count > 1;

            if (aux.Count > 1)
            {
              foreach (var node in aux[0].nodes)
              {
                if (_unusedNodes.Find(a => a.id == node.id) != null)
                {
                  _unusedNodes.Remove(_unusedNodes.First(a => a.id == node.id));
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
          _hullConcaveEdges.AddRange(aux);
          count++;
        }
        _hullConcaveEdges = _hullConcaveEdges.OrderByDescending(a => Line.getLength(a.nodes[0], a.nodes[1])).ToList();
      } while (listIsModified);

      _list.Clear();

      return _hullConcaveEdges;
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

    private static void SetConvHull(List<Node> nodes)
    {
      _unusedNodes.Clear();
      _hullEdges.Clear();
      _hullConcaveEdges.Clear();

      _unusedNodes.AddRange(nodes);
      _hullEdges.AddRange(GetHull(nodes));
      foreach (var line in _hullEdges)
      {
        foreach (var node in line.nodes)
        {
          if (_unusedNodes.Find(a => a.id == node.id) != null)
          {
            _unusedNodes.Remove(_unusedNodes.First(a => a.id == node.id));
          }
        }
      }
    }

    private static void TestModel(IReadOnlyList<Point> points)
    {
      //Used only for the demo
      for (var x = 0; x < points.Count; x++)
      {
        _list.Add(new Node(points[x].X, points[x].Y, x));
      }
      //Delete repeated nodes
      for (var pivotPosition = 0; pivotPosition < _list.Count; pivotPosition++)
      {
        for (var position = 0; position < _list.Count; position++)
          if (_list[pivotPosition].x == _list[position].x && _list[pivotPosition].y == _list[position].y
              && _list[pivotPosition].id != _list[position].id)
          {
            _list.RemoveAt(position);
            position--;
          }
      }
    }
  }
}