using UnityEngine;

namespace Arielle
{
    public class PanneauDebutA : MonoBehaviour
    {
        [SerializeField] private GameObject panneau;

        private void Start()
        {
            panneau.SetActive(true);
            Time.timeScale = 0f; 
        }

        public void Jouer()
        {
            panneau.SetActive(false);
            Time.timeScale = 1f;
        }
    }
}