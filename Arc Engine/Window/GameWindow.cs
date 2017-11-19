using System.Windows.Forms;

namespace ArcEngine
{
    public class GameWindow : Form
    {
        public ViewportControl Viewport { get; }

        public GameWindow(string title)
        {
            Width = 1280;
            Height = 720;
            Text = title;

            FormBorderStyle = FormBorderStyle.FixedSingle;
            MinimizeBox = false;
            MaximizeBox = false;
            StartPosition = FormStartPosition.CenterScreen;

            Viewport = new ViewportControl { Dock = DockStyle.Fill };
            Controls.Add(Viewport);
        }
    }
}