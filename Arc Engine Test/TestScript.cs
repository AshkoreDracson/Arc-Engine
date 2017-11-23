using ArcEngine;

namespace ArcEngineTest
{
    public class TestScript : GlobalScript
    {
        private TextRenderer tr;

        public override void Start()
        {
            GameObject go = new GameObject();
            tr = go.AddComponent<TextRenderer>();
            tr.Text = "This is a test";
            tr.Position = new Vector2(10, 10);
        }

        public override void Update()
        {
            tr.Position = new Vector2(10, 10 + (Time.time * 6).Cos().Remap(-1, 1, 50, 0));
        }
    }
}