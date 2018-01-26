using System;
using System.Drawing;
using System.Linq;
using System.Threading;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace ArcEngine
{
    public class RenderSystem : BaseSystem
    {
        public static GameWindow Window { get; private set; }

        public string Title
        {
            get => Window?.Title ?? "Arc Engine";
            set => Window.Title = value;
        }

        public double TargetFramerate
        {
            get => Window.TargetUpdateFrequency;
            set => Window.TargetUpdateFrequency = Window.TargetRenderFrequency = value;
        }

        public Vector2 Size
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

        public int ShaderProgram;

        public RenderSystem()
        {
            Window = new GameWindow(this, Title);
            Window.MouseMove += Input.OnMouseMove;
        }

        internal override void Start()
        {
            Window.Run(TargetFramerate, TargetFramerate);
        }

        internal override void Update()
        {
            foreach (Camera camera in Camera.Cameras.OrderBy(c => c.Depth))
            {
                Matrix4 projection = camera.Transform.LookAtMatrix;

                switch (camera.PerspectiveMode)
                {
                    case PerspectiveMode.Perspective:
                        projection *= Matrix4.CreatePerspectiveFieldOfView(camera.FOVRadians, Window.Width / (float)Window.Height, camera.NearClipPlane, camera.FarClipPlane);
                        break;
                    case PerspectiveMode.Orthographic:
                        projection *= Matrix4.CreateOrthographic(camera.OrthographicSize * (Window.Width / (float)Window.Height), camera.OrthographicSize, camera.NearClipPlane, camera.FarClipPlane);
                        break;
                    default:
                        goto case PerspectiveMode.Perspective;
                }

                GL.ClearColor(camera.ClearColor);
                GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
                GL.Enable(EnableCap.DepthTest);

                GL.UseProgram(ShaderProgram);

                foreach (MeshRenderer renderer in GameObject.All.Select(go => go.GetComponent<MeshRenderer>()).Where(mr => mr != null))
                {
                    Matrix4 rendererMatrix = renderer.Transform.LookAtMatrix * projection;
                    GL.UniformMatrix4(20, false, ref rendererMatrix);
                    renderer.Draw();
                }
            }

            Window.SwapBuffers();
        }

        public void SetResolution(int width, int height)
        {
            Window.ClientSize = new Size(width, height);
        }
    }
}