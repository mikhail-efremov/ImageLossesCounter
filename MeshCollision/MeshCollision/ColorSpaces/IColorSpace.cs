using System.Drawing;

namespace MeshCollision.ColorSpaces
{
  public interface IColorSpace
  {
    bool ColorSimilar(IColorSpace compareColorSpace, byte sens);
    bool ColorSimilar(Point point, UnsafeBitmap unsafeBitmap, byte sens);
  }
}