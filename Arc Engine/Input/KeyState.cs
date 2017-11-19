using System;

namespace ArcEngine
{
    [Flags]
    public enum KeyState : byte
    {
        None = 0x00,
        Pressed = 0x01,
        Held = 0x02,
        Released = 0x04
    }
}