using ArcEngine;

namespace ArcEngineTest
{
    public class FPSCounter : GlobalScript
    {
        public override int Order => 1;

        public TextRenderer fpsText;

        public override void Start()
        {
            GameObject go = new GameObject("FPS Counter");
            fpsText = go.AddComponent<TextRenderer>();
            fpsText.Color = Color.White * 0.8f;
            fpsText.Position = new Vector2(10, 10);
        }

        public override void Update()
        {
            fpsText.Text = $"FPS: {Time.FPS.Round()}, Time: {Time.time:N2}";
        }
    }
}