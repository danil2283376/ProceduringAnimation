using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class MovePlayer : MonoBehaviour
{
    public delegate void MoveHandler();
    public static event MoveHandler Move;

    public MoveState MoveState { get; private set; } = MoveState.Idle;
    public static bool IsMove { get; private set; } = false;

    [SerializeField] private AnimationCurve _speed;
    [SerializeField] private float _moveSpeed = 5f;

    private Rigidbody _rigidbodyPlayer;


    private void Start()
    {
        _rigidbodyPlayer = gameObject.GetComponent<Rigidbody>();
        
    }

    private void FixedUpdate()
    {
        _rigidbodyPlayer.velocity = Vector3.zero;

        if (Input.GetAxis("Vertical") == 0 
            && Input.GetAxis("Horizontal") == 0)
            SetIdle();

        if (Input.GetKey(KeyCode.W))
            MoveForward();
        if (Input.GetKey(KeyCode.S))
            MoveBack();
        if (Input.GetKey(KeyCode.A))
            MoveLeft();
        if (Input.GetKey(KeyCode.D))
            MoveRight();
    }

    private void MoveForward()
    {
        Vector3 directionForward = new Vector3(transform.forward.x, 0.0f, transform.forward.z);
        _rigidbodyPlayer.AddForce(directionForward * _moveSpeed, ForceMode.Impulse);
        MoveState = MoveState.Move;
        IsMove = true;
    }

    private void MoveBack()
    {
        Vector3 directionBack = new Vector3(-transform.forward.x, 0.0f, -transform.forward.z);
        _rigidbodyPlayer.AddForce(directionBack * _moveSpeed, ForceMode.Impulse);
        MoveState = MoveState.Move;
        IsMove = true;
    }

    private void MoveLeft()
    {
        _rigidbodyPlayer.AddForce(-transform.right * _moveSpeed, ForceMode.Impulse);
        MoveState = MoveState.Move;
        IsMove = true;
    }

    private void MoveRight()
    {
        _rigidbodyPlayer.AddForce(transform.right * _moveSpeed, ForceMode.Impulse);
        MoveState = MoveState.Move;
        IsMove = true;
    }

    private void SetIdle()
    {
        MoveState = MoveState.Idle;
        IsMove = false;
    }

}

public enum MoveState
{
    Idle,
    Move
}