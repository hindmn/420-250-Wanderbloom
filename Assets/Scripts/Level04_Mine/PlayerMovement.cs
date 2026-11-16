
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5.0f;
    public InputAction MoveAction;

    private Vector2 moveInput;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        MoveAction.Enable();
    }

    void Update()
    {
        moveInput = MoveAction.ReadValue<Vector2>();
        moveInput = moveInput.normalized;
    }

    void FixedUpdate()
    {
        rb.MovePosition(
            rb.position + moveInput * speed * Time.fixedDeltaTime
        );
    }

    void OnDisable()
    {
        MoveAction.Disable();
    }
}
