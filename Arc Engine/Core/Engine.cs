using System.Threading;
using System.Windows.Forms;

namespace ArcEngine
{
    public static class Engine
    {
        public static int TargetFramerate { get; set; } = 60;

        private static bool RequestQuit { get; set; }
        private static RenderSystem RenderSystem { get; set; }
        private static BaseSystem[] Systems { get; set; }

        public static void Run()
        {
            RenderSystem = new RenderSystem();
            Systems = new BaseSystem[] { RenderSystem };

            Work();
        }

        public static void Quit()
        {
            RequestQuit = true;
        }

        private static void Work()
        {
            foreach (BaseSystem system in Systems)
            {
                system.Start();
            }

            while (!RequestQuit && RenderSystem.Window.Visible)
            {
                foreach (BaseSystem system in Systems)
                {
                    system.Update();
                }

                Application.DoEvents();
                Thread.Sleep(1000 / TargetFramerate);
            }
        }
    }
}