using System.Drawing;

namespace ArcEngine
{
    public class TextRenderer : Renderer
    {
        private Color _color = Color.White;

        public Color Color
        {
            get => _color;
            set
            {
                _color = value;
                _brush = new SolidBrush(value);
            }
        }
        public Font Font { get; set; } = new Font(FontFamily.GenericMonospace, 9f);
        public string Text { get; set; }



        private SolidBrush _brush;

        public TextRenderer()
        {
            _brush = new SolidBrush(Color);
        }

        internal override void Draw(GraphicContext gc)
        {
            gc.Graphics.DrawString(Text, Font, _brush, GameObject.Transform.LocalPosition.x, GameObject.Transform.LocalPosition.y);
        }
    }
}