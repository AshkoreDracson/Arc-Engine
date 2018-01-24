using System.Drawing;
using System.Threading;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace ArcEngine
{
    public class RenderSystem : BaseSystem
    {
        public static GameWindow Window { get; private set; }

        public static string Title
        {
            get => Window?.Title ?? "Arc Engine";
            set => Window.Title = value;
        }

        public static double TargetFramerate
        {
            get => Window.TargetUpdateFrequency;
            set => Window.TargetUpdateFrequency = Window.TargetRenderFrequency = value;
        }

        public static Vector2 Size
        {
            get => (Vector2)Window.Size;
            set => Window.Size = (Size)value;
        }

        public WindowState WindowState
        {
            get => Window.WindowState;
            set => Window.WindowState = value;
        }
        public VSyncMode VSync
        {
            get => Window.VSync;
            set => Window.VSync = value;
        }

        public RenderSystem()
        {
            Window = new GameWindow(Title);
        }

        internal override void Start()
        {
            Window.Run(1, 1);

            GL.ClearColor(0.1f, 0.2f, 0.5f, 0.0f);
            GL.Enable(EnableCap.DepthTest);
        }

        internal override void Update()
        {
            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            Matrix4 modelview = Matrix4.LookAt(Vector3.zero, Vector3.forward, Vector3.up);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref modelview);

            GL.Begin(PrimitiveType.Triangles);

            GL.Color3(1.0f, 1.0f, 0.0f); GL.Vertex3(-1.0f, -1.0f, 4.0f);
            GL.Color3(1.0f, 0.0f, 0.0f); GL.Vertex3(1.0f, -1.0f, 4.0f);
            GL.Color3(0.2f, 0.9f, 1.0f); GL.Vertex3(0.0f, 1.0f, 4.0f);

            GL.End();

            Window.SwapBuffers();
        }

        public void SetResolution(int width, int height)
        {
            Window.ClientSize = new Size(width, height);
        }
    }
}