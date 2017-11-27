using System;
using System.Drawing;
using System.Linq;
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

        public static Vector2 Size
        {
            get => (Vector2)RenderSystem.Window.Size;
            set => RenderSystem.Window.Size = (Size)value;
        }

        private static bool RequestQuit { get; set; }
        private static bool Running => !RequestQuit && (RenderSystem.Window?.Visible ?? false);

        internal static InputSystem InputSystem { get; set; }
        internal static RenderSystem RenderSystem { get; set; }
        internal static GUISystem GUISystem { get; set; }
        internal static BaseSystem[] Systems { get; set; }

        internal static GlobalScript[] GlobalScripts { get; set; }

        public static void Run()
        {
            if (Running)
                return;

            InputSystem = new InputSystem();
            GUISystem = new GUISystem();
            RenderSystem = new RenderSystem();
            Systems = new BaseSystem[] { InputSystem, GUISystem, RenderSystem };

            GlobalScripts = GlobalScript.GetEnumerableOfType<GlobalScript>().OrderBy(script => script.Order).ToArray();

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
                Draw();

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
            foreach (GlobalScript script in GlobalScripts)
            {
                script.Start();
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
            foreach (GlobalScript script in GlobalScripts)
            {
                script.Update();
            }

            Application.DoEvents();
        }

        private static void Draw()
        {
            RenderSystem.Update();
        }
    }
}