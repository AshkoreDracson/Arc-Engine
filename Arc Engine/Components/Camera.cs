namespace ArcEngine
{
    public class Camera : Component
    {
        public static Camera Instance { get; private set; }

        public Color ClearColor { get; set; } = Color.Black;
        public float FOV { get; set; } = 90f;
        public float OrthographicSize { get; set; } = 5f;
        public PerspectiveMode PerspectiveMode { get; set; }

        public Camera()
        {
            Instance = this;
        }
    }

    public enum PerspectiveMode : byte
    {
        Perspective,
        Orthographic
    }
}