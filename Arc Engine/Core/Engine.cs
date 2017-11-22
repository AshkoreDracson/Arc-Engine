using System;
using System.Threading;
using System.Windows.Forms;

namespace ArcEngine
{
    public static class Engine
    {
        public static string Title
        {
            get => RenderSystem.Window?.Text ?? "???";
            set => RenderSystem.Window.Text = value;
        }
        public static int TargetFramerate { get; set; } = 60;

        private static bool RequestQuit { get; set; }
        private static bool Running => !RequestQuit && (RenderSystem.Window?.Visible ?? false);

        private static InputSystem InputSystem { get; set; }
        private static RenderSystem RenderSystem { get; set; }
        private static BaseSystem[] Systems { get; set; }

        public static void Run()
        {
            if (Running)
                return;

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
            Start();

            while (Running)
            {
                DateTime start = DateTime.Now;

                Update();

                if (TargetFramerate > 0)
                {
                    DateTime endWork = DateTime.Now;
                    TimeSpan elapsedTime = endWork - start;
                    int waitTime = (1000 / TargetFramerate - (int)elapsedTime.TotalMilliseconds).ClampMin(0);

                    if (waitTime > 0)
                        Thread.Sleep(waitTime);
                }

                DateTime end = DateTime.Now;
                Time.SetDeltaTime((float)(end - start).TotalSeconds);
            }
        }

        private static void Start()
        {
            foreach (BaseSystem system in Systems)
            {
                system.Start();
            }
        }

        private static void Update()
        {
            InputSystem.Update();
            foreach (GameObject go in GameObject.All)
            {
                foreach (Component comp in go.GetComponentsEnumerable())
                {
                    if (!comp.HasStarted) comp.Start();
                    comp.Update();
                }
            }

            Application.DoEvents();
        }

        private static void Draw()
        {
            RenderSystem.Update();
        }
    }
}