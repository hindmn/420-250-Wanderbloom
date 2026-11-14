using UnityEngine;

[RequireComponent(typeof(Animator), typeof(Collider2D))]
public class Present : MonoBehaviour
{
    private Animator animator;
    private Collider2D presentSpace;
    private bool isOpen;
    [SerializeField] private ParticleSystem sparkles;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        presentSpace = GetComponent<Collider2D>();
    }

    //Éviter de répéter l'effet à chaque collision (Piège dans le guide 17)
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isOpen || !collision.CompareTag("Player"))
        {
            return;
        }
        isOpen = true;
        presentSpace.enabled = false;
        animator.SetTrigger("Open");
        PlaySparkles();
    }

    private void PlaySparkles()
    {
        sparkles.transform.SetParent(null);
        sparkles.Play();
    }

    public void Disappear()
    {
        Destroy(gameObject);
    }

}
