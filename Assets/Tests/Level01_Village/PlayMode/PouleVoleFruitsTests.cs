using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using NUnit.Framework;
using Arielle;
using UnityEngine.TestTools;



public class PouleVoleFruitsTests
{

    [UnityTest]
    public IEnumerator PouleToucheJoueurRetireFruit()
    {
        //Chargement de la scene du niveau 1
        SceneManager.LoadScene("Level01_Village");
        yield return null;
        yield return null;
        Time.timeScale = 1f;

        var compteur = Object.FindFirstObjectByType<CompteurFruit>();
        var poule = Object.FindFirstObjectByType<TheChickenMovement>();

        Assert.IsNotNull(compteur, "Le joueur doit avoir un CompteurFruit");
        Assert.IsNotNull(poule, "La scene doit contenir la poule");

        //Mettons le joueur a 3 pommes
        compteur.AjouterFruit();
        compteur.AjouterFruit();
        compteur.AjouterFruit();


        //Placons la poule juste pres du joueur
        Vector2 positionJoueur = compteur.transform.position;
        poule.GetComponent<Rigidbody2D>().position = positionJoueur + Vector2.right;


        //Attendons que le compteur change - max 3 sec
        float limite = Time.time + 3f;
        while (compteur.Nombre == 3 && Time.time < limite)
            yield return null;

        //Verifier qu'une pomme a été volée
        Assert.AreEqual(2, compteur.Nombre, "La poule devait voler exactement 1 pomme");

        //Renforcement du test 
        //Pendant la pause, la poule touche encore le joueur
        var rbPoule = poule.GetComponent<Rigidbody2D>();
        Vector2 joueurNow = compteur.transform.position;

        rbPoule.position = joueurNow + Vector2.right * 3f;
        yield return new WaitForFixedUpdate();
        yield return new WaitForFixedUpdate();

        //Nouveau contact
        rbPoule.position = joueurNow + Vector2.right * 0.3f;
        float fin = Time.time + 0.5f;
        while (Time.time < fin)
            yield return null;

        Assert.AreEqual(2, compteur.Nombre, "Pendant sa pause, la poule ne doit pas voler une 2e pomme");
    }
}
