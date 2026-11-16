
using UnityEngine;

public class DiamondCollectible : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            DiamondCounter counter =
                FindFirstObjectByType<DiamondCounter>();

            if (counter != null)
            {
                counter.AddDiamond();
                Destroy(gameObject);
            }
            else
            {
                Debug.LogWarning("DiamondCounter introuvable !");
            }
        }
    }
}
