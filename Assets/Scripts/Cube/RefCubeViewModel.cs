using UnityWeld.Binding;

[Binding]
public class RefCubeViewModel : ViewModel
{
    private bool isVisible = false;

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

}
