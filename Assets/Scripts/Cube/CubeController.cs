using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    public UnityEvent OnTransformationMatrixUpdated;

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
            this.UpdateMatrix();
        }
    }

    public Vector3 Rotation
    {
        get { return this._rotation; }
        set
        {
            this._rotation = value;
            this.UpdateMatrix();
        }
    }

    public Vector3 Scale
    {
        get { return this._scale; }
        set
        {
            this._scale = value;
            this.UpdateMatrix();
        }
    }

    private void UpdateMatrix()
    {
        this._transformationMatrix = MatrixOperations.TRS(this.Position, this.Rotation, this.Scale);
        this.OnTransformationMatrixUpdated.Invoke();
    }

    public void ChangeMatrixValue(int rowIdx, int colIdx, float value)
    {
        this._transformationMatrix[rowIdx, colIdx] = value;
        this._scale = this._transformationMatrix.ExtractScale();
        this._rotation = this._transformationMatrix.ExtractRotation().eulerAngles;
        this._position = this._transformationMatrix.ExtractPosition();
    }

    public void Reset()
    {
        this._position = Vector3.zero;
        this._rotation = Vector3.zero;
        this._scale = Vector3.one;
        this.UpdateMatrix();
    }

    private void Start()
    {
        this.Reset();
    }

    private void Update()
    {
        // assign your the transformation matrix to the object's transform
        transform.FromMatrix(this.TransformationMatrix);
    }
}
