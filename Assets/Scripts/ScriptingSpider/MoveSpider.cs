using UnityEngine;

public class MoveSpider : MonoBehaviour
{
    [SerializeField] private float _speed = 10f;

    private void Start()
    {
       // _characterController = gameObject.GetComponent<CharacterController>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 newPosMove = transform.right * x + -transform.up * z;

        if (Input.GetKey(KeyCode.W))
            MoveForward(newPosMove);
        if (Input.GetKey(KeyCode.S))
            MoveBack(newPosMove);
        if (Input.GetKey(KeyCode.A))
            MoveLeft(newPosMove);
        if (Input.GetKey(KeyCode.D))
            MoveRight(newPosMove);
        //_characterController.Move(newPosMove * _speed * Time.deltaTime);
    }

    private void MoveForward(Vector3 direction) 
    {
        transform.position += direction * _speed * Time.deltaTime;
    }

    private void MoveBack(Vector3 direction)
    {
        transform.position += direction * _speed * Time.deltaTime;
    }

    private void MoveLeft(Vector3 direction)
    {
        transform.position += direction * _speed * Time.deltaTime;
    }

    private void MoveRight(Vector3 direction)
    {
        transform.position += direction * _speed * Time.deltaTime;
    }
}
