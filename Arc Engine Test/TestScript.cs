using ArcEngine;

namespace ArcEngineTest
{
    public class TestScript : GlobalScript
    {
        private TextRenderer[] tr = new TextRenderer[50];

        public override void Start()
        {
            for (int i = 0; i < tr.Length; i++)
            {
                GameObject go = new GameObject();
                tr[i] = go.AddComponent<TextRenderer>();
                tr[i].Text = i.ToString();
                tr[i].Position = new Vector2(10 + i * 10, 10 + i * 10);
            }
        }

        public override void Update()
        {
            for (int i = 0; i < tr.Length; i++)
            {
                tr[i].Position = new Vector2(10 + i * 10, 10 + (Time.time * 6 + (i)).Cos().Remap(-1, 1, 50, 0) + i * 10);
            }
        }
    }
}