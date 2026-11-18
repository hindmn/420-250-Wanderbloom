using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(SpriteRenderer))]
public class ChickenActions : MonoBehaviour
{
    [SerializeField] private Transform startPosition;
    [SerializeField] private Transform endPosition;
    [SerializeField] private float speed = 2f;

    public static event System.Action PlayerIsTouched;
    private Rigidbody2D rb;
    private SpriteRenderer spriteRenderer;
    private Vector2 position0;
    private Vector2 position1;
    private Vector2 targetPosition;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        position0 = startPosition.position;
        position1 = endPosition.position;
        rb.position = position0;
        targetPosition = position1;
    }

    private void FixedUpdate()
    {
        Vector2 nextPosition = Vector2.MoveTowards(rb.position, targetPosition, speed * Time.fixedDeltaTime);
        Turn();
        rb.MovePosition(nextPosition);
        if(Vector2.Distance(nextPosition, targetPosition) < 0.01f) { ChangePosition(); }
    }
    private void Turn()
    {
        if(targetPosition.x != rb.position.x)
        {
            spriteRenderer.flipX = targetPosition.x < rb.position.x;
        }
    }
    private void ChangePosition()
    {
        if(targetPosition == position0)
        {
            targetPosition = position1;
        }else
        {
            targetPosition = position0;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerIsTouched?.Invoke();
        }
    }
}
