using System.Drawing;

namespace ArcEngine
{
    public class RenderSystem : BaseSystem
    {
        public static GameWindow Window { get; private set; }

        internal override void Start()
        {
            Window = new GameWindow("Arc Engine");
            Window.Show();
        }

        internal override void Update()
        {
            if (Window.Visible)
                Window.Controls[0]?.Refresh();
        }

        public void SetResolution(int width, int height)
        {
            Window.ClientSize = new Size(width, height);
        }
    }
}