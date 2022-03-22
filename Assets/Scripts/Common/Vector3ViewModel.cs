using UnityEngine;
using UnityWeld.Binding;

[Binding]
public class Vector3ViewModel : ViewModel
{
    private Vector3 vector;

    [Binding]
    public float x
    {
        get { return this.vector.x; }
        set
        {
            this.vector.x = value;
            this.OnPropertyChanged("x");
        }
    }

    [Binding]
    public float y
    {
        get { return this.vector.y; }
        set
        {
            this.vector.y = value;
            this.OnPropertyChanged("y");
        }
    }

    [Binding]
    public float z
    {
        get { return this.vector.z; }
        set
        {
            this.vector.z = value;
            this.OnPropertyChanged("z");
        }
    }

    [Binding]
    public Vector3 Value
    {
        get { return this.vector; }
        set
        {
            this.x = value.x;
            this.y = value.y;
            this.z = value.z;
            this.OnPropertyChanged("Value");
        }
    }

    Vector3ViewModel(Vector3 value)
    {
        this.Value = value;
    }

    Vector3ViewModel(float x, float y, float z)
    {
        this.Value = new Vector3(x, y, z);
    }
}
