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
            Window.Controls[0].Refresh();
        }
    }
}