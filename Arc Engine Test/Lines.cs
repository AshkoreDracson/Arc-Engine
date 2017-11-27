using ArcEngine;
using System.Drawing;
using Color = ArcEngine.Color;

namespace ArcEngineTest
{
    public class Lines : GlobalScript
    {
        public Vector2[] points = new Vector2[2]
        {
            new Vector2(10, 10),
            new Vector2(100, 100)
        };

        public override void Update()
        {
            points[0] = new Vector2(10, Mathf.Sin(Time.time).Remap(-1, 1, 10, 100));
            points[1] = new Vector2(100, Mathf.Sin(Time.time + (float)Mathf.Pi).Remap(-1, 1, 10, 100));
        }

        public override void Draw(GraphicContext gc)
        {
            Pen p = new Pen(Color.Lerp(Color.White, Color.Magenta, Time.time.Sin().Remap(-1, 1, 0, 1)));
            gc.Graphics.DrawLine(p, (PointF)points[0], (PointF)points[1]);
        }
    }
}