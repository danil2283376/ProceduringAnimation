using UnityEngine;

public class MovePointFoot : MonoBehaviour
{
    [SerializeField] private GameObject _prefabCapsule;
    [SerializeField] private Transform _positionFoot;
    [SerializeField] private Transform _bodyPosition;

    private void Start()
    {

    }

    private void Update()
    {
        Move();
    }

    private void Move() 
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 newPosMove = _bodyPosition.right * x + -_bodyPosition.up * z;

        transform.position += newPosMove * Time.deltaTime;
    }
}
