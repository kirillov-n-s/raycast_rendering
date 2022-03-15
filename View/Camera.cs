using System.Numerics;

namespace laba2.View
{
    public class Camera
    {
        public Vector3 Position;
        public Vector3 Direction;

        public Camera(Vector3 position, Vector3 direction)
        {
            Position = position;
            Direction = direction;
        }

        public Vector3 Right => Vector3.Normalize(new Vector3(-Direction.Z, 0.0f, Direction.X));
        public Vector3 Up => Vector3.Normalize(Vector3.Cross(Direction, Right));
    }
}
