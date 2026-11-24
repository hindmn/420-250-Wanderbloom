using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 4f;
    private Rigidbody2D rb;
    private InputAction moveAction;
    private Vector2 moveInput;

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
        rb.linearVelocity = moveInput * moveSpeed;
    }
}
