using System.Drawing;

namespace ArcEngine
{
    public class GraphicContext
    {
        public Camera Camera { get; }
        public Graphics Graphics { get; }


        public GraphicContext(Graphics g, Camera c)
        {
            Camera = c;
            Graphics = g;
        }
    }
}