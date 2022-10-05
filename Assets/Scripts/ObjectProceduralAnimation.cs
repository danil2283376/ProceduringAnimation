using System;
using UnityEngine;

[Serializable]
public class ObjectProceduralAnimation
{
    public PropertyType PropertyType;
    public float TimeOffset = 0f;
    public float Scale;
    public AnimationCurve Curve;

    public float Evaluate(float normalizedTime) 
    {
        return Curve.Evaluate((normalizedTime + TimeOffset) % 1) * Scale;
    }
}

public enum PropertyType 
{
    LocalTransformX,
    LocalTransformY,
    LocalTransformZ,
    LocalRotationX,
    LocalRotationY,
    LocalRotationZ,
}