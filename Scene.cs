using laba2.Conversion;
using laba2.Lighting;
using laba2.Object;
using laba2.View;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Numerics;
using System.Windows.Forms;

namespace laba2
{
    public class Scene<TObject>
        where TObject : IObject
    {
        readonly PictureBox _picturebox;

        Color _backcolor = Color.Black;
        Color _forecolor = Color.Gray;

        Color Pixel(int x, int y)
        {
            var target = new Vector2(2.0f * x - _picturebox.Width, 2.0f * y - _picturebox.Height) / Math.Min(_picturebox.Width, _picturebox.Height);
            var rayDirection = Vector3.Normalize(target.X * Camera.Right + target.Y * Camera.Up + Camera.Direction);

            var t = Object.RayIntersection(Camera.Position, rayDirection);
            if (t < 0.0f)
                return
                    x == _picturebox.Width / 2 || y == _picturebox.Height / 2
                    ? _forecolor
                    : _backcolor;
            var normal = Object.Normal(Camera.Position + rayDirection * t);

            var material = Object.Material;

            var ambient = AmbientLight.Color.ToVector() * AmbientLight.Intensity * material.Ambient;
            var diffuse = Vector3.Zero;
            var specular = Vector3.Zero;
            foreach (var light in DirectionalLights)
            {
                var negLightDir = -Vector3.Normalize(light.Direction);
                var colorIntensity = light.Color.ToVector() * light.Intensity;
                var dotDiffuse = Math.Max(Vector3.Dot(normal, negLightDir), 0.0f);
                var reflect = Vector3.Normalize(Vector3.Reflect(negLightDir, normal));
                var dotSpecular = Math.Max(Vector3.Dot(reflect, rayDirection), 0.0f);
                diffuse += colorIntensity * material.Diffuse * dotDiffuse;
                specular += colorIntensity * material.Specular * (float)Math.Pow(dotSpecular, material.Shininess);
            }

            return Vector3.Clamp(ambient + diffuse + specular, Vector3.Zero, Vector3.One).ToColor();
        }

        public readonly TObject Object;
        public readonly Camera Camera;
        public readonly AmbientLight AmbientLight;
        public readonly List<DirectionalLight> DirectionalLights = new List<DirectionalLight>();

        public Scene(PictureBox picturebox, TObject @object, Camera camera, AmbientLight ambientLight, params DirectionalLight[] directionalLights)
        {
            _picturebox = picturebox;
            Object = @object;
            Camera = camera;
            AmbientLight = ambientLight;
            DirectionalLights.AddRange(directionalLights);
        }

        public void Render()
        {
            if (_picturebox.Image != null)
                _picturebox.Image.Dispose();
            var bitmap = new Bitmap(_picturebox.Width, _picturebox.Height);
            var bitmapProcessor = new BitmapProcessor(bitmap);
            bitmapProcessor.Process(Pixel);
            _picturebox.Image = bitmap;
            _picturebox.Refresh();
        }
    }
}
