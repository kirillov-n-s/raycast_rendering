using System.Drawing;
using System.Numerics;

namespace laba2.Conversion
{
    public static class VectorConversion
    {
        public static Color ToColor(this Vector3 vector)
        {
            return Color.FromArgb(255, (int)(vector.X * 255), (int)(vector.Y * 255), (int)(vector.Z * 255));
        }
    }
}
