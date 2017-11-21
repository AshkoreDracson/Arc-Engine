using System;
namespace ArcEngine
{
    public struct Vector2 : IEquatable<Vector2>
    {
        public static Vector2 zero => new Vector2(0, 0);
        public static Vector2 one => new Vector2(1, 1);

        public static Vector2 right => new Vector2(1, 0);
        public static Vector2 up => new Vector2(0, 1);
        public static Vector2 left => new Vector2(-1, 0);
        public static Vector2 down => new Vector2(0, -1);

        public float x { get; set; }
        public float y { get; set; }

        public float magnitude => (x * x + y * y).Sqrt();
        public float sqrMagnitude => x * x + y * y;

        public Vector2 normalized
        {
            get
            {
                float m = magnitude;
                return new Vector2(x / m, y / m);
            }
        }

        public float this[int i]
        {
            get
            {
                switch (i)
                {
                    case 0:
                        return x;
                    case 1:
                        return y;
                    default:
                        return float.NaN;
                }
            }
            set
            {
                switch (i)
                {
                    case 0:
                        x = value;
                        break;
                    case 1:
                        y = value;
                        break;
                }
            }
        }

        public Vector2(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        public void Normalize()
        {
            float m = magnitude;
            x /= m;
            y /= m;
        }

        public static Vector2 ClampDistance(Vector2 a, float distance) => a.magnitude > distance ? a.normalized * distance : a;
        public static float Distance(Vector2 a, Vector2 b) => (b - a).magnitude;
        public static float Dot(Vector2 a, Vector2 b)
        {
            a.Normalize();
            b.Normalize();
            return a.x * b.x + a.y * b.y;
        }
        public static Vector2 Lerp(Vector2 a, Vector2 b, float t) => new Vector2(Mathf.Lerp(a.x, b.x, t), Mathf.Lerp(a.y, b.y, t));
        public static Vector2 Reflect(Vector2 i, Vector2 n) => i - 2 * n * Dot(i, n);

        public static Vector2 operator +(Vector2 a, Vector2 b) => new Vector2(a.x + b.x, a.y + b.y);
        public static Vector2 operator -(Vector2 a, Vector2 b) => new Vector2(a.x - b.x, a.y - b.y);
        public static Vector2 operator *(Vector2 a, Vector2 b) => new Vector2(a.x * b.x, a.y * b.y);
        public static Vector2 operator /(Vector2 a, Vector2 b) => new Vector2(a.x / b.x, a.y / b.y);

        public static Vector2 operator +(Vector2 a, float b) => new Vector2(a.x + b, a.y + b);
        public static Vector2 operator -(Vector2 a, float b) => new Vector2(a.x - b, a.y - b);
        public static Vector2 operator *(Vector2 a, float b) => new Vector2(a.x * b, a.y * b);
        public static Vector2 operator /(Vector2 a, float b) => new Vector2(a.x / b, a.y / b);

        public static Vector2 operator +(float b, Vector2 a) => new Vector2(a.x + b, a.y + b);
        public static Vector2 operator -(float b, Vector2 a) => new Vector2(a.x - b, a.y - b);
        public static Vector2 operator *(float b, Vector2 a) => new Vector2(a.x * b, a.y * b);
        public static Vector2 operator /(float b, Vector2 a) => new Vector2(a.x / b, a.y / b);

        public static Vector2 operator -(Vector2 a) => new Vector2(-a.x, -a.y);

        public static bool operator ==(Vector2 a, Vector2 b) => a.x == b.x && a.y == b.y;
        public static bool operator !=(Vector2 a, Vector2 b) => a.x != b.x || a.y != b.y;

        public static implicit operator Vector2(Vector3 a) => new Vector2(a.x, a.y);
        public static explicit operator Vector2(Vector4 a) => new Vector2(a.x, a.y);

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is Vector2 && Equals((Vector2)obj);
        }
        public bool Equals(Vector2 other)
        {
            return x.Equals(other.x) && y.Equals(other.y);
        }
        public override int GetHashCode()
        {
            unchecked
            {
                return (x.GetHashCode() * 397) ^ y.GetHashCode();
            }
        }
        public override string ToString() => $"X:{x}, Y:{y}";
    }
}