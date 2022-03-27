using UnityEngine;

public class RefCubeController : MonoBehaviour
{
    [SerializeField] private CubeViewModel cubeViewModel;
    [SerializeField] private RefCubeViewModel viewModel;

    private void Update()
    {
        this.gameObject.GetComponent<Renderer>().enabled = this.viewModel.IsVisible;

        this.transform.position = this.cubeViewModel.Position;
        this.transform.rotation = Quaternion.Euler(this.cubeViewModel.Rotation);
        this.transform.localScale = this.cubeViewModel.Scale;
    }
}
