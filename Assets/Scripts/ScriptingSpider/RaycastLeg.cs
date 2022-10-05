using Unity.Burst.CompilerServices;
using UnityEngine;

public class RaycastLeg : MonoBehaviour
{
    [SerializeField] private float _offset = 0.5f;
    [SerializeField] private float _distanceRay = 2f;
    [SerializeField] private float _heightLeg = 0.3f;

    private void FixedUpdate()
    {
        Ray ray = new Ray(transform.position + Vector3.up * _offset, Vector3.down);

        //Debug.Log("transform.position: " + transform.position);
        //Debug.DrawRay(ray.origin, ray.direction, Color.black);
        RaycastHit raycastHit;
        if (Physics.Raycast(ray, out raycastHit, _distanceRay))
        {
            Debug.DrawRay(ray.origin, ray.direction, Color.black);
            Debug.Log(raycastHit.collider.name);
            Debug.Log("ray.hitpoint: " + raycastHit.point);


            Vector3 newPosition = new Vector3(
                transform.position.x,
                    transform.position.y,
                        raycastHit.point.z);
            Vector3 positionRelative = transform.parent.InverseTransformDirection(newPosition);
            Debug.Log("positionRelative: " + positionRelative);
            transform.position = newPosition;//positionRelative;
        }
    }
}
