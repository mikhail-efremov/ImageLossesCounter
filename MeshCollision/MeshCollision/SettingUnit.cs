using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace MeshCollision
{
  internal class SettingUnit
  {
    private static string _unitPath;

    public int ColorMin;
    public int ColorMax;
    public int L1000;
    public int S1000;

    public byte ColorSens;
    public double ClusterDistance;
    public double Concavity;
    public int LineWidth;

    public int EtalonLineWidth;

    public HashSet<Point> Points;

    public void Save(SaveFileDialog dialog)
    {
      dialog.Filter = @"txt files (*.txt)|*.txt";
      dialog.FilterIndex = 2;
      dialog.RestoreDirectory = true;
      dialog.InitialDirectory = System.Reflection.Assembly.GetExecutingAssembly().Location;

      if (dialog.ShowDialog() != DialogResult.OK)
        return;

      var file = dialog.OpenFile();
        
      using (var sr = new StreamWriter(file))
      using (var jsonTextWriter = new JsonTextWriter(sr))
      {
        var ser = new JsonSerializer();
        ser.Serialize(jsonTextWriter, this);
        jsonTextWriter.Flush();
      }
    }

    public static SettingUnit Load()
    {
      var open = new OpenFileDialog
      {
        Filter = @"txt files (*.txt)|*.txt|All files (*.*)|*.*"
      };

      _unitPath = open.ShowDialog() == DialogResult.OK ? open.FileName : null;
      if (_unitPath == null)
        return null;

      using (var r = new StreamReader(_unitPath))
      {
        var json = r.ReadToEnd();
        return JsonConvert.DeserializeObject<SettingUnit>(json);
      }
    }
  }
}