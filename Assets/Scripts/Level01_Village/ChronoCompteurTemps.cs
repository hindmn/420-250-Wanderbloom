using UnityEngine;
using TMPro;

namespace Arielle
{
    public class ChronoCompteurTemps : MonoBehaviour
    {
        [SerializeField] private float duree = 60f;
        [SerializeField] private TMP_Text texte;

        private CompteurTempsRegle regles;

        public bool EstTermine => regles.EstTermine;

        private void Start()
        {
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
        }
    }
}