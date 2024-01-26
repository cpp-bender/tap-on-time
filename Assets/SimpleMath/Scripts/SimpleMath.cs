using System.Collections.Generic;
using UnityEngine;

public static class SimpleMath
{
    public const float TAU = 2 * Mathf.PI;

    public static Vector3 ClampVector(Vector3 vector3, VectorComponent vectorComponent, float value)
    {
        var dict = new Dictionary<VectorComponent, float>
        {
            {VectorComponent.X, vector3.x },
            {VectorComponent.Y, vector3.y },
            {VectorComponent.Z, vector3.z},
        };

        dict[vectorComponent] = value;

        return new Vector3(dict[VectorComponent.X], dict[VectorComponent.Y], dict[VectorComponent.Z]);
    }

    public static Vector3 ClampVector(Vector3 vector3, VectorComponent[] components, float[] values)
    {
        var dict = new Dictionary<VectorComponent, float>
        {
            {VectorComponent.X, vector3.x },
            {VectorComponent.Y, vector3.y },
            {VectorComponent.Z, vector3.z},
        };

        for (int i = 0; i < dict.Count; i++)
        {
            dict[components[i]] = values[i];
        }

        return new Vector3(dict[VectorComponent.X], dict[VectorComponent.Y], dict[VectorComponent.Z]);
    }

    public static float Remap(float iMin, float iMax, float oMin, float oMax, float v)
    {
        float t = InvLerp(iMin, iMax, v);
        return Lerp(oMin, oMax, t);
    }

    public static float Lerp(float a, float b, float t)
    {
        return (1.0f - t) * a + b * t;
    }

    public static float InvLerp(float a, float b, float v)
    {
        return (v - a) / (b - a);
    }
}