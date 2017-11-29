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

        public Matrix4x4(params float[] matrix)
        {
            if (matrix.Length != 16)
                throw new Exception("Matrix length is invalid!");

            m = new float[4, 4]
            {
                { matrix[0],  matrix[1],  matrix[2],  matrix[3] },
                { matrix[4],  matrix[5],  matrix[6],  matrix[7] },
                { matrix[8],  matrix[9],  matrix[10], matrix[11] },
                { matrix[12], matrix[13], matrix[14], matrix[15] }
            };
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

        public static Matrix4x4 operator *(Matrix4x4 a, Matrix4x4 b)
        {
            float a00 = a[0, 0];
            float a01 = a[0, 1];
            float a02 = a[0, 2];
            float a03 = a[0, 3];

            float a10 = a[1, 0];
            float a11 = a[1, 1];
            float a12 = a[1, 2];
            float a13 = a[1, 3];

            float a20 = a[2, 0];
            float a21 = a[2, 1];
            float a22 = a[2, 2];
            float a23 = a[2, 3];

            float a30 = a[3, 0];
            float a31 = a[3, 1];
            float a32 = a[3, 2];
            float a33 = a[3, 3];

            float b00 = b[0, 0];
            float b01 = b[0, 1];
            float b02 = b[0, 2];
            float b03 = b[0, 3];

            float b10 = b[1, 0];
            float b11 = b[1, 1];
            float b12 = b[1, 2];
            float b13 = b[1, 3];

            float b20 = b[2, 0];
            float b21 = b[2, 1];
            float b22 = b[2, 2];
            float b23 = b[2, 3];

            float b30 = b[3, 0];
            float b31 = b[3, 1];
            float b32 = b[3, 2];
            float b33 = b[3, 3];

            float[,] matrix = new float[4, 4];

            matrix[0, 0] = a00 * b00 + a10 * b01 + a20 * b02 + a30 * b03;
            matrix[0, 1] = a01 * b00 + a11 * b01 + a21 * b02 + a31 * b03;
            matrix[0, 2] = a02 * b00 + a12 * b01 + a22 * b02 + a32 * b03;
            matrix[0, 3] = a03 * b00 + a13 * b01 + a23 * b02 + a33 * b03;

            matrix[1, 0] = a00 * b10 + a10 * b11 + a20 * b12 + a30 * b13;
            matrix[1, 1] = a01 * b10 + a11 * b11 + a21 * b12 + a31 * b13;
            matrix[1, 2] = a02 * b10 + a12 * b11 + a22 * b12 + a32 * b13;
            matrix[1, 3] = a03 * b10 + a13 * b11 + a23 * b12 + a33 * b13;

            matrix[2, 0] = a00 * b20 + a10 * b21 + a20 * b22 + a30 * b23;
            matrix[2, 1] = a01 * b20 + a11 * b21 + a21 * b22 + a31 * b23;
            matrix[2, 2] = a02 * b20 + a12 * b21 + a22 * b22 + a32 * b23;
            matrix[2, 3] = a03 * b20 + a13 * b21 + a23 * b22 + a33 * b23;

            matrix[3, 0] = a00 * b30 + a10 * b31 + a20 * b32 + a30 * b33;
            matrix[3, 1] = a01 * b30 + a11 * b31 + a21 * b32 + a31 * b33;
            matrix[3, 2] = a02 * b30 + a12 * b31 + a22 * b32 + a32 * b33;
            matrix[3, 3] = a03 * b30 + a13 * b31 + a23 * b32 + a33 * b33;

            return new Matrix4x4(matrix);
        }
    }
}