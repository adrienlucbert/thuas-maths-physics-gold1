using UnityEngine;

public class CubeController : MonoBehaviour
{
    [SerializeField] private CubeViewModel viewModel;

    private void Start()
    {
        this.viewModel.Reset();
        this.viewModel.IsVisible = true;
    }

    private void Update()
    {
        this.gameObject.GetComponent<Renderer>().enabled = this.viewModel.IsVisible;
        // assign your the transformation matrix to the object's transform
        this.transform.FromMatrix(this.viewModel.Matrix);
    }
}
