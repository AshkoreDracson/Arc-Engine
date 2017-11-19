using System;

namespace ArcEngine
{
    public struct Color : IEquatable<Color>
    {
        public static Color Black => new Color(0, 0, 0);
        public static Color Gray => new Color(0.5f, 0.5f, 0.5f);
        public static Color White => new Color(255, 255, 255);
        public static Color Red => new Color(255, 0, 0);
        public static Color Orange => new Color(255, 128, 0);
        public static Color Yellow => new Color(255, 255, 0);
        public static Color Green => new Color(0, 255, 0);
        public static Color Cyan => new Color(0, 255, 255);
        public static Color Blue => new Color(0, 0, 255);
        public static Color Magenta => new Color(255, 0, 255);

        private float _r, _g, _b, _a;

        public float r
        {
            get => _r;
            set => _r = value.ClampMin(0);
        }
        public float g
        {
            get => _g;
            set => _g = value.ClampMin(0);
        }
        public float b
        {
            get => _b;
            set => _b = value.ClampMin(0);
        }
        public float a
        {
            get => _a;
            set => _a = value.Clamp01();
        }

        public float Hue => Mathf.Atan2(1.732050808f * (g - b), 2f * r - g - b) * 57.295779513f * 180f / (float)Mathf.Pi;
        public float Saturation
        {
            get
            {
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
                float min = Math.Min(Math.Min(r, g), b);
                float max = Math.Max(Math.Max(r, g), b);
                return (max + min) / 2;
            }
        }

        public bool IsHDR => r > 1 || g > 1 || b > 1;

        public Color(float r, float g, float b)
        {
            _r = _g = _b = _a = 0;

            this.r = r;
            this.g = g;
            this.b = b;
            this.a = 1;
        }

        public Color(float r, float g, float b, float a)
        {
            _r = _g = _b = _a = 0;

            this.r = r;
            this.g = g;
            this.b = b;
            this.a = a;
        }

        public int ToArgb() => (byte)(a * 255) << 8 | (byte)(r * 255).ClampMax(255) << 8 | (byte)(g * 255).ClampMax(255) << 8 | (byte)(b * 255).ClampMax(255);

        public static Color Lerp(Color a, Color b, float t) => new Color(Mathf.Lerp(a.r, b.r, t), Mathf.Lerp(a.g, b.g, t), Mathf.Lerp(a.b, b.b, t), Mathf.Lerp(a.a, b.a, t));

        public static Color operator +(Color a, Color b) => new Color(a.r + b.r, a.g + b.g, a.b + b.b, a.a + b.a);
        public static Color operator -(Color a, Color b) => new Color(a.r - b.r, a.g - b.g, a.b - b.b, a.a - b.a);
        public static Color operator *(Color a, Color b) => new Color(a.r * b.r, a.g * b.g, a.b * b.b, a.a * b.a);
        public static Color operator *(Color a, float b) => new Color(a.r * b, a.g * b, a.b * b, a.a * b);
        public static Color operator *(float b, Color a) => new Color(a.r * b, a.g * b, a.b * b, a.a * b);
        public static Color operator /(Color a, float b) => new Color(a.r / b, a.g / b, a.b / b, a.a / b);

        public static bool operator ==(Color a, Color b) => a.r == b.r && a.g == b.g && a.b == b.b && a.a == b.a;
        public static bool operator !=(Color a, Color b) => a.r != b.r || a.g != b.g || a.b != b.b || a.a != b.a;

        public static implicit operator Color32(Color c) => new Color32((byte)(c.r * 255).ClampMax(255), (byte)(c.g * 255).ClampMax(255), (byte)(c.b * 255).ClampMax(255), (byte)(c.a * 255).ClampMax(255));
        public static implicit operator System.Drawing.Color(Color c) => System.Drawing.Color.FromArgb((byte)(c.a * 255).ClampMax(255), (byte)(c.r * 255).ClampMax(255), (byte)(c.g * 255).ClampMax(255), (byte)(c.b * 255).ClampMax(255));

        public override string ToString() => $"R:{r}, G:{g}, B:{b}, A:{a}";
        public bool Equals(Color other) => r == other.r && g == other.g && b == other.b && a == other.a;
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is Color && Equals((Color)obj);
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