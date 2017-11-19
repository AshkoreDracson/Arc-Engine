using System;
namespace ArcEngine
{
    public struct Vector3 : IEquatable<Vector3>
    {
        public static Vector3 zero => new Vector3(0, 0, 0);
        public static Vector3 one => new Vector3(1, 1, 1);

        public static Vector3 right => new Vector3(1, 0, 0);
        public static Vector3 up => new Vector3(0, 1, 0);
        public static Vector3 forward => new Vector3(0, 0, 1);
        public static Vector3 left => new Vector3(-1, 0, 0);
        public static Vector3 down => new Vector3(0, -1, 0);
        public static Vector3 back => new Vector3(0, 0, -1);

        public float x { get; set; }
        public float y { get; set; }
        public float z { get; set; }

        public float magnitude => (x * x + y * y + z * z).Sqrt();
        public float sqrMagnitude => x * x + y * y + z * z;

        public Vector3 normalized
        {
            get
            {
                float m = magnitude;
                return new Vector3(x / m, y / m, z / m);
            }
        }

        public Vector3(float x, float y)
        {
            this.x = x;
            this.y = y;
            this.z = 0;
        }
        public Vector3(float x, float y, float z)
        {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public void Normalize()
        {
            float m = magnitude;
            x /= m;
            y /= m;
            z /= m;
        }

        public static Vector3 ClampDistance(Vector3 a, float distance) => a.magnitude > distance ? a.normalized * distance : a;
        public static Vector3 Cross(Vector3 a, Vector3 b) => new Vector3(a.y * b.z - a.z * b.y, a.z * b.x - a.x * b.z, a.x * b.y - a.y * b.x);
        public static float Distance(Vector3 a, Vector3 b) => (b - a).magnitude;
        public static float Dot(Vector3 a, Vector3 b)
        {
            a.Normalize();
            b.Normalize();
            return a.x * b.x + a.y * b.y + a.z * b.z;
        }
        public static Vector3 Lerp(Vector3 a, Vector3 b, float t) => new Vector3(Mathf.Lerp(a.x, b.x, t), Mathf.Lerp(a.y, b.y, t), Mathf.Lerp(a.z, b.z, t));
        public static Vector3 Reflect(Vector3 i, Vector3 n) => i - 2 * n * Dot(i, n);

        public static Vector3 operator +(Vector3 a, Vector3 b) => new Vector3(a.x + b.x, a.y + b.y, a.z + b.z);
        public static Vector3 operator -(Vector3 a, Vector3 b) => new Vector3(a.x - b.x, a.y - b.y, a.z - b.z);
        public static Vector3 operator *(Vector3 a, Vector3 b) => new Vector3(a.x * b.x, a.y * b.y, a.z * b.z);
        public static Vector3 operator /(Vector3 a, Vector3 b) => new Vector3(a.x / b.x, a.y / b.y, a.z / b.z);

        public static Vector3 operator +(Vector3 a, float b) => new Vector3(a.x + b, a.y + b, a.z + b);
        public static Vector3 operator -(Vector3 a, float b) => new Vector3(a.x - b, a.y - b, a.z - b);
        public static Vector3 operator *(Vector3 a, float b) => new Vector3(a.x * b, a.y * b, a.z * b);
        public static Vector3 operator /(Vector3 a, float b) => new Vector3(a.x / b, a.y / b, a.z / b);

        public static Vector3 operator +(float b, Vector3 a) => new Vector3(a.x + b, a.y + b, a.z + b);
        public static Vector3 operator -(float b, Vector3 a) => new Vector3(a.x - b, a.y - b, a.z - b);
        public static Vector3 operator *(float b, Vector3 a) => new Vector3(a.x * b, a.y * b, a.z * b);
        public static Vector3 operator /(float b, Vector3 a) => new Vector3(a.x / b, a.y / b, a.z / b);

        public static Vector3 operator -(Vector3 a) => new Vector3(-a.x, -a.y, -a.z);

        public static bool operator ==(Vector3 a, Vector3 b) => a.x == b.x && a.y == b.y && a.z == b.z;
        public static bool operator !=(Vector3 a, Vector3 b) => a.x != b.x || a.y != b.y || a.z != b.z;

        public static implicit operator Vector3(Vector2 a) => new Vector3(a.x, a.y);
        public static explicit operator Vector3(Vector4 a) => new Vector3(a.x, a.y, a.z);

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            return obj is Vector3 && Equals((Vector3)obj);
        }
        public bool Equals(Vector3 other)
        {
            return x.Equals(other.x) && y.Equals(other.y) && z.Equals(other.z);
        }
        public override int GetHashCode()
        {
            unchecked
            {
                var hashCode = x.GetHashCode();
                hashCode = (hashCode * 397) ^ y.GetHashCode();
                hashCode = (hashCode * 397) ^ z.GetHashCode();
                return hashCode;
            }
        }
        public override string ToString() => $"X:{x}, Y:{y}, Z:{z}";
    }
}