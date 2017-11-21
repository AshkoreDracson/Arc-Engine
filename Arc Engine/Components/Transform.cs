﻿namespace ArcEngine
{
    public class Transform : Component
    {
        public Transform parent { get; set; }

        public Vector3 position { get; set; }
        public Vector3 eulerAngles { get; set; }
        public Vector3 lossyScale { get; set; }

        public Vector3 localPosition { get; set; }
        public Vector3 localEulerAngles { get; set; }
        public Vector3 localScale { get; set; }

        public void SetParent(Transform t)
        {
            parent = t;
        }
    }
}