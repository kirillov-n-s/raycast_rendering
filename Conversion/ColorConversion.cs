using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace laba2.Conversion
{
    public static class ColorConversion
    {
        public static Vector3 ToVector(this Color color)
        {
            return new Vector3(color.R, color.G, color.B) / 255.0f;
        }
    }
}
