namespace ArcEngine
{
    public abstract class Component
    {
        public bool Enabled { get; set; } = true;

        internal virtual void Start() { }
        internal virtual void Update() { }
        internal virtual void Draw() { }
    }
}