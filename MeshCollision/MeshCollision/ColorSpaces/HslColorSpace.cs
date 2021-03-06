﻿using System;
using System.Drawing;

namespace MeshCollision.ColorSpaces
{
  public class HslColorSpace : IColorSpace
  {
    public float H;
    public float S;
    public float L;

    public HslColorSpace(float h, float s, float l) {
      H = h;
      S = s;
      L = l;
    }

    public HslColorSpace() {
    }

    public override string ToString() {
      return string.Format("H:{0};S:{1};L:{2}", H, S, L);
    }

    //http://james-ramsden.com/convert-from-hsl-to-rgb-colour-codes-in-c/
    public static Color ColorFromHsl(double h, double s, double l)
    {
      double r = 0, g = 0, b = 0;

      if (l != 0)
      {
        if (s == 0)
          r = g = b = l;
        else
        {
          double k2;
          if (l < 0.5)
            k2 = l * (1.0 + s);
          else
            k2 = l + s - (l * s);

          double k1 = 2.0 * l - k2;

          r = GetColorComponent(k1, k2, h + 1.0 / 3.0);
          g = GetColorComponent(k1, k2, h);
          b = GetColorComponent(k1, k2, h - 1.0 / 3.0);
        }
      }
      return Color.FromArgb(Convert.ToInt32(255 * r), Convert.ToInt32(255 * g), Convert.ToInt32(255 * b));
    }

    private static double GetColorComponent(double k1, double k2, double k3)
    {
      if (k3 < 0.0)
        k3 += 1.0;
      else if (k3 > 1.0)
        k3 -= 1.0;

      if (k3 < 1.0 / 6.0)
        return k1 + (k2 - k1) * 6.0 * k3;
      if (k3 < 0.5)
        return k2;
      if (k3 < 2.0 / 3.0)
        return k1 + (k2 - k1) * (2.0 / 3.0 - k3) * 6.0;
      return k1;
    }

    public static HslColorSpace FromRGB(byte R, byte G, byte B)
    {
      var hsl = new HslColorSpace();

      float r = (R / 255.0f);
      float g = (G / 255.0f);
      float b = (B / 255.0f);

      float min = Math.Min(Math.Min(r, g), b);
      float max = Math.Max(Math.Max(r, g), b);
      float delta = max - min;

      hsl.L = (max + min) / 2;

      if (delta == 0)
      {
        hsl.H = 0;
        hsl.S = 0.0f;
      }
      else
      {
        hsl.S = (hsl.L <= 0.5) ? (delta / (max + min)) : (delta / (2 - max - min));

        float hue;

        if (r == max)
        {
          hue = ((g - b) / 6) / delta;
        }
        else if (g == max)
        {
          hue = (1.0f / 3) + ((b - r) / 6) / delta;
        }
        else
        {
          hue = (2.0f / 3) + ((r - g) / 6) / delta;
        }

        if (hue < 0)
          hue += 1;
        if (hue > 1)
          hue -= 1;

        hsl.H = (int) (hue * 360);
      }

      return hsl;
    }

    public bool ColorSimilar(IColorSpace compareColorSpace, byte sens)
    {
      var hsl = compareColorSpace as HslColorSpace;
      if (hsl == null)
        return false;

      if (sens >= 100)
        return true;

      var hsens = 50;
      var lsens = 0.6f;

      if (H >= hsl.H - hsens && H <= hsl.H + hsens)
        //       if (S >= shl.S - ssens && S <= hsl.S + ssens)
        if (L >= hsl.L - lsens && L <= hsl.L + lsens)
          return true;
      return false;
    }

    public bool ColorSimilar(Point point, UnsafeBitmap unsafeBitmap, byte sens)
    {
      throw new NotImplementedException();
    }

    public bool ColorSimilar(Point point, Bitmap bitmap, byte sens)
    {
      throw new NotImplementedException();
    }
  }
}