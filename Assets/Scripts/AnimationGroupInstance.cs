using System.Linq;
using Unity.VisualScripting;
using UnityEngine;

public class AnimationGroupInstance
{
    private readonly Transform target;
    private readonly AnimationInstance[] instances;
    private readonly Vector3 originalPosition;
    private readonly Vector3 originalRotation;

    public AnimationGroupInstance(Transform target, ObjectProceduralAnimationGroup animation)
    {
        this.target = target;
        this.originalPosition = target.localPosition;
        this.originalRotation = target.eulerAngles;
        this.instances = animation.Animations.Select(a => new AnimationInstance(a)).ToArray();
    }

    public void Update(float t) 
    {
        Vector3 currentOffset = Vector3.zero;
        Vector3 currentRotation = Vector3.zero;

        foreach (AnimationInstance animationInstance in instances)
        {
            animationInstance.Update(t, ref currentOffset, ref currentRotation);
        }
        target.localPosition = originalPosition + currentOffset;
        target.localRotation = Quaternion.Euler(originalRotation + currentRotation);
    }
}
