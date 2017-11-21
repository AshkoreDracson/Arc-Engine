using System;
using System.Runtime.InteropServices;

namespace ArcEngine
{
    [StructLayout(LayoutKind.Sequential)]
    public struct Vector4 : IEquatable<Vector4>
    {
        public static Vector4 zero => new Vector4(0, 0, 0, 0);
        public static Vector4 one => new Vector4(1, 1, 1, 1);

        public static Vector4 right => new Vector4(1, 0, 0);
        public static Vector4 up => new Vector4(0, 1, 0);
        public static Vector4 forward => new Vector4(0, 0, 1);
        public static Vector4 left => new Vector4(-1, 0, 0);
        public static Vector4 down => new Vector4(0, -1, 0);
        public static Vector4 back => new Vector4(0, 0, -1);

        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }
        public float w { get; set; }

        public float magnitude => (x * x + y * y + z * z + w * w).Sqrt();
        public float sqrMagnitude => x * x + y * y + z * z + w * w;

        public Vector4 normalized
        {
            get
            {
                float m = magnitude;
                return new Vector4(x / m, y / m, z / m, w / m);
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
                    case 2:
                        return z;
                    case 3:
                        return w;
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
                    case 2:
                        z = value;
                        break;
                    case 3:
                        w = value;
                        break;
                }
            }
        }

        public Vector4(float x, float y)
        {
            this.x = x;
            this.y = y;
            this.z = 0;
            this.w = 0;
        }
        public Vector4(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = 0;
        }
        public Vector4(float x, float y, float z, float w)
        {
            this.x = x;
            this.y = y;
            this.z = z;
            this.w = w;
        }

        public void Normalize()
        {
            float m = magnitude;
            x /= m;
            y /= m;
            z /= m;
            w /= m;
        }

        public static Vector4 ClampDistance(Vector4 a, float distance) => a.magnitude > distance ? a.normalized * distance : a;
        public static float Distance(Vector4 a, Vector4 b) => (b - a).magnitude;
        public static Vector4 Lerp(Vector4 a, Vector4 b, float t) => new Vector4(Mathf.Lerp(a.x, b.x, t), Mathf.Lerp(a.y, b.y, t), Mathf.Lerp(a.z, b.z, t), Mathf.Lerp(a.w, b.w, t));

        public static Vector4 operator +(Vector4 a, Vector4 b) => new Vector4(a.x + b.x, a.y + b.y, a.z + b.z, a.w + b.w);
        public static Vector4 operator -(Vector4 a, Vector4 b) => new Vector4(a.x - b.x, a.y - b.y, a.z - b.z, a.w - b.w);
        public static Vector4 operator *(Vector4 a, Vector4 b) => new Vector4(a.x * b.x, a.y * b.y, a.z * b.z, a.w * b.w);
        public static Vector4 operator /(Vector4 a, Vector4 b) => new Vector4(a.x / b.x, a.y / b.y, a.z / b.z, a.w / b.w);

        public static Vector4 operator +(Vector4 a, float b) => new Vector4(a.x + b, a.y + b, a.z + b, a.w + b);
        public static Vector4 operator -(Vector4 a, float b) => new Vector4(a.x - b, a.y - b, a.z - b, a.w - b);
        public static Vector4 operator *(Vector4 a, float b) => new Vector4(a.x * b, a.y * b, a.z * b, a.w * b);
        public static Vector4 operator /(Vector4 a, float b) => new Vector4(a.x / b, a.y / b, a.z / b, a.w / b);

        public static Vector4 operator +(float b, Vector4 a) => new Vector4(a.x + b, a.y + b, a.z + b, a.w + b);
        public static Vector4 operator -(float b, Vector4 a) => new Vector4(a.x - b, a.y - b, a.z - b, a.w - b);
        public static Vector4 operator *(float b, Vector4 a) => new Vector4(a.x * b, a.y * b, a.z * b, a.w * b);
        public static Vector4 operator /(float b, Vector4 a) => new Vector4(a.x / b, a.y / b, a.z / b, a.w / b);

        public static Vector4 operator -(Vector4 a) => new Vector4(-a.x, -a.y, -a.z, -a.w);

        public static bool operator ==(Vector4 a, Vector4 b) => a.x == b.x && a.y == b.y && a.z == b.z && a.w == b.w;
        public static bool operator !=(Vector4 a, Vector4 b) => a.x != b.x || a.y != b.y || a.z != b.z || a.w != b.w;

        public static explicit operator Vector4(Vector2 a) => new Vector4(a.x, a.y);
        public static explicit operator Vector4(Vector3 a) => new Vector4(a.x, a.y, a.z);

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is Vector4 && Equals((Vector4)obj);
        }
        public bool Equals(Vector4 other)
        {
            return x.Equals(other.x) && y.Equals(other.y) && z.Equals(other.z) && w.Equals(other.w);
        }
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = x.GetHashCode();
                hashCode = (hashCode * 397) ^ y.GetHashCode();
                hashCode = (hashCode * 397) ^ z.GetHashCode();
                hashCode = (hashCode * 397) ^ w.GetHashCode();
                return hashCode;
            }
        }
        public override string ToString() => $"X:{x}, Y:{y}, Z:{z}, W:{w}";
    }
}