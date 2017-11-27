using Console = System.Console;

namespace ArcEngine
{
    public abstract class Script : Component
    {
        public Transform transform => gameObject.transform;

        public new virtual void Start() { }
        public new virtual void Update() { }
        public new virtual void Draw(GraphicContext gc) { }

        public void print(object o)
        {
            Console.WriteLine(o);
        }
    }
}