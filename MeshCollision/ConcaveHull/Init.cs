using System.Collections.Generic;
using System;
using System.Drawing;
using System.Linq;

namespace ConcaveHull
{
  public class Init
  {
  static   List<Node> LIST = new List<Node>(); //Used only for the demo

    public static string seed = "dada";
    public static int scaleFactor = 1;
    public static int number_of_dots;

    //-1..1
    public static double concavity = -.3;
    public static bool isSquareGrid = true;
    
    public static void generateHull(List<Point> dot_list)
    {
      HUIZIVNASHO(dot_list);
      Hull.setConvHull(LIST);
      Hull.setConcaveHull(Math.Round(Convert.ToDecimal(concavity), 2), scaleFactor, isSquareGrid);
      LIST.Clear();
    }
    
    public  static void setDots(int number_of_dots)
    {
      //Used only for the demo
      System.Random pseudorandom = new System.Random(seed.GetHashCode());
      for (int x = 0; x < number_of_dots; x++)
      {
        LIST.Add(new Node(pseudorandom.Next(0, 100), pseudorandom.Next(0, 100), x));
      }
      //Delete repeated nodes
      for (int pivot_position = 0; pivot_position < LIST.Count; pivot_position++)
      {
        for (int position = 0; position < LIST.Count; position++)
          if (LIST[pivot_position].x == LIST[position].x && LIST[pivot_position].y == LIST[position].y
              && LIST[pivot_position].id != LIST[position].id)
          {
            LIST.RemoveAt(position);
            position--;
          }
      }
    }
    
    public static void HUIZIVNASHO(List<Point> points)
    {
      //Used only for the demo
      for (int x = 0; x < points.Count; x++)
      {
        LIST.Add(new Node(points[x].X, points[x].Y, x));
      }
      //Delete repeated nodes
      for (int pivot_position = 0; pivot_position < LIST.Count; pivot_position++)
      {
        for (int position = 0; position < LIST.Count; position++)
          if (LIST[pivot_position].x == LIST[position].x && LIST[pivot_position].y == LIST[position].y
              && LIST[pivot_position].id != LIST[position].id)
          {
            LIST.RemoveAt(position);
            position--;
          }
      }
    }
    /*
    void OnDrawGizmos()
    {

      //Convex hull
      Gizmos.color = Color.yellow;
      for (int i = 0; i < Hull.hull_edges.Count; i++)
      {
        Vector2 left = new Vector2((float)Hull.hull_edges[i].nodes[0].x, (float)Hull.hull_edges[i].nodes[0].y);
        Vector2 right = new Vector2((float)Hull.hull_edges[i].nodes[1].x, (float)Hull.hull_edges[i].nodes[1].y);
        Gizmos.DrawLine(left, right);
      }
      //Concave hull
      Gizmos.color = Color.blue;
      for (int i = 0; i < Hull.hull_concave_edges.Count; i++)
      {
        Vector2 left = new Vector2((float)Hull.hull_concave_edges[i].nodes[0].x, (float)Hull.hull_concave_edges[i].nodes[0].y);
        Vector2 right = new Vector2((float)Hull.hull_concave_edges[i].nodes[1].x, (float)Hull.hull_concave_edges[i].nodes[1].y);
        Gizmos.DrawLine(left, right);
      }

      Gizmos.color = Color.red;
      for (int i = 0; i < dot_list.Count; i++)
      {
        Gizmos.DrawSphere(new Vector3((float)dot_list[i].x, (float)dot_list[i].y, 0), 0.5f);
      }
      */
  }
}