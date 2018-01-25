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

        public Matrix4 LocalToWorldMatrix => Matrix4.CreateTranslation(Position) *
                                             Matrix4.CreateFromQuaternion(Rotation) * Matrix4.CreateScale(LossyScale);

        public void SetParent(Transform t)
        {
            Parent = t;
        }
    }
}