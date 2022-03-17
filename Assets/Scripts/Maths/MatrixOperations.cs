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
        // You are NOT allowed to use the following function, calculate the matrix yourself
        return Matrix4x4.TRS(position, Quaternion.Euler(rotation), scale);
    }
}