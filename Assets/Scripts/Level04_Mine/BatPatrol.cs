
using UnityEngine;

public class BatPatrol : MonoBehaviour
{
    public float speed = 2f;
    public float patrolDistance = 2f;

    private Vector3 startPosition;
    private int direction = 1;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        startPosition = transform.position;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        float distance = transform.position.x - startPosition.x;

        if (direction == 1 && distance >= patrolDistance)
        {
            direction = -1;
        }
        else if (direction == -1 && distance <= -patrolDistance)
        {
            direction = 1;
        }

        transform.Translate(Vector3.right * direction * speed * Time.deltaTime, Space.World);

        if (spriteRenderer != null)
        {
            spriteRenderer.flipX = direction == -1;
        }
    }
}
