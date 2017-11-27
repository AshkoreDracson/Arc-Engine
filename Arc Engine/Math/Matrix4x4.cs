using System;

namespace ArcEngine
{
    public struct Matrix4x4
    {
        public static Matrix4x4 identity => new Matrix4x4(new float[,] {
            { 1, 0, 0, 0 },
            { 0, 1, 0, 0 },
            { 0, 0, 1, 0 },
            { 0, 0, 0, 1 }
        });

        private float[,] m;

        public float this[int index]
        {
            get => m[index / 4, index % 4];
            set => m[index / 4, index % 4] = value;
        }
        public float this[int row, int column]
        {
            get => m[row, column];
            set => m[row, column] = value;
        }

        public Matrix4x4(float[,] matrix)
        {
            if (matrix.GetLength(0) != 4 || matrix.GetLength(1) != 4)
                throw new Exception("Matrix length is invalid!");

            m = matrix;
        }
        public Matrix4x4(Vector4[] matrix)
        {
            if (matrix.Length != 4)
                throw new Exception("Matrix length is invalid!");

            m = new float[4, 4];

            for (int i = 0; i < matrix.Length; i++)
            {
                m[i, 0] = matrix[i].x;
                m[i, 1] = matrix[i].y;
                m[i, 2] = matrix[i].z;
                m[i, 3] = matrix[i].w;
            }
        }

        public Vector4 GetRow(int index) => new Vector4(this[index, 0], this[index, 1], this[index, 2], this[index, 3]);
        public Vector4 GetColumn(int index) => new Vector4(this[0, index], this[0, index], this[0, index], this[0, index]);
    }
}