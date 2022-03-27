using System.ComponentModel;
using UnityEngine;
using UnityWeld.Binding;

[Binding]
public class CubeViewModel : ViewModel
{
    [SerializeField] private Vector3ViewModel positionViewModel;
    [SerializeField] private Vector3ViewModel rotationViewModel;
    [SerializeField] private Vector3ViewModel scaleViewModel;
    [SerializeField] private Matrix4x4ViewModel matrixViewModel;
    private bool watchMatrix = false;
    private bool watchSliders = false;
    private bool isVisible = false;

    public Vector3 Position
    {
        get { return this.positionViewModel.Value; }
        private set { this.positionViewModel.Value = value; }
    }
    public Vector3 Rotation
    {
        get { return this.rotationViewModel.Value; }
        private set { this.rotationViewModel.Value = value; }
    }
    public Vector3 Scale
    {
        get { return this.scaleViewModel.Value; }
        private set { this.scaleViewModel.Value = value; }
    }
    public Matrix4x4 Matrix
    {
        get { return this.matrixViewModel.Value; }
        private set { this.matrixViewModel.Value = value; }
    }

    private void WatchSliders()
    { this.watchSliders = true; }
    private void UnwatchSliders()
    { this.watchSliders = false; }

    private void WatchMatrix()
    { this.watchMatrix = true; }
    private void UnwatchMatrix()
    { this.watchMatrix = false; }

    [Binding]
    public bool IsVisible
    {
        get { return this.isVisible; }
        set
        {
            this.isVisible = value;
            this.OnPropertyChanged("IsVisible");
        }
    }

    [Binding]
    public void Reset()
    {
        this.UnwatchMatrix();
        this.UnwatchSliders();
        this.Position = Vector3.zero;
        this.Rotation = Vector3.zero;
        this.Scale = Vector3.one;
        this.UpdateMatrix();
        this.WatchSliders();
        this.WatchMatrix();
    }

    private void UpdateMatrix()
    {
        this.UnwatchMatrix();
        this.Matrix = MatrixOperations.TRS(this.Position, this.Rotation, this.Scale);
        this.WatchMatrix();
    }

    private void UpdateSliders()
    {
        this.UnwatchSliders();
        this.Position = this.Matrix.ExtractPosition();
        this.Rotation = this.Matrix.ExtractRotation().eulerAngles;
        this.Scale = this.Matrix.ExtractScale();
        this.WatchSliders();
    }

    private void OnSliderChanged(object sender, PropertyChangedEventArgs e)
    {
        if (!this.watchSliders)
            return;
        this.UpdateMatrix();
    }

    private void OnMatrixChanged(object sender, PropertyChangedEventArgs e)
    {
        if (!this.watchMatrix)
            return;
        this.UpdateSliders();
    }

    public void Start()
    {
        this.positionViewModel.PropertyChanged += this.OnSliderChanged;
        this.rotationViewModel.PropertyChanged += this.OnSliderChanged;
        this.scaleViewModel.PropertyChanged += this.OnSliderChanged;
        this.matrixViewModel.PropertyChanged += this.OnMatrixChanged;
    }
}
