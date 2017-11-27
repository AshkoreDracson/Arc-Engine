using System.Drawing;

namespace ArcEngine
{
    public static class GUI
    {
        private static Font _defaultFont;
        private static Font DefaultFont => _defaultFont ?? (_defaultFont = new Font(FontFamily.GenericMonospace, 10));

        private static SolidBrush _defaultBrush;
        private static SolidBrush DefaultBrush => _defaultBrush ?? (_defaultBrush = new SolidBrush(Color.White));

        public static void Text(string text, Vector2 position)
        {
            Engine.GUISystem.EnqueueCommand(gc =>
            {
                gc.Graphics.DrawString(text, DefaultFont, DefaultBrush, (PointF)position);
            });
        }
        public static void Text(string text, Vector2 position, Font font)
        {
            Engine.GUISystem.EnqueueCommand(gc =>
            {
                gc.Graphics.DrawString(text, font, DefaultBrush, (PointF)position);
            });
        }
        public static void Text(string text, Vector2 position, Brush brush)
        {
            Engine.GUISystem.EnqueueCommand(gc =>
            {
                gc.Graphics.DrawString(text, DefaultFont, brush, (PointF)position);
            });
        }
        public static void Text(string text, Vector2 position, Font font, Brush brush)
        {
            Engine.GUISystem.EnqueueCommand(gc =>
            {
                gc.Graphics.DrawString(text, font, brush, (PointF)position);
            });
        }
    }
}