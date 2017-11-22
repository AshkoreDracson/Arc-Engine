namespace ArcEngine
{
    public class Camera : Component
    {
        public float FOV { get; set; } = 90f;
        public float OrthographicSize { get; set; } = 5f;
        public PerspectiveMode PerspectiveMode { get; set; }
    }

    public enum PerspectiveMode : byte
    {
        Perspective,
        Orthographic
    }
}