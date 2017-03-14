using System;
using System.Drawing;
using System.ComponentModel;

namespace MeshCollision
{
  public class SelectionElement
  {
    [Description("Minimum value of the slider.")]
    public int Min {
      get { return min; }
      set { min = value; }
    }
    int min = 0;

    [Description("Maximum value of the slider.")]
    public int Max {
      get { return max; }
      set { max = value; }
    }
    int max = 360;

    [Description("Minimum value of the selection range.")]
    public int SelectedMin {
      get { return selectedMin; }
      set
      {
        selectedMin = value;
        SelectionChanged?.Invoke(this, null);
      }
    }
    int selectedMin = 0;

    [Description("Maximum value of the selection range.")]
    public int SelectedMax {
      get { return selectedMax; }
      set
      {
        selectedMax = value;
        SelectionChanged?.Invoke(this, null);
      }
    }
    int selectedMax = 0;
    private int Width = 0;
    private int Height = 0;
    public SelectionElement(int Width, int Height, int m_max, int m_min, Color linesColor) {
      this.Width = Width;
      this.Height = Height;
      LinesColor = linesColor;

      selectedMax = m_max;
      selectedMin = m_min;
    }

    public int LinesCount { get; set; } = 0;
    public Color LinesColor { get; set; }
    public int SValue1000 { get; set; } = 1000;
    public int LValue1000 { get; set; } = 500;
    public double SValue1 => SValue1000 / 1000d;
    public double LValue1 => LValue1000 / 1000d;
    public int Hits { get; set; } = 0;

    [Description("Fired when SelectedMin or SelectedMax changes.")]
    public event EventHandler SelectionChanged;
    public event EventHandler ElementSelected;

    public void SelectElement()
    {
      ElementSelected?.Invoke(this, null);
    }
  }
}