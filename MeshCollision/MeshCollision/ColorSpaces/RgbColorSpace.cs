using System.Drawing;
using MeshCollision.Calculations;

namespace MeshCollision.ColorSpaces
{
  public class RgbColorSpace : IColorSpace
  {
    public byte R => _color.R;
    public byte G => _color.G;
    public byte B => _color.B;

    private Color _color;

    public RgbColorSpace()
    {
      _color = new Color();
    }

    public RgbColorSpace(byte r, byte g, byte b)
    {
      _color = Color.FromArgb(r, g, b);
    }

    public RgbColorSpace(Color color)
    {
      this._color = color;
    }

    public bool ColorSimilar(IColorSpace compareColorSpace, byte sens)
    {
      if (!(compareColorSpace is RgbColorSpace rgb))
        return false;

      if (sens >= 255)
        return true;

      if (R >= rgb.R - sens && R <= rgb.R + sens)
        if (G >= rgb.G - sens && G <= rgb.G + sens)
          if (B >= rgb.B - sens && B <= rgb.B + sens)
            return true;
      return false;
    }

    public bool ColorSimilar(RgbColorSpace rgb, byte sens)
    {
      if (sens >= 255)
        return true;

      if (R >= rgb.R - sens && R <= rgb.R + sens)
        if (G >= rgb.G - sens && G <= rgb.G + sens)
          if (B >= rgb.B - sens && B <= rgb.B + sens)
            return true;
      return false;
    }

    public bool ColorSimilar(Point point, Bitmap bitmap, byte sens)
    {
      var cs = new RgbColorSpace(bitmap.GetPixel(point.X, point.Y));
      return ColorSimilar(cs, sens);
    }

    public bool ColorSimilar(Point point, UnsafeBitmap unsafeBitmap, byte sens) {
      var cs = new RgbColorSpace(unsafeBitmap.GetPixel(point.X, point.Y));
      return ColorSimilar(cs, sens);
    }

    public IColorSpace GetFromPoint(Point point, UnsafeBitmap unsafeBitmap)
    {
      return new RgbColorSpace(unsafeBitmap.GetPixel(point.X, point.Y));
    }
  }
}