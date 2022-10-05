using UnityEditor;
using UnityEngine;

public class BodyRaycast : MonoBehaviour
{
    //[SerializeField] private int _distanceRay = 4;
    //[SerializeField] private float _offset = 1f;
    //[SerializeField] private float _speed = 1f;

    //private Rigidbody body;

    //private void Start()
    //{
    //    body = gameObject.GetComponent<Rigidbody>();
    //}

    //private void FixedUpdate()
    //{
    //    Ray ray = new Ray(transform.position + _offset * Vector3.down, Vector3.down);

    //    RaycastHit hit;

    //    if (Physics.Raycast(ray, out hit, _distanceRay))
    //    {
    //        //Debug.DrawRay(ray.origin, ray.direction * hit.distance, Color.red);
    //        //Debug.Log(hit.collider.name);
    //        body.position = Vector3.Lerp(
    //            body.position,
    //                hit.point,
    //                    _speed * Time.deltaTime
    //            );
    //    }
    //}
//}






























[SerializeField] private float raycastOffset = 1;
[SerializeField] private float distance;
[SerializeField] private float moveSpeed = 1;

private Transform transform;
private Rigidbody rigidbody;

private void Start()
{
    transform = base.transform;
    rigidbody = GetComponent<Rigidbody>();
}

private void FixedUpdate()
{
    var transformUp = transform.up;
    var ray = new Ray(transform.position + raycastOffset * transformUp, -transformUp);
    if (Physics.Raycast(ray, out var hit, raycastOffset + distance))
    {
        //Debug.Log(hit.collider.name);
        //Debug.DrawLine(ray.origin, hit.point, Color.black);
        rigidbody.position = Vector3.Lerp(
            rigidbody.position,
            hit.point + transformUp * distance,
            moveSpeed * Time.deltaTime);
        var rigidbodyVelocity = rigidbody.velocity;
        rigidbodyVelocity.y = 0;
        rigidbody.velocity = rigidbodyVelocity;
    }
}
}
