
using UnityEngine;
using UnityEngine.InputSystem;

public class MinePlayerMovement : MonoBehaviour
{
    public float speed = 5.0f;
    public InputAction MoveAction;

    private Vector2 moveInput;
    private Rigidbody2D rb;
    private Animator animator;

    private string currentAnimation = "";
    private string lastDirection = "Down";

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        MoveAction.Enable();
    }

    void Update()
    {
        moveInput = MoveAction.ReadValue<Vector2>().normalized;

        string newAnimation;

        if (moveInput == Vector2.zero)
        {
            newAnimation = "PlayerIdle" + lastDirection;
        }
        else
        {
            if (Mathf.Abs(moveInput.x) > Mathf.Abs(moveInput.y))
            {
                lastDirection = moveInput.x > 0 ? "Right" : "Left";
            }
            else
            {
                lastDirection = moveInput.y > 0 ? "Up" : "Down";
            }

            newAnimation = "PlayerWalk" + lastDirection;
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
