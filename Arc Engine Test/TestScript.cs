using ArcEngine;

namespace ArcEngineTest
{
    public class TestScript : GlobalScript
    {
        private TextRenderer[] tr = new TextRenderer[125];

        public override void Start()
        {
            for (int i = 0; i < tr.Length; i++)
            {
                GameObject go = new GameObject();
                tr[i] = go.AddComponent<TextRenderer>();
                tr[i].Text = "O";
                tr[i].Position = new Vector2(10 + i * 10, 10 + i * 10);
            }
        }

        public override void Update()
        {
            for (int i = 0; i < tr.Length; i++)
            {
                float offset = i * 0.05f;
                float x = Mathf.Sin(Time.time * 0.5f + offset).Remap(-1, 1, 10, 1240);
                float y = Mathf.Sin(Time.time * 1f + offset).Remap(-1, 1, 10, 680);
                tr[i].Position = new Vector2(x, y);
                tr[i].Color = Color.Lerp(Color.Green, Color.Magenta, (Time.time * 10f + offset * 2).Sin().Remap(-1, 1, 0, 1));
            }
        }
    }
}