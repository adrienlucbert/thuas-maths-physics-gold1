using UnityEngine;

public static class VectorOperations
{
    public static float Magnitude(Vector3 vector)
    {
        return Mathf.Sqrt(Mathf.Pow(vector.x, 2) + Mathf.Pow(vector.y, 2) + Mathf.Pow(vector.z, 2));
    }

    public static Vector3 Normalized(Vector3 vector)
    {
        float magnitude = VectorOperations.Magnitude(vector);
        return new Vector3(vector.x / magnitude, vector.y / magnitude, vector.z / magnitude);
    }
}
