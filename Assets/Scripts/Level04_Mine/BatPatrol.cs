
using UnityEngine;

public class BatPatrol : MonoBehaviour
{
    public float speed = 2f;
    public float patrolDistance = 2f;
    public float detectionRadius = 3f;
    public float chaseSpeed = 3f;

    private Vector3 startPosition;
    private int direction = 1;
    private SpriteRenderer spriteRenderer;
    private Transform player;

    void Start()
    {
        startPosition = transform.position;
        spriteRenderer = GetComponent<SpriteRenderer>();

        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");

        if (playerObject != null)
        {
            player = playerObject.transform;
        }
    }

    void Update()
    {
        if (player != null &&
            Vector2.Distance(transform.position, player.position) <= detectionRadius)
        {
            ChasePlayer();
        }
        else
        {
            Patrol();
        }
    }

    void Patrol()
    {
        float distance = transform.position.x - startPosition.x;

        if (direction == 1 && distance >= patrolDistance)
            direction = -1;
        else if (direction == -1 && distance <= -patrolDistance)
            direction = 1;

        transform.Translate(Vector3.right * direction * speed * Time.deltaTime, Space.World);
        spriteRenderer.flipX = direction == -1;
    }

    void ChasePlayer()
    {
        Vector3 targetPosition = new Vector3(
            player.position.x,
            player.position.y,
            transform.position.z
        );

        transform.position = Vector3.MoveTowards(
            transform.position,
            targetPosition,
            chaseSpeed * Time.deltaTime
        );

        spriteRenderer.flipX = player.position.x < transform.position.x;
    }
}
