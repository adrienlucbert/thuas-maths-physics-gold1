using NUnit.Framework;

public class MatrixTests
{
    [Test]
    public void Constructor()
    {
        var m = new GDS.Maths.detail.Matrix(3, 5);
        Assert.AreEqual(3, m.rows);
        Assert.AreEqual(5, m.columns);
    }

    [Test]
    public void FromRows()
    {
        var m = GDS.Maths.detail.Matrix.FromRows(
            new float[] { 0f, 1f, 2f },
            new float[] { 3f, 4f, 5f });
        Assert.AreEqual(2, m.rows);
        Assert.AreEqual(3, m.columns);
        Assert.AreEqual(0, m[0, 0]);
        Assert.AreEqual(1, m[0, 1]);
        Assert.AreEqual(2, m[0, 2]);
        Assert.AreEqual(3, m[1, 0]);
        Assert.AreEqual(4, m[1, 1]);
        Assert.AreEqual(5, m[1, 2]);
    }

    [Test]
    public void FromColumns()
    {
        var m = GDS.Maths.detail.Matrix.FromColumns(
            new float[] { 0f, 3f },
            new float[] { 1f, 4f },
            new float[] { 2f, 5f });
        Assert.AreEqual(2, m.rows);
        Assert.AreEqual(3, m.columns);
        Assert.AreEqual(0, m[0, 0]);
        Assert.AreEqual(1, m[0, 1]);
        Assert.AreEqual(2, m[0, 2]);
        Assert.AreEqual(3, m[1, 0]);
        Assert.AreEqual(4, m[1, 1]);
        Assert.AreEqual(5, m[1, 2]);
    }

    [Test]
    public void Copy()
    {
        var m = new GDS.Maths.detail.Matrix(2, 2);
        m[0, 0] = 1; m[0, 1] = 2;
        m[1, 0] = 3; m[1, 1] = 4;
        var m_cpy = m.Copy();
        Assert.AreEqual(1, m_cpy[0, 0]);
        Assert.AreEqual(2, m_cpy[0, 1]);
        Assert.AreEqual(3, m_cpy[1, 0]);
        Assert.AreEqual(4, m_cpy[1, 1]);
    }

    [Test]
    public void Zero()
    {
        var m = GDS.Maths.detail.Matrix.zero(2, 2);
        Assert.AreEqual(0, m[0, 0]);
        Assert.AreEqual(0, m[0, 1]);
        Assert.AreEqual(0, m[1, 0]);
        Assert.AreEqual(0, m[1, 1]);
    }

    [Test]
    public void One()
    {
        var m = GDS.Maths.detail.Matrix.one(2, 2);
        Assert.AreEqual(1, m[0, 0]);
        Assert.AreEqual(1, m[0, 1]);
        Assert.AreEqual(1, m[1, 0]);
        Assert.AreEqual(1, m[1, 1]);
    }

    [Test]
    public void Identity()
    {
        var m = GDS.Maths.detail.Matrix.identity(2);
        Assert.AreEqual(1, m[0, 0]);
        Assert.AreEqual(0, m[0, 1]);
        Assert.AreEqual(0, m[1, 0]);
        Assert.AreEqual(1, m[1, 1]);
    }

    [Test]
    public void Addition()
    {
        var a = new GDS.Maths.detail.Matrix(2, 2);
        a[0, 0] = 1; a[0, 1] = 2;
        a[1, 0] = 3; a[1, 1] = 4;
        var b = new GDS.Maths.detail.Matrix(2, 2);
        b[0, 0] = 5; b[0, 1] = 6;
        b[1, 0] = 7; b[1, 1] = 8;
        var c = a + b;
        Assert.AreEqual(6, c[0, 0]);
        Assert.AreEqual(8, c[0, 1]);
        Assert.AreEqual(10, c[1, 0]);
        Assert.AreEqual(12, c[1, 1]);
    }

    [Test]
    public void Substraction()
    {
        var a = new GDS.Maths.detail.Matrix(2, 2);
        a[0, 0] = 1; a[0, 1] = 2;
        a[1, 0] = 3; a[1, 1] = 4;
        var b = new GDS.Maths.detail.Matrix(2, 2);
        b[0, 0] = 5; b[0, 1] = 6;
        b[1, 0] = 7; b[1, 1] = 8;
        var c = b - a;
        Assert.AreEqual(4, c[0, 0]);
        Assert.AreEqual(4, c[0, 1]);
        Assert.AreEqual(4, c[1, 0]);
        Assert.AreEqual(4, c[1, 1]);
    }

    [Test]
    public void Multiplication()
    {
        var a = new GDS.Maths.detail.Matrix(2, 2);
        a[0, 0] = 1; a[0, 1] = 2;
        a[1, 0] = 3; a[1, 1] = 4;
        var b = new GDS.Maths.detail.Matrix(2, 2);
        b[0, 0] = 5; b[0, 1] = 6;
        b[1, 0] = 7; b[1, 1] = 8;
        var c = a * b;
        Assert.AreEqual(2, c.rows);
        Assert.AreEqual(2, c.columns);
        Assert.AreEqual(19, c[0, 0]);
        Assert.AreEqual(22, c[0, 1]);
        Assert.AreEqual(43, c[1, 0]);
        Assert.AreEqual(50, c[1, 1]);
        var d = b * a;
        Assert.AreEqual(2, d.rows);
        Assert.AreEqual(2, d.columns);
        Assert.AreEqual(23, d[0, 0]);
        Assert.AreEqual(34, d[0, 1]);
        Assert.AreEqual(31, d[1, 0]);
        Assert.AreEqual(46, d[1, 1]);
    }

    [Test]
    public void Equality()
    {
        var a = new GDS.Maths.detail.Matrix(2, 2);
        a[0, 0] = 1; a[0, 1] = 2;
        a[1, 0] = 3; a[1, 1] = 4;
        var a_cpy = a;
        var b = new GDS.Maths.detail.Matrix(2, 2);
        b[0, 0] = 5; b[0, 1] = 6;
        b[1, 0] = 7; b[1, 1] = 8;
        Assert.IsTrue(a == a_cpy);
        Assert.IsFalse(a == b);
        Assert.IsTrue(a.Equals(a_cpy));
        Assert.IsFalse(a.Equals(b));
    }

    [Test]
    public void Difference()
    {
        var a = new GDS.Maths.detail.Matrix(2, 2);
        a[0, 0] = 1; a[0, 1] = 2;
        a[1, 0] = 3; a[1, 1] = 4;
        var a_cpy = a;
        var b = new GDS.Maths.detail.Matrix(2, 2);
        b[0, 0] = 5; b[0, 1] = 6;
        b[1, 0] = 7; b[1, 1] = 8;
        Assert.IsFalse(a != a_cpy);
        Assert.IsTrue(a != b);
    }

    [Test]
    public void Transpose()
    {
        var m = new GDS.Maths.detail.Matrix(2, 2);
        m[0, 0] = 1; m[0, 1] = 2;
        m[1, 0] = 3; m[1, 1] = 4;
        var t = m.transpose;
        Assert.AreEqual(1, t[0, 0]);
        Assert.AreEqual(3, t[0, 1]);
        Assert.AreEqual(2, t[1, 0]);
        Assert.AreEqual(4, t[1, 1]);
    }
}
