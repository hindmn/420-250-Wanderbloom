using UnityEngine;

namespace Arielle
{
    public class NiveauA : MonoBehaviour
    {
        [SerializeField] private ChronoCompteurTemps chrono;
        [SerializeField] private CompteurFruit compteur;

        private bool partieFinie = false;


        private void Update()
        {
            if (partieFinie) return;

            if (compteur.Nombre >= compteur.Objectif)
                TerminerPartie(true);
            else if (chrono.EstTermine)
                TerminerPartie(false);
        }

        private void TerminerPartie(bool victoire)
        {
            partieFinie = true;
            Time.timeScale = 0f;

            if (victoire)
                Debug.Log("Victoire!!!!");
            else
                Debug.Log("Défaite, temps écoulé!!");
        }
    }
}