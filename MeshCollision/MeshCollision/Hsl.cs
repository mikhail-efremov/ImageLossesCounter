using System;
using System.Drawing;

namespace MeshCollision
{
  public class Hsl
  {
    public static Color ColorFromHsl(double h, double s, double l) {
      double r = 0, g = 0, b = 0;

      if (l != 0) {
        if (s == 0)
          r = g = b = l;
        else {
          double temp2;
          if (l < 0.5)
            temp2 = l * (1.0 + s);
          else
            temp2 = l + s - (l * s);

          double temp1 = 2.0 * l - temp2;

          r = GetColorComponent(temp1, temp2, h + 1.0 / 3.0);
          g = GetColorComponent(temp1, temp2, h);
          b = GetColorComponent(temp1, temp2, h - 1.0 / 3.0);
        }
      }
      return Color.FromArgb((int)(255 * r), (int)(255 * g), (int)(255 * b));
    }

    private static double GetColorComponent(double temp1, double temp2, double temp3) {
      if (temp3 < 0.0)
        temp3 += 1.0;
      else if (temp3 > 1.0)
        temp3 -= 1.0;

      if (temp3 < 1.0 / 6.0)
        return temp1 + (temp2 - temp1) * 6.0 * temp3;
      if (temp3 < 0.5)
        return temp2;
      if (temp3 < 2.0 / 3.0)
        return temp1 + (temp2 - temp1) * (2.0 / 3.0 - temp3) * 6.0;
      return temp1;
    }

    public static HslColor FromRGB(Byte R, Byte G, Byte B) {
      HslColor hsl = new HslColor();

      float r = (R / 255.0f);
      float g = (G / 255.0f);
      float b = (B / 255.0f);

      float min = Math.Min(Math.Min(r, g), b);
      float max = Math.Max(Math.Max(r, g), b);
      float delta = max - min;

      hsl.L = (max + min) / 2;

      if (delta == 0) {
        hsl.H = 0;
        hsl.S = 0.0f;
      }
      else {
        hsl.S = (hsl.L <= 0.5) ? (delta / (max + min)) : (delta / (2 - max - min));

        float hue;

        if (r == max) {
          hue = ((g - b) / 6) / delta;
        }
        else if (g == max) {
          hue = (1.0f / 3) + ((b - r) / 6) / delta;
        }
        else {
          hue = (2.0f / 3) + ((r - g) / 6) / delta;
        }

        if (hue < 0)
          hue += 1;
        if (hue > 1)
          hue -= 1;

        hsl.H = (int)(hue * 360);
      }

      return hsl;
    }
  }

  public class HslColor
  {
    public float H;
    public float S;
    public float L;

    public HslColor(float h, float s, float l) {
      H = h;
      S = s;
      L = l;
    }

    public HslColor()
    {
    }

    public override string ToString()
    {
      return $"H:{H};S:{S};L:{L}";
    }
  }
}