using UnityEngine;
using TMPro;

namespace Arielle
{
    public class CompteurFruit : MonoBehaviour
    {

        [SerializeField] private TMP_Text texte;
        [SerializeField] private int objectif = 10;


        private CompteurFruitRegleJeu regles;

        private void Awake()
        {
            regles = new CompteurFruitRegleJeu(objectif);
        }


        public int Nombre => regles.Nombre;

        public int Objectif => objectif;

        void Start()
        {
            MettreAJourTexte();
        }

        public void AjouterFruit()
        {
            regles.Ajouter();
            MettreAJourTexte();
        }

        public void RetirerFruit()
        {
            regles.Retirer();
            MettreAJourTexte();
        }




        private void MettreAJourTexte()
        {
            if (texte != null)
                texte.text = regles.Nombre + " / " + objectif;
        }
    }
}