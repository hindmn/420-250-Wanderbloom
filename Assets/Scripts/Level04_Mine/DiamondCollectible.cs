
using UnityEngine;

public class DiamondCollectible : MonoBehaviour
{
    public GameObject diamondParticles;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            DiamondCounter counter = FindFirstObjectByType<DiamondCounter>();

            if (counter != null)
            {
                counter.AddDiamond();

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
