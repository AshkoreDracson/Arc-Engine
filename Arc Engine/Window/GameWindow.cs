using System;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace ArcEngine
{
    public class GameWindow : OpenTK.GameWindow
    {
        public GameWindow() : this("Arc Engine") { }
        public GameWindow(string title)
        {
            Title = title;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);

            GL.Viewport(ClientRectangle.X, ClientRectangle.Y, ClientRectangle.Width, ClientRectangle.Height);

            Matrix4 projection = Matrix4.CreatePerspectiveFieldOfView((float)Math.PI / 4, Width / (float)Height, 1.0f, 64.0f);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref projection);
        }
    }
}