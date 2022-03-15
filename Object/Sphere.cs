using System;
using System.Numerics;

namespace laba2.Object
{
    public class Sphere : IObject
    {
        public Vector3 Center;
        public float Radius;

        public Material Material { get; set; }

        public Sphere(Vector3 center, float radius, Material material)
        {
            Center = center;
            Radius = radius;
            Material = material;
        }

        public Vector3 Normal(Vector3 point)
        {
            return Vector3.Normalize(point - Center);
        }

        public float RayIntersection(Vector3 origin, Vector3 direction)
        {
            var vec = Center - origin;
            var proj = Vector3.Dot(vec, direction);
            if (proj < 0.0f)
                return -1.0f;
            var diff = Radius * Radius - (Vector3.Dot(vec, vec) - proj * proj);
            return diff < 0.0f ? -1.0f : proj - (float)Math.Sqrt(diff);
        }
    }
}
