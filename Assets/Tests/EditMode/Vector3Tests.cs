using NUnit.Framework;

public class Vector3Tests
{
    [Test]
    public void DefaultConstructor()
    {
        var v = new GDS.Maths.Vector3();
        Assert.AreEqual(3, v.size);
    }

    [Test]
    public void AggregateConstructor()
    {
        var v = new GDS.Maths.Vector3(1f, 2f, 3f);
        Assert.AreEqual(3, v.size);
        Assert.AreEqual(1f, v[0]);
        Assert.AreEqual(2f, v[1]);
        Assert.AreEqual(3f, v[2]);
    }

    [Test]
    public void X()
    {
        var v = new GDS.Maths.Vector3(1f, 2f, 3f);
        Assert.AreEqual(1f, v.x);
    }

    [Test]
    public void Y()
    {
        var v = new GDS.Maths.Vector3(1f, 2f, 3f);
        Assert.AreEqual(2f, v.y);
    }

    [Test]
    public void Z()
    {
        var v = new GDS.Maths.Vector3(1f, 2f, 3f);
        Assert.AreEqual(3f, v.z);
    }

    [Test]
    public void R()
    {
        var v = new GDS.Maths.Vector3(1f, 2f, 3f);
        Assert.AreEqual(1f, v.r);
    }

    [Test]
    public void G()
    {
        var v = new GDS.Maths.Vector3(1f, 2f, 3f);
        Assert.AreEqual(2f, v.g);
    }

    [Test]
    public void B()
    {
        var v = new GDS.Maths.Vector3(1f, 2f, 3f);
        Assert.AreEqual(3f, v.b);
    }

    [Test]
    public void Left()
    {
        var v = GDS.Maths.Vector3.left;
        Assert.AreEqual(new GDS.Maths.Vector3(-1f, 0f, 0f), v);
    }

    [Test]
    public void Right()
    {
        var v = GDS.Maths.Vector3.right;
        Assert.AreEqual(new GDS.Maths.Vector3(1f, 0f, 0f), v);
    }

    [Test]
    public void Down()
    {
        var v = GDS.Maths.Vector3.down;
        Assert.AreEqual(new GDS.Maths.Vector3(0f, -1f, 0f), v);
    }

    [Test]
    public void Up()
    {
        var v = GDS.Maths.Vector3.up;
        Assert.AreEqual(new GDS.Maths.Vector3(0f, 1f, 0f), v);
    }

    [Test]
    public void Back()
    {
        var v = GDS.Maths.Vector3.back;
        Assert.AreEqual(new GDS.Maths.Vector3(0f, 0f, -1f), v);
    }

    [Test]
    public void Forward()
    {
        var v = GDS.Maths.Vector3.forward;
        Assert.AreEqual(new GDS.Maths.Vector3(0f, 0f, 1f), v);
    }

    [Test]
    public void ConversionFromUnity()
    {
        GDS.Maths.Vector3 v = (GDS.Maths.Vector3)new UnityEngine.Vector3(1f, 2f, 3f);
        Assert.AreEqual(new GDS.Maths.Vector3(1f, 2f, 3f), v);
    }

    [Test]
    public void ConversionToUnity()
    {
        UnityEngine.Vector3 v = (UnityEngine.Vector3)new GDS.Maths.Vector3(1f, 2f, 3f);
        Assert.AreEqual(new UnityEngine.Vector3(1f, 2f, 3f), v);
    }
}
