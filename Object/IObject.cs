using System.Numerics;

namespace laba2.Object
{
    public interface IObject
    {
        Material Material { get; }

        float RayIntersection(Vector3 origin, Vector3 direction);
        Vector3 Normal(Vector3 point);
    }
}
