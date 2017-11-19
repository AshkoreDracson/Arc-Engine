using System;
using System.Threading;
using System.Windows.Forms;

namespace ArcEngine
{
    public static class Engine
    {
        public static int TargetFramerate { get; set; } = 60;

        private static bool RequestQuit { get; set; }

        private static InputSystem InputSystem { get; set; }
        private static RenderSystem RenderSystem { get; set; }
        private static BaseSystem[] Systems { get; set; }

        public static void Run()
        {
            InputSystem = new InputSystem();
            RenderSystem = new RenderSystem();
            Systems = new BaseSystem[] { InputSystem, RenderSystem };

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
                DateTime start = DateTime.Now;

                foreach (BaseSystem system in Systems)
                {
                    system.Update();
                }
                Application.DoEvents();

                DateTime endWork = DateTime.Now;
                TimeSpan elapsedTime = endWork - start;
                int waitTime = (1000 / TargetFramerate - (int)elapsedTime.TotalMilliseconds).ClampMin(0);

                if (waitTime > 0)
                    Thread.Sleep(waitTime);

                DateTime end = DateTime.Now;
                Time.SetDeltaTime((float)(end - start).TotalSeconds);
            }
        }
    }
}