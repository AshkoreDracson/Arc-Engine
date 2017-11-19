using System.Collections.Generic;

namespace ArcEngine
{
    public static class Input
    {
        internal static InputSystem System { get; set; }

        private static Dictionary<string, Keys> keyMapping = new Dictionary<string, Keys>();

        public static bool IsButtonDown(string name) => System.keyStates[(int)keyMapping[name]].HasFlag(KeyState.Pressed);
        public static bool IsButton(string name) => System.keyStates[(int)keyMapping[name]].HasFlag(KeyState.Held);
        public static bool IsButtonUp(string name) => System.keyStates[(int)keyMapping[name]].HasFlag(KeyState.Released);

        public static bool IsKeyDown(Keys key) => System.keyStates[(int)key].HasFlag(KeyState.Pressed);
        public static bool IsKey(Keys key) => System.keyStates[(int)key].HasFlag(KeyState.Held);
        public static bool IsKeyUp(Keys key) => System.keyStates[(int)key].HasFlag(KeyState.Released);

        public static bool IsMouseButtonDown(MouseButtons button) => System.keyStates[(int)button].HasFlag(KeyState.Pressed);
        public static bool IsMouseButton(MouseButtons button) => System.keyStates[(int)button].HasFlag(KeyState.Held);
        public static bool IsMouseButtonUp(MouseButtons button) => System.keyStates[(int)button].HasFlag(KeyState.Released);

        public static void RegisterButton(string name, Keys key)
        {
            if (!keyMapping.ContainsKey(name))
                keyMapping.Add(name, key);
            else
                keyMapping[name] = key;
        }
        public static void UnregisterButton(string name)
        {
            if (keyMapping.ContainsKey(name))
                keyMapping.Remove(name);
        }
    }
}