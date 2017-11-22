using System.Drawing;

namespace ArcEngine
{
    public class GraphicContext
    {
        public Graphics Graphics { get; }

        public GraphicContext(Graphics g)
        {
            Graphics = g;
        }
    }
}