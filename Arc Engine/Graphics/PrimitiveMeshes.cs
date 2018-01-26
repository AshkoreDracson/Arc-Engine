using OpenTK.Graphics;

namespace ArcEngine
{
    public static class PrimitiveMeshes
    {
        private static Mesh _cube;
        public static Mesh Cube => _cube ?? (_cube = new Mesh(new[]
        {
            new Vertex(new Vector4(-0.5f, -0.5f, -0.5f, 1.0f),   Color4.White),
            new Vertex(new Vector4(-0.5f, -0.5f, 0.5f, 1.0f),    Color4.White),
            new Vertex(new Vector4(-0.5f, 0.5f, -0.5f, 1.0f),    Color4.White),
            new Vertex(new Vector4(-0.5f, 0.5f, -0.5f, 1.0f),    Color4.White),
            new Vertex(new Vector4(-0.5f, -0.5f, 0.5f, 1.0f),    Color4.White),
            new Vertex(new Vector4(-0.5f, 0.5f, 0.5f, 1.0f),     Color4.White),
            
            new Vertex(new Vector4(0.5f, -0.5f, -0.5f, 1.0f),    Color4.White),
            new Vertex(new Vector4(0.5f, 0.5f, -0.5f, 1.0f),     Color4.White),
            new Vertex(new Vector4(0.5f, -0.5f, 0.5f, 1.0f),     Color4.White),
            new Vertex(new Vector4(0.5f, -0.5f, 0.5f, 1.0f),     Color4.White),
            new Vertex(new Vector4(0.5f, 0.5f, -0.5f, 1.0f),     Color4.White),
            new Vertex(new Vector4(0.5f, 0.5f, 0.5f, 1.0f),      Color4.White),
            
            new Vertex(new Vector4(-0.5f, -0.5f, -0.5f, 1.0f),   Color4.White),
            new Vertex(new Vector4(0.5f, -0.5f, -0.5f, 1.0f),    Color4.White),
            new Vertex(new Vector4(-0.5f, -0.5f, 0.5f, 1.0f),    Color4.White),
            new Vertex(new Vector4(-0.5f, -0.5f, 0.5f, 1.0f),    Color4.White),
            new Vertex(new Vector4(0.5f, -0.5f, -0.5f, 1.0f),    Color4.White),
            new Vertex(new Vector4(0.5f, -0.5f, 0.5f, 1.0f),     Color4.White),
            
            new Vertex(new Vector4(-0.5f, 0.5f, -0.5f, 1.0f),    Color4.White),
            new Vertex(new Vector4(-0.5f, 0.5f, 0.5f, 1.0f),     Color4.White),
            new Vertex(new Vector4(0.5f, 0.5f, -0.5f, 1.0f),     Color4.White),
            new Vertex(new Vector4(0.5f, 0.5f, -0.5f, 1.0f),     Color4.White),
            new Vertex(new Vector4(-0.5f, 0.5f, 0.5f, 1.0f),     Color4.White),
            new Vertex(new Vector4(0.5f, 0.5f, 0.5f, 1.0f),      Color4.White),
            
            new Vertex(new Vector4(-0.5f, -0.5f, -0.5f, 1.0f),   Color4.White),
            new Vertex(new Vector4(-0.5f, 0.5f, -0.5f, 1.0f),    Color4.White),
            new Vertex(new Vector4(0.5f, -0.5f, -0.5f, 1.0f),    Color4.White),
            new Vertex(new Vector4(0.5f, -0.5f, -0.5f, 1.0f),    Color4.White),
            new Vertex(new Vector4(-0.5f, 0.5f, -0.5f, 1.0f),    Color4.White),
            new Vertex(new Vector4(0.5f, 0.5f, -0.5f, 1.0f),     Color4.White),
            
            new Vertex(new Vector4(-0.5f, -0.5f, 0.5f, 1.0f),    Color4.White),
            new Vertex(new Vector4(0.5f, -0.5f, 0.5f, 1.0f),     Color4.White),
            new Vertex(new Vector4(-0.5f, 0.5f, 0.5f, 1.0f),     Color4.White),
            new Vertex(new Vector4(-0.5f, 0.5f, 0.5f, 1.0f),     Color4.White),
            new Vertex(new Vector4(0.5f, -0.5f, 0.5f, 1.0f),     Color4.White),
            new Vertex(new Vector4(0.5f, 0.5f, 0.5f, 1.0f),      Color4.White)
        }));
    }
}