using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeUIProxy : MonoBehaviour
{
    [SerializeField] private CubeController _controller;

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
}
