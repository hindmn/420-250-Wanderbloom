using UnityEngine;
using UnityEngine.SceneManagement;

public class ScreenVictory : MonoBehaviour
{
   
    //Affiche l'écran et met le jeu en pause
    public void ShowScreen()
    {
        gameObject.SetActive(true);
        Time.timeScale = 0f;
    }
    
    //Remet le temps à 1 AVANT de recharger, sinon l'écran sera figé au rechargement.
    public void Replay()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
