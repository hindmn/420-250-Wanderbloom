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

        [SerializeField] private AudioClip sonVol;
        [SerializeField] private GameObject effetNuage;
        [SerializeField] private Transform player;

        private Rigidbody2D rb;
        private SpriteRenderer sr;
        private Animator animator;
        private float finPause = 0f;


        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            sr = GetComponent<SpriteRenderer>();
            animator = GetComponent<Animator>();
        }


        private void FixedUpdate()
        {
            if(Time.time < finPause)
            {
                rb.linearVelocity = Vector2.zero;
                animator.SetBool("EnMarche", false);
                return;
            }

            Vector2 direction = ((Vector2)player.position - rb.position).normalized;
            rb.linearVelocity = direction * vitesse;
            rb.position = Limites.Limiter(rb.position, limiteMin, limiteMax);
            animator.SetBool("EnMarche", true);

            if (direction.x != 0)
                sr.flipX = direction.x < 0;
            

        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            Debug.Log("La poule touche : " + collision.gameObject.name);

            // Cherche le compteur sur l'objet touché ou sur son parent
            CompteurFruit compteur = collision.gameObject.GetComponentInParent<CompteurFruit>();
            if (compteur == null) return;

            // Déjà en pause : elle ne peut pas voler de nouveau
            if (Time.time < finPause) return;

            compteur.RetirerFruit();
            GetComponent<AudioSource>().PlayOneShot(sonVol);
            Instantiate(effetNuage, collision.GetContact(0).point, Quaternion.identity);
            Debug.Log("Fruit volé ! Il reste : " + compteur.Nombre);

            finPause = Time.time + pause;

        }
    }
}