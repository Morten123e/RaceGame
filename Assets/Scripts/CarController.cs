using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

public class CarController : MonoBehaviour
{



    InputAction Move;
    Rigidbody rigidbody;
    Vector2 Control;

    [SerializeField] private float moveSpeed = 10f;
    [SerializeField] private float turnSpeed = 100f;
    [SerializeField] private float acceleration = 10f;
    [SerializeField] private float currentSpeed;

    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        Move = InputSystem.actions.FindAction("Move");
    }

    void Update()
    {
        Control = Move.ReadValue<Vector2>();
    }

    void FixedUpdate()
    {
        Vector3 move = transform.forward * currentSpeed * Time.fixedDeltaTime;
        Quaternion turn = Quaternion.Euler(0f, Control.x * currentSpeed / moveSpeed * turnSpeed * Time.fixedDeltaTime, 0f);
        rigidbody.MovePosition(rigidbody.position + move);
        rigidbody.MoveRotation(rigidbody.rotation * turn);
        currentSpeed = Mathf.MoveTowards(currentSpeed, Control.y * moveSpeed, acceleration * Time.fixedDeltaTime);
    }
}
