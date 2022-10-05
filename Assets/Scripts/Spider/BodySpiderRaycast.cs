using UnityEngine;
using UnityEngine.UIElements;

public class BodySpiderRaycast : MonoBehaviour
{
    [SerializeField] private float _distanceRay = 1;
    [SerializeField] private float _offset = 1f;
    [SerializeField] private float _speed = 1f;
    [SerializeField] private float _heightBody = 2f;

    private Rigidbody body;

    private void Start()
    {
        body = gameObject.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        Ray ray = new Ray(transform.position + Vector3.up * _offset, Vector3.down);

        RaycastHit hit;

        Debug.DrawRay(ray.origin, ray.direction, Color.red);

        if (Physics.Raycast(ray, out hit, _distanceRay))
        {
            Debug.Log(hit.collider.name);
            Debug.DrawRay(ray.origin, ray.direction * hit.distance, Color.red);
            Debug.Log(hit.collider.name);

            Debug.Log("hit.point: " + hit.point);

            //transform.position = Vector3.Lerp(
            //    transform.position,
            //        hit.point,
            //            _speed * Time.deltaTime
            //    );
            transform.position = hit.point;
            //transform.position = transform.position + newPosition;
        }
    }

    private void RotateBody() 
    {

    }
}
