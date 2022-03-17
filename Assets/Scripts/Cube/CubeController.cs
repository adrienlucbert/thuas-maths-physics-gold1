using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class MatrixExtensions
{
    public static Quaternion ExtractRotation(this Matrix4x4 matrix)
    {
        Vector3 forward;
        forward.x = matrix.m02;
        forward.y = matrix.m12;
        forward.z = matrix.m22;

        Vector3 upwards;
        upwards.x = matrix.m01;
        upwards.y = matrix.m11;
        upwards.z = matrix.m21;

        return Quaternion.LookRotation(forward, upwards);
    }

    public static Vector3 ExtractPosition(this Matrix4x4 matrix)
    {
        Vector3 position;
        position.x = matrix.m03;
        position.y = matrix.m13;
        position.z = matrix.m23;
        return position;
    }

    public static Vector3 ExtractScale(this Matrix4x4 matrix)
    {
        Vector3 scale;
        scale.x = new Vector4(matrix.m00, matrix.m10, matrix.m20, matrix.m30).magnitude;
        scale.y = new Vector4(matrix.m01, matrix.m11, matrix.m21, matrix.m31).magnitude;
        scale.z = new Vector4(matrix.m02, matrix.m12, matrix.m22, matrix.m32).magnitude;
        return scale;
    }
}

public static class TransformExtensions
{
    public static void FromMatrix(this Transform transform, Matrix4x4 matrix)
    {
        transform.localScale = matrix.ExtractScale();
        transform.rotation = matrix.ExtractRotation();
        transform.position = matrix.ExtractPosition();
    }
}

public class CubeController : MonoBehaviour
{
    public delegate void UpdateTransformationMatrixAction();
    public event UpdateTransformationMatrixAction OnTransformationMatrixUpdated;

    private Vector3 _position;
    private Vector3 _rotation;
    private Vector3 _scale;
    private Matrix4x4 _transformationMatrix;

    public Matrix4x4 TransformationMatrix
    {
        get { return this._transformationMatrix; }
    }

    public Vector3 Position
    {
        get { return this._position; }
        set
        {
            this._position = value;
            this.updateMatrix();
        }
    }

    public Vector3 Rotation
    {
        get { return this._rotation; }
        set
        {
            this._rotation = value;
            this.updateMatrix();
        }
    }

    public Vector3 Scale
    {
        get { return this._scale; }
        set
        {
            this._scale = value;
            this.updateMatrix();
        }
    }

    private void updateMatrix()
    {
        // You are NOT allowed to use the following function, calculate the matrix yourself
        this._transformationMatrix = Matrix4x4.TRS(
            this.Position,
            Quaternion.Euler(this.Rotation),
            this.Scale
        );
        if (OnTransformationMatrixUpdated != null)
            OnTransformationMatrixUpdated();
    }

    private void Start()
    {
        this._position = Vector3.zero;
        this._rotation = Vector3.zero;
        this._scale = Vector3.one;
        this.updateMatrix();
    }

    private void Update()
    {
        // assign your the transformation matrix to the object's transform
        transform.FromMatrix(this.TransformationMatrix);
    }
}
