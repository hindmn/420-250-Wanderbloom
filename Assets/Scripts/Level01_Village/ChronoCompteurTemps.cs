using UnityEngine;
using TMPro;

namespace Arielle
{
    public class ChronoCompteurTemps : MonoBehaviour
    {
        [SerializeField] private float duree = 60f;
        [SerializeField] private TMP_Text texte;
        [SerializeField] private float secondesAlerte = 10f;

        private Color couleurNorm;
        private CompteurTempsRegle regles;

        public bool EstTermine => regles.EstTermine;

        public float TempsEcoule => duree - regles.TempsRestant;

        private void Start()
        {
            couleurNorm = texte.color;
            regles = new CompteurTempsRegle(duree);
            MettreAJourTexte();
        }


        private void Update()
        {
            regles.Avancer(Time.deltaTime);
            MettreAJourTexte();
        }

        private void MettreAJourTexte()
        {
            int secondes = Mathf.CeilToInt(regles.TempsRestant);
            texte.text = "0" + (secondes / 60) + " : " + (secondes % 60).ToString("00");
            texte.color = regles.TempsRestant <= secondesAlerte ? Color.red : couleurNorm;
        }
    }
}