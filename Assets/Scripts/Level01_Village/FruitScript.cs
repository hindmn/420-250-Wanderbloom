using UnityEngine;

namespace Arielle
{
    public class FruitScript : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                CompteurFruit compteur = other.GetComponent<CompteurFruit>();
                if (compteur != null)
                    compteur.AjouterFruit();

                //Debug.Log("Fruit ramassé");
                Destroy(gameObject);
            }
        }

    }
}