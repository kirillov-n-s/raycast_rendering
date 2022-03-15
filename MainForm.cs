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
    public partial class MainForm : Form
    {
        readonly List<Material> _knownMaterials = new List<Material>()
        {
            Material.Ruby,
            Material.Emerald,
            Material.Turquoise,
            Material.Jade,
            Material.Obsidian,
            Material.Pearl,
            Material.Brass,
            Material.Bronze,
            Material.Chrome,
            Material.Copper,
            Material.Gold,
            Material.Silver,
            Material.PlasticBlack,
            Material.PlasticCyan,
            Material.PlasticGreen,
            Material.PlasticRed,
            Material.PlasticWhite,
            Material.PlasticYellow,
            Material.RubberBlack,
            Material.RubberCyan,
            Material.RubberGreen,
            Material.RubberRed,
            Material.RubberWhite,
            Material.RubberYellow,
        };

        readonly Scene<Sphere> _scene;

        void SetMaterialNumericsEnabled(bool value)
        {
            NumericMaterialAmbientRed.Enabled = value;
            NumericMaterialAmbientGreen.Enabled = value;
            NumericMaterialAmbientBlue.Enabled = value;

            NumericMaterialDiffuseRed.Enabled = value;
            NumericMaterialDiffuseGreen.Enabled = value;
            NumericMaterialDiffuseBlue.Enabled = value;

            NumericMaterialSpecularRed.Enabled = value;
            NumericMaterialSpecularGreen.Enabled = value;
            NumericMaterialSpecularBlue.Enabled = value;

            NumericMaterialShininess.Enabled = value;
        }

        void UpdateMaterialNumerics()
        {
            NumericMaterialAmbientRed.Value = (decimal)_scene.Object.Material.Ambient.X;
            NumericMaterialAmbientGreen.Value = (decimal)_scene.Object.Material.Ambient.Y;
            NumericMaterialAmbientBlue.Value = (decimal)_scene.Object.Material.Ambient.Z;

            NumericMaterialDiffuseRed.Value = (decimal)_scene.Object.Material.Diffuse.X;
            NumericMaterialDiffuseGreen.Value = (decimal)_scene.Object.Material.Diffuse.Y;
            NumericMaterialDiffuseBlue.Value = (decimal)_scene.Object.Material.Diffuse.Z;

            NumericMaterialSpecularRed.Value = (decimal)_scene.Object.Material.Specular.X;
            NumericMaterialSpecularGreen.Value = (decimal)_scene.Object.Material.Specular.Y;
            NumericMaterialSpecularBlue.Value = (decimal)_scene.Object.Material.Specular.Z;

            NumericMaterialShininess.Value = (decimal)_scene.Object.Material.Shininess;
        }

        void UpdateCameraNumerics()
        {
            NumericCameraPositionX.Value = (decimal)_scene.Camera.Position.X;
            NumericCameraPositionY.Value = (decimal)_scene.Camera.Position.Y;
            NumericCameraPositionZ.Value = (decimal)_scene.Camera.Position.Z;

            NumericCameraDirectionX.Value = (decimal)_scene.Camera.Direction.X;
            NumericCameraDirectionY.Value = (decimal)_scene.Camera.Direction.Y;
            NumericCameraDirectionZ.Value = (decimal)_scene.Camera.Direction.Z;
        }

        void OnNumericChanged(ref float property, NumericUpDown numeric)
        {
            property = (float)numeric.Value;
            _scene.Render();
        }

        void OnMaterialNumericChanged(Func<Material, Material> func)
        {
            _scene.Object.Material = func(_scene.Object.Material);
            if (ComboKnownMaterials.SelectedIndex == 0)
                _scene.Render();
        }

        public MainForm()
        {
            InitializeComponent();

            var i = new Random().Next(1, _knownMaterials.Count + 1);

            _scene = new Scene<Sphere>
            (
                PictureScene,
                new Sphere
                (
                    Vector3.Zero,
                    1.0f,
                    _knownMaterials[i]
                ),
                new Camera
                (
                    new Vector3(0.0f, 0.0f, 2.0f),
                    new Vector3(0.0f, 0.0f, -1.0f)
                ),
                new AmbientLight(Color.White, 1.0f),
                new DirectionalLight(Color.White, 1.0f, new Vector3(1.0f, -1.0f, -1.0f)),
                new DirectionalLight(Color.White, 1.0f, new Vector3(-1.0f, 0.0f, -1.0f))
            );

            NumericSphereRadius.Value = (decimal)_scene.Object.Radius;

            UpdateMaterialNumerics();
            SetMaterialNumericsEnabled(false);
            ComboKnownMaterials.SelectedIndex = i;

            UpdateCameraNumerics();

            PictureAmbientColor.BackColor = _scene.AmbientLight.Color;
            NumericAmbientIntensity.Value = (decimal)_scene.AmbientLight.Intensity;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            _scene.Render();
        }

        private void ComboKnownMaterials_SelectedIndexChanged(object sender, EventArgs e)
        {
            var index = ComboKnownMaterials.SelectedIndex;
            if (index == 0)
            {
                SetMaterialNumericsEnabled(true);
                return;
            }

            SetMaterialNumericsEnabled(false);
            _scene.Object.Material = _knownMaterials[index - 1];
            UpdateMaterialNumerics();
            _scene.Render();
        }

        private void PIctureAmbientColor_Click(object sender, EventArgs e)
        {
            if (ColorPicker.ShowDialog() != DialogResult.OK)
                return;
            PictureAmbientColor.BackColor = _scene.AmbientLight.Color = ColorPicker.Color;
            _scene.Render();
        }

        private void NumericSphereRadius_ValueChanged(object sender, EventArgs e) => OnNumericChanged(ref _scene.Object.Radius, NumericSphereRadius);

        private void NumericCameraPositionX_ValueChanged(object sender, EventArgs e) => OnNumericChanged(ref _scene.Camera.Position.X, NumericCameraPositionX);
        private void NumericCameraPositionY_ValueChanged(object sender, EventArgs e) => OnNumericChanged(ref _scene.Camera.Position.Y, NumericCameraPositionY);
        private void NumericCameraPositionZ_ValueChanged(object sender, EventArgs e) => OnNumericChanged(ref _scene.Camera.Position.Z, NumericCameraPositionZ);

        private void NumericCameraDirectionX_ValueChanged(object sender, EventArgs e) => OnNumericChanged(ref _scene.Camera.Direction.X, NumericCameraDirectionX);
        private void NumericCameraDirectionY_ValueChanged(object sender, EventArgs e) => OnNumericChanged(ref _scene.Camera.Direction.Y, NumericCameraDirectionY);

        private void NumericMaterialAmbientRed_ValueChanged(object sender, EventArgs e) => OnMaterialNumericChanged(_ => { _.Ambient.X = (float)NumericMaterialAmbientRed.Value; return _; } );
        private void NumericMaterialAmbientGreen_ValueChanged(object sender, EventArgs e) => OnMaterialNumericChanged(_ => { _.Ambient.Y = (float)NumericMaterialAmbientGreen.Value; return _; });
        private void NumericMaterialAmbientBlue_ValueChanged(object sender, EventArgs e) => OnMaterialNumericChanged(_ => { _.Ambient.Z = (float)NumericMaterialAmbientBlue.Value; return _; });

        private void NumericMaterialDiffuseRed_ValueChanged(object sender, EventArgs e) => OnMaterialNumericChanged(_ => { _.Diffuse.X = (float)NumericMaterialDiffuseRed.Value; return _; });
        private void NumericMaterialDiffuseGreen_ValueChanged(object sender, EventArgs e) => OnMaterialNumericChanged(_ => { _.Diffuse.Y = (float)NumericMaterialDiffuseGreen.Value; return _; });
        private void NumericMaterialDiffuseBlue_ValueChanged(object sender, EventArgs e) => OnMaterialNumericChanged(_ => { _.Diffuse.Z = (float)NumericMaterialDiffuseBlue.Value; return _; });

        private void NumericMaterialSpecularRed_ValueChanged(object sender, EventArgs e) => OnMaterialNumericChanged(_ => { _.Specular.X = (float)NumericMaterialSpecularRed.Value; return _; });
        private void NumericMaterialSpecularGreen_ValueChanged(object sender, EventArgs e) => OnMaterialNumericChanged(_ => { _.Specular.Y = (float)NumericMaterialSpecularGreen.Value; return _; });
        private void NumericMaterialSpecularBlue_ValueChanged(object sender, EventArgs e) => OnMaterialNumericChanged(_ => { _.Specular.Z = (float)NumericMaterialSpecularBlue.Value; return _; });

        private void NumericMaterialShininess_ValueChanged(object sender, EventArgs e) => OnMaterialNumericChanged(_ => { _.Shininess = (float)NumericMaterialShininess.Value; return _; });

        private void NumericAmbientIntensity_ValueChanged(object sender, EventArgs e) => OnNumericChanged(ref _scene.AmbientLight.Intensity, NumericAmbientIntensity);
    }
}
