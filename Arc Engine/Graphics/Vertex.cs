namespace ArcEngine
{
    public struct Vertex
    {
        public const int Size = (4 + 4) * 4; // size of struct in bytes

        private readonly Vector4 _position;
        private readonly Color _color;

        public Vector4 Position => _position;
        public Color Color => _color;

        public Vertex(Vector4 position, Color color)
        {
            _position = position;
            _color = color;
        }
    }
}