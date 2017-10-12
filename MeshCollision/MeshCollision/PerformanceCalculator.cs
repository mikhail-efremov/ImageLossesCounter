using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace MeshCollision
{
  public class PerformanceCalculator
  {
    private static List<Perf> Perfs = new List<Perf>();

    static PerformanceCalculator()
    {
      Write(Environment.NewLine + "---------------------NEW SESSION--------------------");
    }

    public static void Start(string name)
    {
      var perf = new Perf {Name = name, Stopwatch = new Stopwatch()};
      perf.Stopwatch.Start();
      Perfs.Add(perf);
    }

    public static void Stop(string name)
    {
      var perfs = Perfs.Where(p => p.Name == name).ToArray();
      if(perfs.Length == 0)
        return;
      var perf = perfs.First();

      perf.Stopwatch.Stop();
      Perfs.Remove(perf);
      WriteStats(perf);
    }

    private static void WriteStats(Perf perf)
    {
      var createText = Environment.NewLine + perf.Name + ": " + perf.Stopwatch.ElapsedMilliseconds;
      File.AppendAllText(@"C:\Users\mikha\Desktop\1.txt", createText);
    }

    private static void Write(string text)
    {
      File.AppendAllText(@"C:\Users\mikha\Desktop\1.txt", text);
    }

    private class Perf
    {
      public string Name;
      public Stopwatch Stopwatch;
    }
  }
}