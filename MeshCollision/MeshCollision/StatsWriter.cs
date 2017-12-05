using System;
using System.IO;

namespace MeshCollision
{
  internal class StatsWriter
  {
    private static int id = 0;

    static StatsWriter()
    {
      WriteImpl(Environment.NewLine + "---------------------NEW SESSION--------------------");
    }

    public static void Write(Stat stat)
    {
      WriteImpl(Environment.NewLine);

      var createText = ++id + "\t" + stat.S + "\t" + stat.Mid + "\t" + stat.Max + "\t" + stat.Angle;
      WriteImpl(createText);
    }

    private static void WriteImpl(string text)
    {
      File.AppendAllText(@"C:\Users\mikha\Desktop\stat.txt", text);
    }

    internal class Stat
    {
      public string S;
      public string Mid;
      public string Max;
      public string Angle;
    }
  }
}