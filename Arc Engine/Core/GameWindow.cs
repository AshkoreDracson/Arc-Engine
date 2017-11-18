using System.Windows.Forms;

namespace ArcEngine.Core
{
    public class GameWindow : Form
    {
        public ViewportControl Viewport { get; }

        public GameWindow(string title)
        {
            Width = 1280;
            Height = 720;
            Text = title;

            Viewport = new ViewportControl { Dock = DockStyle.Fill };
            Controls.Add(Viewport);
        }
    }
}