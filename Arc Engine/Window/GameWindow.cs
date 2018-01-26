using System;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;

namespace ArcEngine
{
    public class GameWindow : OpenTK.GameWindow
    {
        public RenderSystem LinkedRenderSystem { get; }

        public GameWindow(RenderSystem rs) : this(rs, "Arc Engine") { }
        public GameWindow(RenderSystem rs, string title) : base(640, 480, GraphicsMode.Default, title)
        {
            LinkedRenderSystem = rs;
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            LinkedRenderSystem.ShaderProgram = Shader.CreateProgram();

            CursorVisible = true;

            GL.PolygonMode(MaterialFace.FrontAndBack, PolygonMode.Line);
            GL.PatchParameter(PatchParameterInt.PatchVertices, 3);
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            GL.Viewport(ClientRectangle.X, ClientRectangle.Y, ClientRectangle.Width, ClientRectangle.Height);
        }

        protected override void OnClosed(EventArgs e)
        {
            GL.DeleteProgram(LinkedRenderSystem.ShaderProgram);
        }
    }
}