using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 4f;
    private Rigidbody2D rb;
    private InputAction moveAction;
    private Vector2 moveInput;
    [SerializeField] private float iceControl = 6f;
    private bool onIce;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        moveAction = InputSystem.actions.FindAction("Player/Move");
    }

    //Lire la direction de l'appui
    private void Update()
    {
        moveInput = moveAction.ReadValue<Vector2>();
    }

    //FixedUpdate donne la vitesse au Rigidbody rb
    private void FixedUpdate()
    {
        rb.linearVelocity = ReglementsGlace.NextVelocity(
            rb.linearVelocity, moveInput, moveSpeed, onIce, iceControl, Time.fixedDeltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ice"))
        {
            onIce = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Ice"))
        {
            onIce = false;
        }
    }
}
