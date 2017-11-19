using System.Runtime.InteropServices;

namespace ArcEngine
{
    public class InputSystem : BaseSystem
    {
        [DllImport("user32.dll")]
        static extern short GetAsyncKeyState(Keys vKey);
        [DllImport("user32.dll")]
        static extern short GetAsyncKeyState(int vKey);

        internal KeyState[] keyStates;

        public override void Start()
        {
            keyStates = new KeyState[256];
            Input.System = this;
        }

        public override void Update()
        {
            for (int i = 0; i < keyStates.Length; i++)
            {
                switch (GetAsyncKeyState(i))
                {
                    case 0:
                        goto default;
                    case -32767:
                        keyStates[i] = KeyState.Pressed | KeyState.Held;
                        break;
                    case -32768:
                        keyStates[i] = KeyState.Held;
                        break;
                    default:
                        if (keyStates[i].HasFlag(KeyState.Held))
                            keyStates[i] = KeyState.Released;
                        else
                            keyStates[i] = KeyState.None;
                        break;
                }
            }
        }
    }
}