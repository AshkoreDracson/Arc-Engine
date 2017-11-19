namespace ArcEngine
{
    public static class Time
    {
        public static float deltaTime { get; private set; }
        public static float time { get; private set; }
        public static float timeScale { get; set; } = 1f;
        public static float unscaledDeltaTime { get; private set; }
        public static float unscaledTime { get; private set; }

        internal static void SetDeltaTime(float dt)
        {
            deltaTime = dt * timeScale;
            unscaledDeltaTime = dt;

            time += deltaTime;
            unscaledTime += unscaledDeltaTime;
        }
    }
}