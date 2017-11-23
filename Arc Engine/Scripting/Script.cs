namespace ArcEngine
{
    public abstract class Script : Component
    {
        public new virtual void Start() { }
        public new virtual void Update() { }
        public new virtual void Draw(GraphicContext gc) { }
    }
}