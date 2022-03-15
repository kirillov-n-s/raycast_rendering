using System;
using System.Numerics;

namespace laba2.Object
{
    public struct Material
    {
        public Vector3 Ambient;
        public Vector3 Diffuse;
        public Vector3 Specular;
        public float Shininess;

        public Material(Vector3 ambient, Vector3 diffuse, Vector3 specular, float shininess)
        {
            Ambient = ambient;
            Diffuse = diffuse;
            Specular = specular;
            Shininess = shininess;
        }

        public static Material Emerald => new Material
        (
            new Vector3(0.0215f, 0.1745f, 0.0215f),
            new Vector3(0.07568f, 0.61424f, 0.07568f),
            new Vector3(0.633f, 0.727811f, 0.633f),
            (float)Math.Round(128.0f * 0.6f)
        );

        public static Material Jade => new Material
        (
            new Vector3(0.135f, 0.2225f, 0.1575f),
            new Vector3(0.54f, 0.89f, 0.63f),
            new Vector3(0.316228f, 0.316228f, 0.316228f),
            (float)Math.Round(128.0f * 0.1f)
        );

        public static Material Obsidian => new Material
        (
            new Vector3(0.05375f, 0.05f, 0.06625f),
            new Vector3(0.18275f, 0.17f, 0.22525f),
            new Vector3(0.332741f, 0.328634f, 0.346435f),
            (float)Math.Round(128.0f * 0.3f)
        );

        public static Material Pearl => new Material
        (
            new Vector3(0.25f, 0.20725f, 0.20725f),
            new Vector3(1f, 0.829f, 0.829f),
            new Vector3(0.296648f, 0.296648f, 0.296648f),
            (float)Math.Round(128.0f * 0.088f)
        );

        public static Material Ruby => new Material
        (
            new Vector3(0.1745f, 0.01175f, 0.01175f),
            new Vector3(0.61424f, 0.04136f, 0.04136f),
            new Vector3(0.727811f, 0.626959f, 0.626959f),
            (float)Math.Round(128.0f * 0.6f)
        );

        public static Material Turquoise => new Material
        (
            new Vector3(0.1f, 0.18725f, 0.1745f),
            new Vector3(0.396f, 0.74151f, 0.69102f),
            new Vector3(0.297254f, 0.30829f, 0.306678f),
            (float)Math.Round(128.0f * 0.1f)
        );

        public static Material Brass => new Material
        (
            new Vector3(0.329412f, 0.223529f, 0.027451f),
            new Vector3(0.780392f, 0.568627f, 0.113725f),
            new Vector3(0.992157f, 0.941176f, 0.807843f),
            (float)Math.Round(128.0f * 0.21794872f)
        );

        public static Material Bronze => new Material
        (
            new Vector3(0.2125f, 0.1275f, 0.054f),
            new Vector3(0.714f, 0.4284f, 0.18144f),
            new Vector3(0.393548f, 0.271906f, 0.166721f),
            (float)Math.Round(128.0f * 0.2f)
        );

        public static Material Chrome => new Material
        (
            new Vector3(0.25f),
            new Vector3(0.4f),
            new Vector3(0.774597f),
            (float)Math.Round(128.0f * 0.6f)
        );

        public static Material Copper => new Material
        (
            new Vector3(0.19125f, 0.0735f, 0.0225f),
            new Vector3(0.7038f, 0.27048f, 0.0828f),
            new Vector3(0.256777f, 0.137622f, 0.086014f),
            (float)Math.Round(128.0f * 0.1f)
        );

        public static Material Gold => new Material
        (
            new Vector3(0.24725f, 0.1995f, 0.0745f),
            new Vector3(0.75164f, 0.60648f, 0.22648f),
            new Vector3(0.628281f, 0.555802f, 0.366065f),
            (float)Math.Round(128.0f * 0.4f)
        );

        public static Material Silver => new Material
        (
            new Vector3(0.19225f),
            new Vector3(0.50754f),
            new Vector3(0.508273f),
            (float)Math.Round(128.0f * 0.4f)
        );

        public static Material PlasticBlack => new Material
        (
            new Vector3(0.0f),
            new Vector3(0.01f),
            new Vector3(0.5f),
            (float)Math.Round(128.0f * 0.25f)
        );

        public static Material PlasticCyan => new Material
        (
            new Vector3(0.0f, 0.1f, 0.06f),
            new Vector3(0.0f, 0.50980392f, 0.50980392f),
            new Vector3(0.50196078f),
            (float)Math.Round(128.0f * 0.25f)
        );

        public static Material PlasticGreen => new Material
        (
            new Vector3(0.0f),
            new Vector3(0.1f, 0.35f, 0.1f),
            new Vector3(0.45f, 0.55f, 0.45f),
            (float)Math.Round(128.0f * 0.25f)
        );

        public static Material PlasticRed => new Material
        (
            new Vector3(0.0f),
            new Vector3(0.5f, 0.0f, 0.0f),
            new Vector3(0.7f, 0.6f, 0.6f),
            (float)Math.Round(128.0f * 0.25f)
        );

        public static Material PlasticWhite => new Material
        (
            new Vector3(0.0f),
            new Vector3(0.55f),
            new Vector3(0.7f),
            (float)Math.Round(128.0f * 0.25f)
        );

        public static Material PlasticYellow => new Material
        (
            new Vector3(0.0f),
            new Vector3(0.5f, 0.5f, 0.0f),
            new Vector3(0.6f, 0.6f, 0.5f),
            (float)Math.Round(128.0f * 0.25f)
        );

        public static Material RubberBlack => new Material
        (
            new Vector3(0.02f),
            new Vector3(0.01f),
            new Vector3(0.4f),
            (float)Math.Round(128.0f * 0.078125f)
        );

        public static Material RubberCyan => new Material
        (
            new Vector3(0.0f, 0.05f, 0.05f),
            new Vector3(0.4f, 0.5f, 0.5f),
            new Vector3(0.04f, 0.7f, 0.7f),
            (float)Math.Round(128.0f * 0.078125f)
        );

        public static Material RubberGreen => new Material
        (
            new Vector3(0.0f, 0.05f, 0.0f),
            new Vector3(0.4f, 0.5f, 0.4f),
            new Vector3(0.04f, 0.7f, 0.04f),
            (float)Math.Round(128.0f * 0.078125f)
        );

        public static Material RubberRed => new Material
        (
            new Vector3(0.05f, 0.0f, 0.0f),
            new Vector3(0.5f, 0.4f, 0.4f),
            new Vector3(0.7f, 0.04f, 0.04f),
            (float)Math.Round(128.0f * 0.078125f)
        );

        public static Material RubberWhite => new Material
        (
            new Vector3(0.05f),
            new Vector3(0.5f),
            new Vector3(0.7f),
            (float)Math.Round(128.0f * 0.078125f)
        );

        public static Material RubberYellow => new Material
        (
            new Vector3(0.05f, 0.05f, 0.0f),
            new Vector3(0.5f, 0.5f, 0.4f),
            new Vector3(0.7f, 0.7f, 0.04f),
            (float)Math.Round(128.0f * 0.078125f)
        );
    }
}
