using System.Drawing;
using System.Windows.Forms;

namespace ArcEngine
{
    public class ViewportControl : Control
    {
        protected override void OnPaint(PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(Color.Black);
        }
    }
}