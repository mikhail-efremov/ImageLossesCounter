using System.Drawing;

namespace MeshCollision.ColorSpaces
{
  public class RgbColorSpace : IColorSpace
  {
    public byte R {get {return color.R;}}
    public byte G {get {return color.G;}}
    public byte B { get { return color.B; } }

    private Color color;

    public RgbColorSpace()
    {
      color = new Color();
    }

    public RgbColorSpace(byte r, byte g, byte b)
    {
      color = Color.FromArgb(r, g, b);
    }

    public RgbColorSpace(Color color)
    {
      this.color = color;
    }

    public bool ColorSimilar(IColorSpace compareColorSpace, byte sens)
    {
      var rgb = compareColorSpace as RgbColorSpace;
      if (rgb == null)
        return false;

      if (sens >= 255)
        return true;

      if (R >= rgb.R - sens && R <= rgb.R + sens)
        if (G >= rgb.G - sens && G <= rgb.G + sens)
          if (B >= rgb.B - sens && B <= rgb.B + sens)
            return true;
      return false;
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