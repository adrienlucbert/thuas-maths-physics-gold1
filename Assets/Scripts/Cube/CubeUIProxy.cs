using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class CubeUIProxy : MonoBehaviour
{
    [SerializeField] private CubeController _controller;
    [SerializeField] private GameObject _matrixUI;

    public void OnTransformXChange(float value)
    {
        var pos = this._controller.Position;
        pos.x = value;
        this._controller.Position = pos;
    }

    public void OnTransformYChange(float value)
    {
        var pos = this._controller.Position;
        pos.y = value;
        this._controller.Position = pos;
    }

    public void OnTransformZChange(float value)
    {
        var pos = this._controller.Position;
        pos.z = value;
        this._controller.Position = pos;
    }

    public void OnRotationXChange(float value)
    {
        var rot = this._controller.Rotation;
        rot.x = value;
        this._controller.Rotation = rot;
    }

    public void OnRotationYChange(float value)
    {
        var rot = this._controller.Rotation;
        rot.y = value;
        this._controller.Rotation = rot;
    }

    public void OnRotationZChange(float value)
    {
        var rot = this._controller.Rotation;
        rot.z = value;
        this._controller.Rotation = rot;
    }

    private GameObject GetMatrixItem(int rowIdx, int colIdx)
    {
        var rowObject = this._matrixUI.transform.Find($"Row{rowIdx}").gameObject;
        var itemObject = rowObject.transform.Find($"Col{colIdx}").gameObject;
        return itemObject;
    }

    public void UpdateTransformationMatrixUI()
    {
        for (int rowIdx = 0; rowIdx < 4; ++rowIdx)
        {
            var row = this._controller.TransformationMatrix.GetRow(rowIdx);
            for (int colIdx = 0; colIdx < 4; ++colIdx)
            {
                var itemObject = this.GetMatrixItem(rowIdx, colIdx);
                var itemPlaceholder = itemObject.transform.Find("Placeholder").GetComponent<UnityEngine.UI.Text>();
                var itemText = itemObject.GetComponent<UnityEngine.UI.InputField>();
                itemPlaceholder.text = row[colIdx].ToString("F2");
                itemText.text = row[colIdx].ToString("F2");
            }
        }
    }

    public void Start()
    {
        this._controller.OnTransformationMatrixUpdated += this.UpdateTransformationMatrixUI;
    }
}
