
using UnityEngine;

public class BatPatrol : MonoBehaviour
{
    public float speed = 2f;
    public float patrolDistance = 2f;
    public bool verticalPatrol = false;
    public float detectionRadius = 3f;
    public float chaseSpeed = 3f;

    public float roomHalfWidth = 3f;
    public float roomHalfHeight = 2f;

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
            Vector2.Distance(transform.position, player.position) <= detectionRadius && IsInsideRoom(player.position))
        {
            ChasePlayer();
        }
        else
        {
            Patrol();
        }

        KeepInsideRoom();
    }


    void Patrol()
    {
        float distance;

        if (verticalPatrol)
            distance = transform.position.y - startPosition.y;
        else
            distance = transform.position.x - startPosition.x;

        float maxDistance;

        if (verticalPatrol)
            maxDistance = Mathf.Min(patrolDistance, roomHalfHeight);
        else
            maxDistance = Mathf.Min(patrolDistance, roomHalfWidth);

        if (direction == 1 && distance >= maxDistance)
            direction = -1;
        else if (direction == -1 && distance <= -maxDistance)
            direction = 1;

        Vector3 movement;

        if (verticalPatrol)
            movement = Vector3.up;
        else
            movement = Vector3.right;

        transform.Translate(movement * direction * speed * Time.deltaTime, Space.World);

        if (spriteRenderer != null && !verticalPatrol)
            spriteRenderer.flipX = direction == -1;
    }


    void ChasePlayer()
    {
        Vector3 targetPosition = new Vector3(player.position.x, player.position.y, transform.position.z);
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, chaseSpeed * Time.deltaTime);

        if (spriteRenderer != null)
            spriteRenderer.flipX = player.position.x < transform.position.x;
    }

    bool IsInsideRoom(Vector3 position)
    {
        return position.x >= startPosition.x - roomHalfWidth &&
               position.x <= startPosition.x + roomHalfWidth &&
               position.y >= startPosition.y - roomHalfHeight &&
               position.y <= startPosition.y + roomHalfHeight;
    }

    void KeepInsideRoom()
    {
        Vector3 position = transform.position;

        position.x = Mathf.Clamp(position.x, startPosition.x - roomHalfWidth, startPosition.x + roomHalfWidth);

        position.y = Mathf.Clamp( position.y, startPosition.y - roomHalfHeight, startPosition.y + roomHalfHeight);
        transform.position = position;
    }

    void OnDrawGizmosSelected()
    {
        Vector3 center = Application.isPlaying ? startPosition : transform.position;

        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(center, new Vector3(roomHalfWidth * 2f, roomHalfHeight * 2f, 0f));

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRadius);
    }
}
