using System.Collections;
using System.Collections.Generic;
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
        m = MatrixOperations.Rotate(m, rotation);
        m = MatrixOperations.Translate(m, position);
        m = MatrixOperations.Scale(m, scale);
        // You are NOT allowed to use the following function, calculate the matrix yourself
        //m = Matrix4x4.TRS(position, Quaternion.Euler(rotation), scale);
        return m;
    }

    private static Matrix4x4 Translate(Matrix4x4 matrix, Vector3 position)
    {
        matrix.m03 += position.x;
        matrix.m13 += position.y;
        matrix.m23 += position.z;
        return matrix;
    }
    private static Matrix4x4 Product(Matrix4x4 a, Matrix4x4 b)
    {
        Matrix4x4 m = Matrix4x4.zero;

        for (int i = 0; i < 4; ++i)
            for (int j = 0; j < 4; ++j)
                for (int k = 0; k < 4; ++k)
                    m[i, j] += a[i, k] * b[k, j];
        return m;
    }
    private static Matrix4x4 RotateAroundAxis(Matrix4x4 matrix, Vector3 axis, float angle)
    {
        axis = axis.normalized; // TODO: replace with own function
        angle = angle * Mathf.PI / 180f; // convert degree angle to radians
        Matrix4x4 m = Matrix4x4.zero;
        float c = Mathf.Cos(angle);
        float s = Mathf.Sin(angle);
        float t = 1 - Mathf.Cos(angle);
        m.m00 = t * axis.x * axis.x + c;
        m.m01 = t * axis.x * axis.y - s * axis.z;
        m.m02 = t * axis.x * axis.y + s * axis.y;
        m.m10 = t * axis.x * axis.y + s * axis.z;
        m.m11 = t * axis.y * axis.y + c;
        m.m12 = t * axis.y * axis.z - s * axis.x;
        m.m20 = t * axis.x * axis.z - s * axis.y;
        m.m21 = t * axis.y * axis.z + s * axis.x;
        m.m22 = t * axis.z * axis.z + c;
        return MatrixOperations.Product(matrix, m);
    }
    private static Matrix4x4 Rotate(Matrix4x4 matrix, Vector3 rotation)
    {
        matrix = MatrixOperations.RotateAroundAxis(matrix, Vector3.right, rotation.x);
        matrix = MatrixOperations.RotateAroundAxis(matrix, Vector3.up, rotation.y);
        matrix = MatrixOperations.RotateAroundAxis(matrix, Vector3.forward, rotation.z);
        return matrix;
    }
    private static Matrix4x4 Scale(Matrix4x4 matrix, Vector3 scale)
    {
        return matrix;
    }
}