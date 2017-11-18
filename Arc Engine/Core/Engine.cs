using System.Windows.Forms;

namespace ArcEngine.Core
{
    public static class Engine
    {
        public static GameWindow Window { get; private set; }

        public static void Run()
        {
            Window = new GameWindow("ArcEngine");
            Application.Run(Window);
        }
    }
}