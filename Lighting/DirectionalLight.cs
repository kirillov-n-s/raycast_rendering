using System.Drawing;
using System.Numerics;

namespace laba2.Lighting
{
    public class DirectionalLight
    {
        public Color Color;
        public float Intensity;
        public Vector3 Direction;

        public DirectionalLight(Color color, float intensity, Vector3 direction)
        {
            Color = color;
            Intensity = intensity;
            Direction = direction;
        }
    }
}
