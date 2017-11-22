namespace ArcEngine
{
    public class Camera : Component
    {
        public static Camera instance { get; private set; }

        public float FOV { get; set; } = 90f;
        public float OrthographicSize { get; set; } = 5f;
        public PerspectiveMode PerspectiveMode { get; set; }

        public Camera()
        {
            instance = this;
        }
    }

    public enum PerspectiveMode : byte
    {
        Perspective,
        Orthographic
    }
}