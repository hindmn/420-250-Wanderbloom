using UnityEngine;

namespace Arielle
{

    public class FruitSpawner : MonoBehaviour
    {

        [SerializeField] private GameObject[] prefabsFruits;
        //[SerializeField] private int nombreFruits = 14;
        [SerializeField] private int nombreTotal = 15;
        [SerializeField] private int nombreAuDepart = 3;
        [SerializeField] private float intervalle = 4f;

        private int nombreApparus = 0;
        private float prochainFruit = 0f;
        [SerializeField] private Vector2 zoneMin = new Vector2(-9f, -4f);
        [SerializeField] private Vector2 zoneMax = new Vector2(9f, 4f);
        [SerializeField] private float rayonLibre = 0.5f;
        [SerializeField] private int essaisMax = 30;

        private void Start()
        {

            for (int i = 0; i < nombreAuDepart; i++)
            {
                FaireApparaitreUnFruit();
            }

            prochainFruit = Time.time + intervalle;
        }


        private void Update()
        {
            if (nombreApparus >= nombreTotal) return;

            if (Time.time >= prochainFruit)
            {
                FaireApparaitreUnFruit();
                prochainFruit = Time.time + intervalle;
            }
        }



        private void FaireApparaitreUnFruit()
        {
            for(int essai = 0; essai < essaisMax; essai++)
            {
                //Choix d'une position random
                Vector2 position = new Vector2(
                    Random.Range(zoneMin.x, zoneMax.x),
                    Random.Range(zoneMin.y, zoneMax.y)
                );

                Collider2D obstacle = Physics2D.OverlapCircle(position, rayonLibre);
                if (obstacle != null)
                {
                    Debug.Log("Place occupée par : " + obstacle.name);
                }
                else
                {
                    GameObject prefab = prefabsFruits[Random.Range(0, prefabsFruits.Length)];
                    Instantiate(prefab, position, Quaternion.identity, transform);
                    nombreApparus++;
                    return;
                }
            }
            Debug.LogWarning("Pas de place libre pour un fruit");
        }

        //POur dessiner la zone d'apparition dans la vus Scene
        private void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.green;
            Vector2 centre = (zoneMin + zoneMax) / 2f;
            Vector2 taille = zoneMax - zoneMin;
            Gizmos.DrawWireCube(centre, taille);

        }



    }
}