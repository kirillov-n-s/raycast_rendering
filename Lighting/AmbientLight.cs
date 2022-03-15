using System.Drawing;

namespace laba2.Lighting
{
    public class AmbientLight
    {
        public Color Color;
        public float Intensity;

        public AmbientLight(Color color, float intensity)
        {
            Color = color;
            Intensity = intensity;
        }
    }
}
