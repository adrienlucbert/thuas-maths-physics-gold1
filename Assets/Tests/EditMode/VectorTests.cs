using NUnit.Framework;

public class VectorTests
{
    [Test]
    public void DefaultConstructor()
    {
        var v = new GDS.Maths.detail.Vector(3);
        Assert.AreEqual(3, v.size);
    }

    [Test]
    public void AggregateConstructor()
    {
        var v = new GDS.Maths.detail.Vector(1f, 2f, 3f, 4f);
        Assert.AreEqual(4, v.size);
        Assert.AreEqual(1f, v[0]);
        Assert.AreEqual(2f, v[1]);
        Assert.AreEqual(3f, v[2]);
        Assert.AreEqual(4f, v[3]);
    }

    [Test]
    public void Set()
    {
        var v = new GDS.Maths.detail.Vector(1f, 2f);
        v.Set(3f, 4f);
        Assert.AreEqual(2, v.size);
        Assert.AreEqual(3f, v[0]);
        Assert.AreEqual(4f, v[1]);
    }

    [Test]
    public void Copy()
    {
        var v = new GDS.Maths.detail.Vector(1f, 2f);
        var v_cpy = v.Copy();
        Assert.AreEqual(2, v_cpy.size);
        Assert.AreEqual(1f, v_cpy[0]);
        Assert.AreEqual(2f, v_cpy[1]);
    }

    [Test]
    public void Zero()
    {
        var v = GDS.Maths.detail.Vector.zero(2);
        Assert.AreEqual(2, v.size);
        Assert.AreEqual(0f, v[0]);
        Assert.AreEqual(0f, v[1]);
    }

    [Test]
    public void One()
    {
        var v = GDS.Maths.detail.Vector.one(2);
        Assert.AreEqual(2, v.size);
        Assert.AreEqual(1f, v[0]);
        Assert.AreEqual(1f, v[1]);
    }

    [Test]
    public void SqrMagnitude()
    {
        var v = new GDS.Maths.detail.Vector(4f, 3f);
        Assert.AreEqual(25f, v.sqrMagnitude);
    }

    [Test]
    public void Magnitude()
    {
        var v = new GDS.Maths.detail.Vector(4f, 3f);
        Assert.AreEqual(5f, v.magnitude);
    }

    [Test]
    public void Normalized()
    {
        var v = new GDS.Maths.detail.Vector(4f, 3f);
        var normalized = v.normalized;
        Assert.AreEqual(4f / UnityEngine.Mathf.Sqrt(25), normalized[0]);
        Assert.AreEqual(3f / UnityEngine.Mathf.Sqrt(25), normalized[1]);
    }

    [Test]
    public void Distance()
    {
        var a = new GDS.Maths.detail.Vector(1f, 1f);
        var b = new GDS.Maths.detail.Vector(5f, 4f);
        Assert.AreEqual(5f, a.Distance(b));
    }

    [Test]
    public void Addition()
    {
        var a = new GDS.Maths.detail.Vector(2f, 3f);
        var b = new GDS.Maths.detail.Vector(3f, 4f);
        var v = a + b;
        Assert.AreEqual(2, v.size);
        Assert.AreEqual(2f + 3f, v[0]);
        Assert.AreEqual(3f + 4f, v[1]);
    }

    [Test]
    public void Substraction()
    {
        var a = new GDS.Maths.detail.Vector(2f, 3f);
        var b = new GDS.Maths.detail.Vector(3f, 4f);
        var v = a - b;
        Assert.AreEqual(2, v.size);
        Assert.AreEqual(2f - 3f, v[0]);
        Assert.AreEqual(3f - 4f, v[1]);
    }

    [Test]
    public void Multiplication()
    {
        var a = new GDS.Maths.detail.Vector(2f, 3f);
        var b = new GDS.Maths.detail.Vector(3f, 4f);
        var v = a * b;
        Assert.AreEqual(2, v.size);
        Assert.AreEqual(2f * 3f, v[0]);
        Assert.AreEqual(3f * 4f, v[1]);
    }

    [Test]
    public void Division()
    {
        var a = new GDS.Maths.detail.Vector(2f, 3f);
        var b = new GDS.Maths.detail.Vector(3f, 4f);
        var v = a / b;
        Assert.AreEqual(2, v.size);
        Assert.AreEqual(2f / 3f, v[0]);
        Assert.AreEqual(3f / 4f, v[1]);
    }

    [Test]
    public void Equality()
    {
        var a = new GDS.Maths.detail.Vector(2f, 3f);
        var a_cpy = a;
        var b = new GDS.Maths.detail.Vector(3f, 4f);
        Assert.IsTrue(a == a_cpy);
        Assert.IsFalse(a == b);
        Assert.IsTrue(a.Equals(a_cpy));
        Assert.IsFalse(a.Equals(b));
    }

    [Test]
    public void Difference()
    {
        var a = new GDS.Maths.detail.Vector(2f, 3f);
        var a_cpy = a;
        var b = new GDS.Maths.detail.Vector(3f, 4f);
        Assert.IsFalse(a != a_cpy);
        Assert.IsTrue(a != b);
    }
}
