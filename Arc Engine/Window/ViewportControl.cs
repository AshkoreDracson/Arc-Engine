using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
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

            GraphicContext gc = new GraphicContext(e.Graphics, Camera.instance);

            foreach (GlobalScript script in Engine.GlobalScripts)
            {
                script.Draw(gc);
            }
            foreach (GameObject go in GameObject.All)
            {
                foreach (Component comp in go.GetComponentsEnumerable().Where(comp => comp is Renderer || comp is Script))
                {
                    comp.Draw(gc);
                }
            }
        }
    }
}