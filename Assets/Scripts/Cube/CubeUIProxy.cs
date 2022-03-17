using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CubeUIProxy : MonoBehaviour
{
    [SerializeField] private CubeController _controller;
    [SerializeField] private GameObject _resetUI;
    [SerializeField] private GameObject _transformationUI;
    [SerializeField] private GameObject _rotationUI;
    [SerializeField] private GameObject _matrixUI;
    private static readonly string[] _coordsNames = { "X", "Y", "Z" };

    public void OnTransformValueChanged(int coordIdx, float value)
    {
        var pos = this._controller.Position;
        pos[coordIdx] = value;
        this._controller.Position = pos;
    }

    public void OnRotationValueChanged(int coordIdx, float value)
    {
        var rot = this._controller.Rotation;
        rot[coordIdx] = value;
        this._controller.Rotation = rot;
    }

    private InputField GetMatrixItem(int rowIdx, int colIdx)
    {
        var rowObject = this._matrixUI.transform.Find($"Row{rowIdx}").gameObject;
        var itemObject = rowObject.transform.Find($"Col{colIdx}").gameObject;
        return itemObject.GetComponent<InputField>();
    }

    private void UpdateMatrixUI()
    {
        for (int rowIdx = 0; rowIdx < 4; ++rowIdx)
        {
            var row = this._controller.TransformationMatrix.GetRow(rowIdx);
            for (int colIdx = 0; colIdx < 4; ++colIdx)
            {
                var item = this.GetMatrixItem(rowIdx, colIdx);
                item.SetTextWithoutNotify(row[colIdx].ToString("F2"));
            }
        }
    }

    private void UpdateSlidersFromMatrix()
    {
        Matrix4x4 matrix = this._controller.TransformationMatrix;
        Vector3 rotation = matrix.ExtractRotation().eulerAngles;
        Vector3 position = matrix.ExtractPosition();

        for (int coordIdx = 0; coordIdx < _coordsNames.Length; ++coordIdx)
        {
            var transformSlider = this._transformationUI.transform.Find(_coordsNames[coordIdx]).gameObject.GetComponent<Slider>();
            transformSlider.SetValueWithoutNotify(position[coordIdx]);
            var rotationSlider = this._rotationUI.transform.Find(_coordsNames[coordIdx]).gameObject.GetComponent<Slider>();
            rotationSlider.SetValueWithoutNotify(rotation[coordIdx]);
        }
    }

    private void OnMatrixUIValueChanged(int rowIdx, int colIdx, string value)
    {
        this._controller.ChangeMatrixValue(rowIdx, colIdx, float.Parse(value));
        this.UpdateSlidersFromMatrix();
    }

    private void OnReset()
    {
        this._controller.Reset();
        this.UpdateSlidersFromMatrix();
    }

    public void Start()
    {
        this._controller.OnTransformationMatrixUpdated.AddListener(this.UpdateMatrixUI);

        // Setup UI listeners
        this._resetUI.GetComponent<Button>().onClick.AddListener(this.OnReset);

        for (int coordIdx = 0; coordIdx < _coordsNames.Length; ++coordIdx)
        {
            // Make local copy of coordIdx to prevent the lambda from taking references
            // Otherwise when calling the lambda, index is always max value
            int coordIdxCpy = coordIdx;

            var transformSlider = this._transformationUI.transform.Find(_coordsNames[coordIdx]).gameObject.GetComponent<Slider>();
            transformSlider.onValueChanged.AddListener((float value) => this.OnTransformValueChanged(coordIdxCpy, value));

            var rotationSlider = this._rotationUI.transform.Find(_coordsNames[coordIdx]).gameObject.GetComponent<Slider>();
            rotationSlider.onValueChanged.AddListener((float value) => this.OnRotationValueChanged(coordIdxCpy, value));
        }
        for (int rowIdx = 0; rowIdx < 4; ++rowIdx)
        {
            var row = this._controller.TransformationMatrix.GetRow(rowIdx);
            for (int colIdx = 0; colIdx < 4; ++colIdx)
            {
                var item = this.GetMatrixItem(rowIdx, colIdx);
                // Local copy of indices, same reason as above
                var rowIdxCpy = rowIdx;
                var colIdxCpy = colIdx;
                item.onEndEdit.AddListener((string value) => this.OnMatrixUIValueChanged(rowIdxCpy, colIdxCpy, value));
            }
        }
    }
}
