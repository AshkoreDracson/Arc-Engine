using System;

namespace ArcEngine
{
    public struct Color32 : IEquatable<Color32>
    {
        public static Color32 Black => new Color32(0, 0, 0);
        public static Color32 Gray => new Color32(128, 128, 128);
        public static Color32 White => new Color32(255, 255, 255);
        public static Color32 Red => new Color32(255, 0, 0);
        public static Color32 Orange => new Color32(255, 128, 0);
        public static Color32 Yellow => new Color32(255, 255, 0);
        public static Color32 Green => new Color32(0, 255, 0);
        public static Color32 Cyan => new Color32(0, 255, 255);
        public static Color32 Blue => new Color32(0, 0, 255);
        public static Color32 Magenta => new Color32(255, 0, 255);

        public byte r { get; set; }
        public byte g { get; set; }
        public byte b { get; set; }
        public byte a { get; set; }

        public float Hue
        {
            get
            {
                float r = this.r / 255f;
                float g = this.g / 255f;
                float b = this.b / 255f;
                return Mathf.Atan2(1.732050808f * (g - b), 2f * r - g - b) * 57.295779513f * 180f / (float)Mathf.Pi;
            }
        }
        public float Saturation
        {
            get
            {
                float r = this.r / 255f;
                float g = this.g / 255f;
                float b = this.b / 255f;

                float min = Math.Min(Math.Min(r, g), b);
                float max = Math.Max(Math.Max(r, g), b);
                float delta = max - min;

                return Luminosity <= 0.5 ? delta / (max + min) : delta / (2 - max - min);
            }
        }
        public float Luminosity
        {
            get
            {
                float r = this.r / 255f;
                float g = this.g / 255f;
                float b = this.b / 255f;

                float min = Math.Min(Math.Min(r, g), b);
                float max = Math.Max(Math.Max(r, g), b);
                return (max + min) / 2;
            }
        }

        public byte this[int i]
        {
            get
            {
                switch (i)
                {
                    case 0:
                        return r;
                    case 1:
                        return g;
                    case 2:
                        return b;
                    case 3:
                        return a;
                    default:
                        return 0;
                }
            }
            set
            {
                switch (i)
                {
                    case 0:
                        r = value;
                        break;
                    case 1:
                        g = value;
                        break;
                    case 2:
                        b = value;
                        break;
                    case 3:
                        a = value;
                        break;
                }
            }
        }

        public Color32(byte r, byte g, byte b)
        {
            this.r = r;
            this.g = g;
            this.b = b;
            this.a = 255;
        }

        public Color32(byte r, byte g, byte b, byte a)
        {
            this.r = r;
            this.g = g;
            this.b = b;
            this.a = a;
        }

        public int ToArgb() => a << 8 | r << 8 | g << 8 | b;

        public static Color32 Lerp(Color32 a, Color32 b, float t) => new Color32((byte)Mathf.Lerp(a.r, b.r, t), (byte)Mathf.Lerp(a.g, b.g, t), (byte)Mathf.Lerp(a.b, b.b, t), (byte)Mathf.Lerp(a.a, b.a, t));

        public static bool operator ==(Color32 a, Color32 b) => a.r == b.r && a.g == b.g && a.b == b.b && a.a == b.a;
        public static bool operator !=(Color32 a, Color32 b) => a.r != b.r || a.g != b.g || a.b != b.b || a.a != b.a;

        public static implicit operator Color(Color32 c) => new Color(c.r / 255f, c.g / 255f, c.b / 255f, c.a / 255f);
        public static implicit operator System.Drawing.Color(Color32 c) => System.Drawing.Color.FromArgb(c.a, c.r, c.g, c.b);

        public override string ToString() => $"R:{r}, G:{g}, B:{b}, A:{a}";
        public bool Equals(Color32 other) => r == other.r && g == other.g && b == other.b && a == other.a;
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is Color32 && Equals((Color32)obj);
        }
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = r.GetHashCode();
                hashCode = (hashCode * 397) ^ g.GetHashCode();
                hashCode = (hashCode * 397) ^ b.GetHashCode();
                hashCode = (hashCode * 397) ^ a.GetHashCode();
                return hashCode;
            }
        }
    }
}