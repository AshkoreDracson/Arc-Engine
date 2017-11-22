using ArcEngine;

namespace ArcEngineTest
{
    internal static class Program
    {
        private static void Main()
        {
            GameObject go = new GameObject(); // This is totally not how you should create GameObjects or anything, scriptbehaviours or something coming soon!
            TextRenderer tr = go.AddComponent<TextRenderer>();
            tr.Text = "Hello! The text renderer is working!";
            tr.Position = new Vector2(10, 10);

            Engine.Run();
        }
    }
}