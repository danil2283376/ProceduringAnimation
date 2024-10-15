using UnityEngine;

public class LegAimGround : MonoBehaviour
{
    public float HeightLeg = 0.02f;

    [SerializeField] private float _distanceRay = 1f;
    [SerializeField] private float _offset = 1f;

    private int layerGround;
    private void Start()
    {
        layerGround = LayerMask.GetMask("Ground");
    }

    private void FixedUdpate()
    {
        Ray ray = new Ray(transform.position + Vector3.up * _offset, Vector3.down);
        //Debug.DrawLine(ray.origin, Vector3.down, Color.white);
        Debug.DrawRay(ray.origin, ray.direction, Color.black);

        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, _distanceRay, layerGround))
        {
            Debug.Log("hit: " + hit.collider.name);
            Debug.DrawRay(ray.origin, ray.direction, Color.black);
            transform.position = hit.point + Vector3.up * HeightLeg;
        }
    }
}
