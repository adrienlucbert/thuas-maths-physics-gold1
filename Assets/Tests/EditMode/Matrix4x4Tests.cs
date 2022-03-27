using NUnit.Framework;

public class Matrix4x4Tests
{
    [Test]
    public void Constructor()
    {
        var m = new GDS.Maths.Matrix4x4();
        Assert.AreEqual(4, m.rows);
        Assert.AreEqual(4, m.columns);
    }

    [Test]
    public void FromRows()
    {
        var m = GDS.Maths.Matrix4x4.FromRows(
            new float[] { 1f, 2f, 3f, 4f },
            new float[] { 5f, 6f, 7f, 8f },
            new float[] { 9f, 10f, 11f, 12f },
            new float[] { 13f, 14f, 15f, 16f });
        Assert.AreEqual(1f, m[0, 0]);
        Assert.AreEqual(2f, m[0, 1]);
        Assert.AreEqual(3f, m[0, 2]);
        Assert.AreEqual(4f, m[0, 3]);
        Assert.AreEqual(5f, m[1, 0]);
        Assert.AreEqual(6f, m[1, 1]);
        Assert.AreEqual(7f, m[1, 2]);
        Assert.AreEqual(8f, m[1, 3]);
        Assert.AreEqual(9f, m[2, 0]);
        Assert.AreEqual(10f, m[2, 1]);
        Assert.AreEqual(11f, m[2, 2]);
        Assert.AreEqual(12f, m[2, 3]);
        Assert.AreEqual(13f, m[3, 0]);
        Assert.AreEqual(14f, m[3, 1]);
        Assert.AreEqual(15f, m[3, 2]);
        Assert.AreEqual(16f, m[3, 3]);
    }

    [Test]
    public void FromColumns()
    {
        var m = GDS.Maths.Matrix4x4.FromColumns(
            new float[] { 1f, 5f, 9f, 13f },
            new float[] { 2f, 6f, 10f, 14f },
            new float[] { 3f, 7f, 11f, 15f },
            new float[] { 4f, 8f, 12f, 16f });
        Assert.AreEqual(1f, m[0, 0]);
        Assert.AreEqual(2f, m[0, 1]);
        Assert.AreEqual(3f, m[0, 2]);
        Assert.AreEqual(4f, m[0, 3]);
        Assert.AreEqual(5f, m[1, 0]);
        Assert.AreEqual(6f, m[1, 1]);
        Assert.AreEqual(7f, m[1, 2]);
        Assert.AreEqual(8f, m[1, 3]);
        Assert.AreEqual(9f, m[2, 0]);
        Assert.AreEqual(10f, m[2, 1]);
        Assert.AreEqual(11f, m[2, 2]);
        Assert.AreEqual(12f, m[2, 3]);
        Assert.AreEqual(13f, m[3, 0]);
        Assert.AreEqual(14f, m[3, 1]);
        Assert.AreEqual(15f, m[3, 2]);
        Assert.AreEqual(16f, m[3, 3]);
    }

    [Test]
    public void TRS()
    {
        var position = new UnityEngine.Vector3(1f, 2f, 3f);
        var rotation = new UnityEngine.Vector3(25f, 35f, -12.5f);
        var scale = new UnityEngine.Vector3(1.2f, 0.8f, 0.6f);
        var gds_trs = GDS.Maths.Matrix4x4.TRS(position, rotation, scale);
        var unity_trs = UnityEngine.Matrix4x4.TRS(
            position,
            UnityEngine.Quaternion.Euler(rotation),
            scale);
        for (int i = 0; i < 4; ++i)
            for (int j = 0; j < 4; ++j)
                Assert.That(gds_trs[i, j], Is.EqualTo(unity_trs[i, j]).Within(0.0000001f));
    }
}
