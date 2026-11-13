using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Arielle
{
    public class TheChickenMovement : MonoBehaviour
    {
        [SerializeField] private Vector2 limiteMin = new Vector2(-10f, -5f);
        [SerializeField] private Vector2 limiteMax = new Vector2(10f, 5f);

        [SerializeField] private float vitesse = 2f;
        [SerializeField] private float pause = 1.5f;
        [SerializeField] private Transform player;

        private Rigidbody2D rb;
        private SpriteRenderer sr;
        private float finPause = 0f;


        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            sr = GetComponent<SpriteRenderer>();
        }


        private void FixedUpdate()
        {
            if(Time.time < finPause)
            {
                rb.linearVelocity = Vector2.zero;
            }

            Vector2 direction = ((Vector2)player.position - rb.position).normalized;
            rb.linearVelocity = direction * vitesse;
            rb.position = Limites.Limiter(rb.position, limiteMin, limiteMax);

            if (direction.x != 0)
            
                sr.flipX = direction.x < 0;
            

        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Player"))
            {
                finPause = Time.time + pause;
            }
        }
    }
}