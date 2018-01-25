using System.Collections.Generic;

namespace ArcEngine
{
    public class Camera : Component
    {
        public static List<Camera> Cameras { get; } = new List<Camera>();

        public Color ClearColor { get; set; } = Color.Black;
        public int Depth { get; set; } = 0;
        public float FOV { get; set; } = 60f;
        public float OrthographicSize { get; set; } = 5f;
        public PerspectiveMode PerspectiveMode { get; set; } = PerspectiveMode.Perspective;

        public float NearClipPlane { get; set; } = 0.3f;
        public float FarClipPlane { get; set; } = 1000f;

        public float FOVRadians => FOV.Remap(0f, 180f, 0f, (float)Mathf.Pi).ClampMax(179.99f);

        public Camera()
        {
            Cameras.Add(this);
        }
        ~Camera()
        {
            Cameras.Remove(this);
        }
    }

    public enum PerspectiveMode : byte
    {
        Perspective,
        Orthographic
    }
}