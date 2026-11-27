using UnityEngine;

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
        private AudioSource audioSource;
        private float finPause = 0f;

        private bool EstEnPause => Time.time < finPause;


        private void Awake()
        {
            rb = GetComponent<Rigidbody2D>();
            sr = GetComponent<SpriteRenderer>();
            animator = GetComponent<Animator>();
            audioSource = GetComponent<AudioSource>();
        }


        private void FixedUpdate()
        {
            if (EstEnPause)
                Arreter();
            else
                PoursuivreJoueur();
        }

        private void Arreter()
        {
            rb.linearVelocity = Vector2.zero;
            animator.SetBool("EnMarche", false);
        }

        public void PoursuivreJoueur()
        {
            Vector2 direction = ((Vector2)player.position - rb.position).normalized;
            rb.linearVelocity = direction * vitesse;
            rb.position = Limites.Limiter(rb.position, limiteMin, limiteMax);
            animator.SetBool("EnMarche", true);

            if (direction.x != 0)
                sr.flipX = direction.x < 0;
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            CompteurFruit compteur = collision.gameObject.GetComponentInParent<CompteurFruit>();
            if (compteur == null || EstEnPause) return;

            VolerFruit(compteur, collision.GetContact(0).point);
        }

        public void VolerFruit(CompteurFruit compteur, Vector2 pointContact)
        {
            compteur.RetirerFruit();
            audioSource.PlayOneShot(sonVol);
            Instantiate(effetNuage, pointContact, Quaternion.identity);
            finPause = Time.time + pause;
        }
    }
}
