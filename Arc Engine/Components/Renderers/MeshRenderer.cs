namespace ArcEngine
{
    public class MeshRenderer : Renderer
    {
        public Mesh Mesh { get; set; }

        internal override void Draw()
        {
            Mesh.Draw();
        }
    }
}