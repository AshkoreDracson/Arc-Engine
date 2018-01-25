using Console = System.Console;

namespace ArcEngine
{
    public abstract class Script : Component
    {
        public Transform transform => GameObject.Transform;

        public new virtual void Start() { }
        public new virtual void Update() { }
        public new virtual void Draw() { }

        public void print(object o)
        {
            Console.WriteLine(o);
        }
    }
}