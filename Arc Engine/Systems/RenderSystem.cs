namespace ArcEngine
{
    public class RenderSystem : BaseSystem
    {
        public static GameWindow Window { get; private set; }

        public override void Start()
        {
            Window = new GameWindow("Arc Engine");
            Window.Show();
        }

        public override void Update()
        {
            if (Window.Visible)
                Window.Controls[0]?.Refresh();
        }

        public void SetResolution(int width, int height)
        {
            Window.Width = width;
            Window.Height = height;
        }
    }
}