using NUnit.Framework;

public class Vector2Tests
{
    [Test]
    public void DefaultConstructor()
    {
        var v = new GDS.Maths.Vector2();
        Assert.AreEqual(2, v.size);
    }

    [Test]
    public void AggregateConstructor()
    {
        var v = new GDS.Maths.Vector2(1f, 2f);
        Assert.AreEqual(2, v.size);
        Assert.AreEqual(1f, v[0]);
        Assert.AreEqual(2f, v[1]);
    }

    [Test]
    public void X()
    {
        var v = new GDS.Maths.Vector2(1f, 2f);
        Assert.AreEqual(1f, v.x);
    }

    [Test]
    public void Y()
    {
        var v = new GDS.Maths.Vector2(1f, 2f);
        Assert.AreEqual(2f, v.y);
    }

    [Test]
    public void Left()
    {
        var v = GDS.Maths.Vector2.left;
        Assert.AreEqual(new GDS.Maths.Vector2(-1f, 0f), v);
    }

    [Test]
    public void Right()
    {
        var v = GDS.Maths.Vector2.right;
        Assert.AreEqual(new GDS.Maths.Vector2(1f, 0f), v);
    }

    [Test]
    public void Down()
    {
        var v = GDS.Maths.Vector2.down;
        Assert.AreEqual(new GDS.Maths.Vector2(0f, -1f), v);
    }

    [Test]
    public void Up()
    {
        var v = GDS.Maths.Vector2.up;
        Assert.AreEqual(new GDS.Maths.Vector2(0f, 1f), v);
    }

    [Test]
    public void ConversionFromUnity()
    {
        GDS.Maths.Vector2 v = (GDS.Maths.Vector2)new UnityEngine.Vector2(1f, 2f);
        Assert.AreEqual(new GDS.Maths.Vector2(1f, 2f), v);
    }

    [Test]
    public void ConversionToUnity()
    {
        UnityEngine.Vector2 v = (UnityEngine.Vector2)new GDS.Maths.Vector2(1f, 2f);
        Assert.AreEqual(new UnityEngine.Vector2(1f, 2f), v);
    }
}
