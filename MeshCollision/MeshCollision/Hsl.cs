using System.Drawing;

namespace MeshCollision
{
  public class Hsl
  {
    public static Color ColorFromHsl(double h, double s, double l) {
      double r = 0, g = 0, b = 0;
      //dirty

      if (l > .8)
        l = .8;
      if (l < .2)
        l = .2;

      if (h < 0)
        return Color.White;
      if (h > 1)
        return Color.Black;

      //dirty

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
  }
}