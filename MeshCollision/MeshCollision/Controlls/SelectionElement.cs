﻿using System;
using System.ComponentModel;
using System.Drawing;

namespace MeshCollision.Controlls
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
        if(SelectionChanged != null)
          SelectionChanged(this, null);
      }
    }
    int selectedMin = 0;

    [Description("Maximum value of the selection range.")]
    public int SelectedMax {
      get { return selectedMax; }
      set
      {
        selectedMax = value;
        if (SelectionChanged != null)
          SelectionChanged(this, null);
      }
    }
    int selectedMax = 0;

    public SelectionElement(int m_max, int m_min, Color linesColor) {
      LinesColor = linesColor;

      selectedMax = m_max;
      selectedMin = m_min;
    }

    public int LinesCount { get; set; }
    public Color LinesColor { get; set; }

    private int sValue1000 = 1000;
    public int SValue1000 {
      get => sValue1000;
      set => sValue1000 = value;
    }

    private int lValue1000 = 500;
    public int LValue1000 { 
      get => lValue1000;
      set => lValue1000 = value;
    }

    public double SValue1 => SValue1000 / 1000d;
    public double LValue1 => LValue1000 / 1000d;

    [Description("Fired when SelectedMin or SelectedMax changes.")]
    public event EventHandler SelectionChanged;
    public event EventHandler ElementSelected;

    public void SelectElement()
    {
      if(ElementSelected != null)
        ElementSelected(this, null);
    }
  }
}