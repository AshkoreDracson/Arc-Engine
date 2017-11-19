namespace ArcEngine
{
    public static class Input
    {
        internal static InputSystem System { get; set; }

        public static bool IsKeyDown(Keys key) => System.keyStates[(int)key].HasFlag(KeyState.Pressed);
        public static bool IsKey(Keys key) => System.keyStates[(int)key].HasFlag(KeyState.Held);
        public static bool IsKeyUp(Keys key) => System.keyStates[(int)key].HasFlag(KeyState.Released);

        public static bool IsMouseButtonDown(MouseButtons button) => System.keyStates[(int)button].HasFlag(KeyState.Pressed);
        public static bool IsMouseButton(MouseButtons button) => System.keyStates[(int)button].HasFlag(KeyState.Held);
        public static bool IsMouseButtonUp(MouseButtons button) => System.keyStates[(int)button].HasFlag(KeyState.Released);
    }
}