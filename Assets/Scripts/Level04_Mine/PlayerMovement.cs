
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5.0f;
    public InputAction MoveAction;

    private Vector2 moveInput;
    private Rigidbody2D rb;
    private Animator animator;
    private string currentAnimation = "";

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        MoveAction.Enable();
    }

    void Update()
    {
        moveInput = MoveAction.ReadValue<Vector2>();
        moveInput = moveInput.normalized;

        if (moveInput == Vector2.zero)
        {
            animator.speed = 0f;
            return;
        }

        animator.speed = 1f;

        string newAnimation;

        if (Mathf.Abs(moveInput.x) > Mathf.Abs(moveInput.y))
        {
            if (moveInput.x > 0)
                newAnimation = "PlayerWalkRight";
            else
                newAnimation = "PlayerWalkLeft";
        }
        else
        {
            if (moveInput.y > 0)
                newAnimation = "PlayerWalkUp";
            else
                newAnimation = "PlayerWalkDown";
        }

        if (newAnimation != currentAnimation)
        {
            animator.Play(newAnimation, 0, 0f);
            currentAnimation = newAnimation;
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveInput * speed * Time.fixedDeltaTime);
    }

    void OnDisable()
    {
        MoveAction.Disable();
    }
}
