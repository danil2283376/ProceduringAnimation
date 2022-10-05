using UnityEngine;

public class ProceduralAnimation : MonoBehaviour
{
    [SerializeField] private float loopTime = 1;
    [SerializeField] private ProceduralAnimationDefinition animation;

    private AnimationGroupInstance[] groups;
    private void Awake()
    {
        var tmp = UnityEngine.Pool.ListPool<AnimationGroupInstance>.Get();

        foreach (ObjectProceduralAnimationGroup group in animation.Groups)
        {
            string[] pathElements = group.TargetPath.Split("\\");
            //Debug.Log("pathElement: " + pathElements[1]);
            Transform target = transform;
            foreach (string pathElement in pathElements)
            {
                target = target.Find(pathElement);
                //Debug.Log("target: " + target);
                if (target == null)
                    break;
            }
            if (target != null)
                tmp.Add(new AnimationGroupInstance(target, group));

            groups = tmp.ToArray();
        }

        UnityEngine.Pool.ListPool<AnimationGroupInstance>.Release(tmp);
    }

    private void LateUpdate()
    {
        float t = (Time.time % loopTime) / loopTime;
        foreach (AnimationGroupInstance groupInstance in groups)
        {
            groupInstance.Update(t);
        }
    }
}
