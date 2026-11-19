using System.Collections;
using UnityEngine;

public class DialogManager : MonoBehaviour
{
    //L'objet "DialogContent" dans Hierarchy
    [SerializeField] private GameObject content;
    //La durée de l'affichage, on peut la modifier directement dans l'inspecteur
    [SerializeField] private float duration = 2.5f;

    public void ShowScreen()
    {//Si une autre fenêtre de dialog est ouverte, on l'arrête avant de lancer celle-ci
        StopAllCoroutines();
        StartCoroutine(ShowDialogScreen());
    }

    //Une coroutine, une méthode qui peut faire une pause au milieu de son exécution et qui reprend plus tard
    private IEnumerator ShowDialogScreen()
    {
        content.SetActive(true);
        Time.timeScale = 0f;
        //C'est ici "yield return" que la coroutine prend une pause
        yield return new WaitForSecondsRealtime(duration);

        Time.timeScale = 1f;
        content.SetActive(false);
    }
}
