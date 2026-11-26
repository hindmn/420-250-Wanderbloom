using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Arielle
{
    public class NiveauA : MonoBehaviour
    {
        [SerializeField] private ChronoCompteurTemps chrono;
        [SerializeField] private CompteurFruit compteur;

        [SerializeField] private GameObject panneauFin;
        [SerializeField] private TMP_Text texteResultat;
        [SerializeField] private TMP_Text texteTemps;
        [SerializeField] private Image imageEmoji;


        [SerializeField] private Sprite emojiVert;
        [SerializeField] private Sprite emojiBleu;
        [SerializeField] private Sprite emojiMauve;

        [SerializeField] private string nomSceneMenu = "MainMenu";

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
            panneauFin.SetActive(true);

            int pommes = compteur.Nombre;

            if(pommes >= compteur.Objectif)
            {
                imageEmoji.sprite = emojiVert;
                texteResultat.text = "Victoire!!! Tu as rammssé " + pommes + " pommes en moins de 60 secondes!!!";
            }
            else if(pommes >= 5)
            {
                imageEmoji.sprite = emojiBleu;
                texteResultat.text = "Presque ! Tu as ramassé " + pommes + " pommes sur " + compteur.Objectif + ".";
            }
            else
            {
                imageEmoji.sprite = emojiMauve;
                texteResultat.text = "Oh mince... Tu as ramassé seulement " + pommes + " pommes.";
            }


            int secondes = Mathf.CeilToInt(chrono.TempsEcoule);
            texteTemps.text = "Temps écoulé - " + (secondes / 60).ToString("00") + " : " + (secondes % 60).ToString("00");

            /*if (victoire)
                Debug.Log("Victoire!!!!");
            else
                Debug.Log("Défaite, temps écoulé!!");*/
        }

        public void Rejouer()
        {
            Time.timeScale = 1f;
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public void AllerAuMenu()
        {
            Time.timeScale = 1f;

            if (Application.CanStreamedLevelBeLoaded(nomSceneMenu))
                SceneManager.LoadScene(nomSceneMenu);
            else
                Debug.LogWarning("La scène " + nomSceneMenu + " n'existe pas encore.");
        }
    }
}