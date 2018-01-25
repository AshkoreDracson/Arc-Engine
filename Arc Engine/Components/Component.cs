namespace ArcEngine
{
    public abstract class Component
    {
        public bool Enabled { get; set; } = true;
        public GameObject GameObject { get; internal set; }

        internal bool HasStarted { get; set; }

        internal virtual void Start() { }
        internal virtual void Update() { }
        internal virtual void Draw() { }
    }
}