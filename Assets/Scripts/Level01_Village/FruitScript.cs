using UnityEngine;

namespace Arielle
{
    public class FruitScript : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                Debug.Log("Fruit ramassé");
                Destroy(gameObject);
            }
        }

    }
}