using System;
using System.Drawing;
using System.Linq;
using OpenTK;

namespace ArcEngine
{
    public static class Engine
    {
        public static string Title
        {
            get => RenderSystem?.Title;
            set => RenderSystem.Title = value;
        }

        private static bool RequestQuit { get; set; }
        private static bool Running => !RequestQuit && (RenderSystem.Window?.Visible ?? false);

        internal static InputSystem InputSystem { get; set; }
        internal static RenderSystem RenderSystem { get; set; }
        internal static BaseSystem[] Systems { get; set; }

        internal static GlobalScript[] GlobalScripts { get; set; }

        public static void Run()
        {
            if (Running)
                return;

            InputSystem = new InputSystem();
            RenderSystem = new RenderSystem();
            Systems = new BaseSystem[] { InputSystem, RenderSystem };

            RenderSystem.TargetFramerate = 60;

            GlobalScripts = GlobalScript.GetEnumerableOfType<GlobalScript>().OrderBy(script => script.Order).ToArray();

            RenderSystem.Window.UpdateFrame += Update;
            RenderSystem.Window.RenderFrame += Draw;

            Work();
        }

        public static void Quit()
        {
            RequestQuit = true;
        }

        private static void Work()
        {
            Start();
        }

        private static void Start()
        {
            InputSystem.Start();

            foreach (GlobalScript script in GlobalScripts)
            {
                script.Start();
            }

            RenderSystem.Start();
        }

        private static void Update(object sender, FrameEventArgs e)
        {
            InputSystem.Update();

            foreach (GameObject go in GameObject.All.Where(g => g.Enabled))
            {
                foreach (Component comp in go.GetComponentsEnumerable().Where(c => c.Enabled))
                {
                    if (!comp.HasStarted) comp.Start();
                    comp.Update();
                }
            }
            foreach (GlobalScript script in GlobalScripts)
            {
                script.Update();
            }
        }

        private static void Draw(object sender, FrameEventArgs e)
        {
            RenderSystem.Update();
            Time.SetDeltaTime((float)e.Time);
        }
    }
}