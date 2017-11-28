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

        public void SetParent(Transform t)
        {
            Parent = t;
        }
    }
}