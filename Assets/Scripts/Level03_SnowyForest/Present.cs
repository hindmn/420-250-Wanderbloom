using UnityEngine;

[RequireComponent(typeof(Animator), typeof(Collider2D))]
[RequireComponent(typeof(AudioSource), typeof(SpriteRenderer))]
public class Present : MonoBehaviour
{
    private Animator animator;
    private Collider2D presentSpace;
    private bool isOpen;
    [SerializeField] private ParticleSystem sparkles;
    [SerializeField] private AudioClip sparklesSound;
    private AudioSource audioSource;
    private SpriteRenderer spriteRenderer;
    //Évenement qui appartient à la classe Present (parent) et le compteur prend en compte tous les cadeaux.
    public static event System.Action Collected;

    private void Awake()
    {
        animator = GetComponent<Animator>();
        presentSpace = GetComponent<Collider2D>();
        audioSource = GetComponent<AudioSource>();
        spriteRenderer = GetComponent<SpriteRenderer>();
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
        PlaySparklesSound();
        Collected?.Invoke();
        //Le ? évite une erreur si le résultat est null et puisque l'appel est après isOpen,
        //le cadeau ne peut compter qu'une seule fois
    }

    private void PlaySparkles()
    {
        sparkles.transform.SetParent(null);
        sparkles.Play();
    }

    private void PlaySparklesSound()
    {
        audioSource.PlayOneShot(sparklesSound);
    }

    public void Disappear()
    {
        spriteRenderer.enabled = false;
        Destroy(gameObject, sparklesSound.length);
    }

}
