using NUnit.Framework;

public class Vector4Tests
{
    [Test]
    public void DefaultConstructor()
    {
        var v = new GDS.Maths.Vector4();
        Assert.AreEqual(4, v.size);
    }

    [Test]
    public void AggregateConstructor()
    {
        var v = new GDS.Maths.Vector4(1f, 2f, 3f, 4f);
        Assert.AreEqual(4, v.size);
        Assert.AreEqual(1f, v[0]);
        Assert.AreEqual(2f, v[1]);
        Assert.AreEqual(3f, v[2]);
        Assert.AreEqual(4f, v[3]);
    }

    [Test]
    public void X()
    {
        var v = new GDS.Maths.Vector4(1f, 2f, 3f, 4f);
        Assert.AreEqual(1f, v.x);
    }

    [Test]
    public void Y()
    {
        var v = new GDS.Maths.Vector4(1f, 2f, 3f, 4f);
        Assert.AreEqual(2f, v.y);
    }

    [Test]
    public void Z()
    {
        var v = new GDS.Maths.Vector4(1f, 2f, 3f, 4f);
        Assert.AreEqual(3f, v.z);
    }

    [Test]
    public void W()
    {
        var v = new GDS.Maths.Vector4(1f, 2f, 3f, 4f);
        Assert.AreEqual(4f, v.w);
    }

    [Test]
    public void R()
    {
        var v = new GDS.Maths.Vector4(1f, 2f, 3f, 4f);
        Assert.AreEqual(1f, v.r);
    }

    [Test]
    public void G()
    {
        var v = new GDS.Maths.Vector4(1f, 2f, 3f, 4f);
        Assert.AreEqual(2f, v.g);
    }

    [Test]
    public void B()
    {
        var v = new GDS.Maths.Vector4(1f, 2f, 3f, 4f);
        Assert.AreEqual(3f, v.b);
    }

    [Test]
    public void A()
    {
        var v = new GDS.Maths.Vector4(1f, 2f, 3f, 4f);
        Assert.AreEqual(4f, v.a);
    }

    [Test]
    public void ConversionFromUnity()
    {
        GDS.Maths.Vector4 v = (GDS.Maths.Vector4)new UnityEngine.Vector4(1f, 2f, 3f, 4f);
        Assert.AreEqual(new GDS.Maths.Vector4(1f, 2f, 3f, 4f), v);
    }

    [Test]
    public void ConversionToUnity()
    {
        UnityEngine.Vector4 v = (UnityEngine.Vector4)new GDS.Maths.Vector4(1f, 2f, 3f, 4f);
        Assert.AreEqual(new UnityEngine.Vector4(1f, 2f, 3f, 4f), v);
    }
}
