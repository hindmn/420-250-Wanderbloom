
using UnityEngine;

public class DiamondCollectible : MonoBehaviour
{
    public GameObject diamondParticles;
    public AudioClip collectionSound;

    [Range(0f, 1f)]
    public float soundVolume = 0.7f;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            DiamondCounter counter = FindFirstObjectByType<DiamondCounter>();

            if (counter != null)
            {
                counter.AddDiamond();

                if (collectionSound != null)
                {
                    AudioSource.PlayClipAtPoint(
                        collectionSound,
                        transform.position,
                        soundVolume
                    );
                }

                if (diamondParticles != null)
                {
                    GameObject effect = Instantiate(
                        diamondParticles,
                        transform.position,
                        Quaternion.identity
                    );

                    Destroy(effect, 0.4f);
                }
                Destroy(gameObject);
            }
        }
    }
}
