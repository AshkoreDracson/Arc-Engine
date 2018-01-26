using OpenTK;

namespace ArcEngine
{
    public class Transform : Component
    {
        public Transform Parent { get; set; }

        public Vector3 Position { get; set; }
        public Vector3 EulerAngles { get; set; }
        public Vector3 LossyScale { get; set; }

        public Vector3 LocalPosition { get; set; }
        public Vector3 LocalEulerAngles { get; set; }
        public Vector3 LocalScale { get; set; }

        public Quaternion Rotation => new OpenTK.Quaternion(EulerAngles);

        public Matrix4 LocalToWorldMatrix => Matrix4.CreateRotationX(EulerAngles.x) * Matrix4.CreateRotationY(EulerAngles.y) * Matrix4.CreateRotationZ(EulerAngles.z) * Matrix4.CreateTranslation(Position)
                                              * Matrix4.CreateScale(LossyScale);

        public Vector3 left => ToWorldVector(Vector3.left);
        public Vector3 up => ToWorldVector(Vector3.up);
        public Vector3 forward => ToWorldVector(Vector3.forward);
        public Vector3 right => ToWorldVector(Vector3.right);
        public Vector3 down => ToWorldVector(Vector3.down);
        public Vector3 back => ToWorldVector(Vector3.back);

        public Matrix4 LookAtMatrix => Matrix4.LookAt(Transform.Position, Transform.Position + Transform.forward, Transform.up);

        public void SetParent(Transform t)
        {
            Parent = t;
        }

        public Vector3 ToLocalVector(Vector3 worldVector)
        {
            return OpenTK.Quaternion.Invert(Rotation) * (OpenTK.Vector3)worldVector;
        }
        public Vector3 ToWorldVector(Vector3 localVector)
        {
            return Rotation * (OpenTK.Vector3)localVector;
        }
    }
}