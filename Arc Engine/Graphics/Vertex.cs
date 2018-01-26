using System;
using System.Runtime.InteropServices;
using OpenTK.Graphics;

namespace ArcEngine
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct Vertex
    {
        private readonly OpenTK.Vector4 _position;
        private readonly Color4 _color;

        public OpenTK.Vector4 Position => _position;
        public Color4 Color => _color;

        public const int Size = (4 + 4) * 4; // size of struct in bytes

        public Vertex(Vector4 position, Color4 color)
        {
            _position = position;
            _color = color;
        }
    }
}