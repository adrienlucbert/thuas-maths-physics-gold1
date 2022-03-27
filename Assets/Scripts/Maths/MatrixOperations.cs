using UnityEngine;

public static class MatrixOperations
{
    /// <summary>
    /// Creates a translation, rotation and scaling matrix.
    /// </summary>
    /// <param name="position">Translation vector</param>
    /// <param name="rotation">Rotation vector</param>
    /// <param name="scale">Scale vector</param>
    public static Matrix4x4 TRS(Vector3 position, Vector3 rotation, Vector3 scale)
    {
        Matrix4x4 m = Matrix4x4.identity;
        m = m * MatrixOperations.Translate(position);
        m = m * MatrixOperations.Rotate(rotation);
        m = m * MatrixOperations.Scale(scale);
        // m = MatrixOperations.rightToLeftHanded(m);
        return m;
    }

    public static Matrix4x4 Translate(Vector3 position)
    {
        Matrix4x4 T = new Matrix4x4(
            new Vector4(1, 0, 0, position.x),
            new Vector4(0, 1, 0, position.y),
            new Vector4(0, 0, 1, position.z),
            new Vector4(0, 0, 0, 1)
        ).transpose;
        return T;
    }
    public static Matrix4x4 Rotate(Vector3 rotation)
    {
        float x = -rotation.x * Mathf.PI / 180f;
        float y = -rotation.y * Mathf.PI / 180f;
        float z = -rotation.z * Mathf.PI / 180f;
        Matrix4x4 Rx = new Matrix4x4(
            new Vector4(1, 0, 0, 0),
            new Vector4(0, Mathf.Cos(x), Mathf.Sin(x), 0),
            new Vector4(0, -Mathf.Sin(x), Mathf.Cos(x), 0),
            new Vector4(0, 0, 0, 1)
        ).transpose;
        Matrix4x4 Ry = new Matrix4x4(
            new Vector4(Mathf.Cos(y), 0, -Mathf.Sin(y), 0),
            new Vector4(0, 1, 0, 0),
            new Vector4(Mathf.Sin(y), 0, Mathf.Cos(y), 0),
            new Vector4(0, 0, 0, 1)
        ).transpose;
        Matrix4x4 Rz = new Matrix4x4(
            new Vector4(Mathf.Cos(z), Mathf.Sin(z), 0, 0),
            new Vector4(-Mathf.Sin(z), Mathf.Cos(z), 0, 0),
            new Vector4(0, 0, 1, 0),
            new Vector4(0, 0, 0, 1)
        ).transpose;
        return Ry * Rx * Rz;
    }
    public static Matrix4x4 Scale(Vector3 scale)
    {
        Matrix4x4 S = new Matrix4x4(
            new Vector4(scale.x, 0, 0, 0),
            new Vector4(0, scale.y, 0, 0),
            new Vector4(0, 0, scale.z, 0),
            new Vector4(0, 0, 0, 1)
        ).transpose;
        return S;
    }
    public static Matrix4x4 RotateAroundAxis(Vector3 axis, float angle)
    {
        axis = VectorOperations.Normalized(axis);
        angle = angle * Mathf.PI / 180f; // convert degree angle to radians
        Matrix4x4 m = Matrix4x4.zero;
        float c = Mathf.Cos(angle);
        float s = Mathf.Sin(angle);
        float t = 1f - Mathf.Cos(angle);
        m.m00 = t * axis.x * axis.x + c;
        m.m01 = t * axis.x * axis.y - s * axis.z;
        m.m02 = t * axis.x * axis.z + s * axis.y;
        m.m10 = t * axis.x * axis.y + s * axis.z;
        m.m11 = t * axis.y * axis.y + c;
        m.m12 = t * axis.y * axis.z - s * axis.x;
        m.m20 = t * axis.x * axis.z - s * axis.y;
        m.m21 = t * axis.y * axis.z + s * axis.x;
        m.m22 = t * axis.z * axis.z + c;
        return m;
    }
    public static Matrix4x4 Transpose(Matrix4x4 matrix)
    {
        Matrix4x4 m = matrix;
        for (int i = 0; i < 4; ++i)
            for (int j = 0; j < 4; ++j)
                m[j, i] = matrix[i, j];
        return m;
    }
    public static Matrix4x4 Product(Matrix4x4 a, Matrix4x4 b)
    {
        Matrix4x4 m = Matrix4x4.zero;

        for (int i = 0; i < 4; ++i)
            for (int j = 0; j < 4; ++j)
                for (int k = 0; k < 4; ++k)
                    m[i, j] += a[i, k] * b[k, j];
        return m;
    }
    public static Matrix4x4 Substract(Matrix4x4 a, Matrix4x4 b)
    {
        Matrix4x4 m = a;
        for (int i = 0; i < 4; ++i)
            for (int j = 0; j < 4; ++j)
                m[i, j] -= b[i, j];
        return m;
    }
}
