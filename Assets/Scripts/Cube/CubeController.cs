using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;
using UnityEngine.UI;

public class CubeController : MonoBehaviour
{
    [SerializeField] private CubeViewModel viewModel;

    private void Start()
    {
        this.viewModel.Reset();
    }

    private void Update()
    {
        // assign your the transformation matrix to the object's transform
        this.transform.FromMatrix(this.viewModel.Matrix);
    }
}
