using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace MeshCollision.Controlls
{
  public class SelectionRangeSlider : UserControl
  {
    private enum MovingMode
    {
      MovingMin, MovingMax
    }
    MovingMode _movingMode;

    public List<SelectionElement> Sliders = new List<SelectionElement>();
    public SelectionElement CurrentSelectionElement = null;

    public SelectionRangeSlider() {
      SetStyle(ControlStyles.AllPaintingInWmPaint, true);
      SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
      Paint += SelectionRangeSlider_Paint;
//      MouseDown
      MouseClick += SelectionRangeSlider_MouseDown;
      MouseMove += SelectionRangeSlider_MouseDown;
    }

    public void AddSelectionElement(SelectionElement element)
    {
      Sliders.Add(element);
      if (Sliders.Count == 1)
      {
        CurrentSelectionElement = element;
        element.SelectElement();
      }
    }

    void SelectionRangeSlider_Paint(object sender, PaintEventArgs e) {
      //paint background in white
      e.Graphics.FillRectangle(Brushes.White, ClientRectangle);
      if (Sliders.Count > 0)
        foreach (var slider in Sliders)
        {
          Rectangle selectionRect = new Rectangle(
          (slider.SelectedMin - slider.Min) * Width / (slider.Max - slider.Min),
          0,
          (slider.SelectedMax - slider.SelectedMin) * Width / (slider.Max - slider.Min),
          Height);
          e.Graphics.FillRectangle(new SolidBrush(slider.LinesColor), selectionRect);
        }
      //draw a black frame around our control
      e.Graphics.DrawRectangle(Pens.Black, 0, 0, Width - 1, Height - 1);

      if (CurrentSelectionElement == null)
        return;
      e.Graphics.DrawRectangle(Pens.Red, new Rectangle(
          (CurrentSelectionElement.SelectedMin - CurrentSelectionElement.Min)
          * Width / (CurrentSelectionElement.Max - CurrentSelectionElement.Min),
          0,
          (CurrentSelectionElement.SelectedMax - CurrentSelectionElement.SelectedMin)
          * Width / (CurrentSelectionElement.Max - CurrentSelectionElement.Min),
          Height));
    }

    void SelectionRangeSlider_MouseDown(object sender, MouseEventArgs e) {
      if (Sliders.Count < 1)
        return;

      var contMin = 360;
      SelectionElement selectionElement = null;

      foreach (var slider in Sliders)
      {
        var pointedValue = slider.Min + e.X * (slider.Max - slider.Min) / Width;
        var distMin = Math.Abs(pointedValue - slider.SelectedMin);
        var distMax = Math.Abs(pointedValue - slider.SelectedMax);
        var minDist = Math.Min(distMin, distMax);
        if (minDist < contMin)
        {
          contMin = minDist;
          selectionElement = slider;
        }
        else
        {
          continue;
        }

        _movingMode = minDist == distMin ? MovingMode.MovingMin : MovingMode.MovingMax;
      }
      if(e.Button == MouseButtons.Left)
        SelectionRangeSlider_LeftMouseMove(selectionElement, e);
      if (e.Button == MouseButtons.Right)
        SelectionRangeSlider_RightMouseMove(selectionElement, e);
    }

    private void SelectionRangeSlider_LeftMouseMove(object sender, MouseEventArgs e) {
      if (e.Button != MouseButtons.Left)
        return;
      var slider = (SelectionElement)sender;
      if (slider == null)
        return;

      var pointedValue = slider.Min + e.X * (slider.Max - slider.Min) / Width;

      switch (_movingMode)
      {
        case MovingMode.MovingMin:
          if (pointedValue <= slider.SelectedMax && CanDraw(pointedValue, slider))
            slider.SelectedMin = pointedValue;
          break;
        case MovingMode.MovingMax:
          if (pointedValue >= slider.SelectedMin && CanDraw(pointedValue, slider))
            slider.SelectedMax = pointedValue;
          break;
      }
      SelectElement((SelectionElement)sender);
    }

    private bool CanDraw(int pointedValue, SelectionElement selectionElement) {
      if (pointedValue < selectionElement.Min || pointedValue > selectionElement.Max)
        return false;
      return Sliders.Where(s => pointedValue >= s.SelectedMin && pointedValue <= s.SelectedMax)
        .All(s => s == selectionElement);
    }

    private void SelectionRangeSlider_RightMouseMove(object sender, MouseEventArgs e)
    {
      SelectElement((SelectionElement)sender);
    }

    private void SelectElement(SelectionElement element)
    {
      CurrentSelectionElement = element;
      CurrentSelectionElement.SelectElement();
      Invalidate();
    }
  }
}