namespace ArcEngine
{
    public abstract class Component
    {
        public bool Enabled { get; set; } = true;

        public abstract void Start();
        public abstract void Update();
        public abstract void Draw();
    }
}