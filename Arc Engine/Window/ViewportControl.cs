using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace ArcEngine
{
    public class ViewportControl : Control
    {
        public ViewportControl()
        {
            SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.UserPaint, true);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(System.Drawing.Color.Black);

            g.SmoothingMode = GraphicsSettings.AntiAliasing ? SmoothingMode.AntiAlias : SmoothingMode.None;
        }
    }
}