using ArcEngine;
using System.Drawing;
using Color = ArcEngine.Color;

namespace ArcEngineTest
{
    public class GUITest : GlobalScript
    {
        Brush brush = new SolidBrush(Color.Gray);

        public override void Update()
        {
            GUI.Rectangle(new Vector2(10, 10), new Vector2((Time.time * 2).Sin().Remap(-1, 1, 100, 500), (Time.time * 6).Cos().Remap(-1, 1, 100, 500)), brush);
            GUI.Text("Hello world!", new Vector2((Time.time * 10).Cos().Remap(-1, 1, 10, 100), (Time.time * 3).Sin().Remap(-1, 1, 10, 500)));
        }
    }
}