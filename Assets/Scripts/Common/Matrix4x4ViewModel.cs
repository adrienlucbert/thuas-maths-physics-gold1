using UnityEngine;
using UnityWeld.Binding;

[Binding]
public class Matrix4x4ViewModel : ViewModel
{
    private Matrix4x4 matrix;

    [Binding]
    public float m00
    {
        get { return this.matrix.m00; }
        set
        {
            this.matrix.m00 = value;
            this.OnPropertyChanged("m00");
        }
    }

    [Binding]
    public float m01
    {
        get { return this.matrix.m01; }
        set
        {
            this.matrix.m01 = value;
            this.OnPropertyChanged("m01");
        }
    }

    [Binding]
    public float m02
    {
        get { return this.matrix.m02; }
        set
        {
            this.matrix.m02 = value;
            this.OnPropertyChanged("m02");
        }
    }

    [Binding]
    public float m03
    {
        get { return this.matrix.m03; }
        set
        {
            this.matrix.m03 = value;
            this.OnPropertyChanged("m03");
        }
    }

    [Binding]
    public float m10
    {
        get { return this.matrix.m10; }
        set
        {
            this.matrix.m10 = value;
            this.OnPropertyChanged("m10");
        }
    }

    [Binding]
    public float m11
    {
        get { return this.matrix.m11; }
        set
        {
            this.matrix.m11 = value;
            this.OnPropertyChanged("m11");
        }
    }

    [Binding]
    public float m12
    {
        get { return this.matrix.m12; }
        set
        {
            this.matrix.m12 = value;
            this.OnPropertyChanged("m12");
        }
    }

    [Binding]
    public float m13
    {
        get { return this.matrix.m13; }
        set
        {
            this.matrix.m13 = value;
            this.OnPropertyChanged("m13");
        }
    }

    [Binding]
    public float m20
    {
        get { return this.matrix.m20; }
        set
        {
            this.matrix.m20 = value;
            this.OnPropertyChanged("m20");
        }
    }

    [Binding]
    public float m21
    {
        get { return this.matrix.m21; }
        set
        {
            this.matrix.m21 = value;
            this.OnPropertyChanged("m21");
        }
    }

    [Binding]
    public float m22
    {
        get { return this.matrix.m22; }
        set
        {
            this.matrix.m22 = value;
            this.OnPropertyChanged("m22");
        }
    }

    [Binding]
    public float m23
    {
        get { return this.matrix.m23; }
        set
        {
            this.matrix.m23 = value;
            this.OnPropertyChanged("m23");
        }
    }

    [Binding]
    public float m30
    {
        get { return this.matrix.m30; }
        set
        {
            this.matrix.m30 = value;
            this.OnPropertyChanged("m30");
        }
    }

    [Binding]
    public float m31
    {
        get { return this.matrix.m31; }
        set
        {
            this.matrix.m31 = value;
            this.OnPropertyChanged("m31");
        }
    }

    [Binding]
    public float m32
    {
        get { return this.matrix.m32; }
        set
        {
            this.matrix.m32 = value;
            this.OnPropertyChanged("m32");
        }
    }

    [Binding]
    public float m33
    {
        get { return this.matrix.m33; }
        set
        {
            this.matrix.m33 = value;
            this.OnPropertyChanged("m33");
        }
    }

    [Binding]
    public Matrix4x4 Value
    {
        get { return this.matrix; }
        set
        {
            this.m00 = value.m00;
            this.m01 = value.m01;
            this.m02 = value.m02;
            this.m03 = value.m03;
            this.m10 = value.m10;
            this.m11 = value.m11;
            this.m12 = value.m12;
            this.m13 = value.m13;
            this.m20 = value.m20;
            this.m21 = value.m21;
            this.m22 = value.m22;
            this.m23 = value.m23;
            this.m30 = value.m30;
            this.m31 = value.m31;
            this.m32 = value.m32;
            this.m33 = value.m33;
            this.OnPropertyChanged("Value");
        }
    }

    Matrix4x4ViewModel(Matrix4x4 value)
    {
        this.Value = value;
    }
}
