using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.TestTools;

public class PresentPlayModeTests
{
    [UnityTest]
    public IEnumerator ToucheCadeau_CompteurChange()
    {
        const string scenePath = "Assets/Scenes/Level03_SnowyForest.unity";
        const string playerName = "/Player";
        const string counterName = "/Canvas";
        const string presentName = "Presents Group/Present 1";
        const string openState = "Present_Open";
        const float timeout = 3f;

        //Scène
        Time.timeScale = 1f;
        yield return SceneManager.LoadSceneAsync(scenePath, LoadSceneMode.Single);
        yield return null;
        Scene scene = SceneManager.GetActiveScene();
        Assert.IsTrue(scene.isLoaded, "La scène n'est pas chargée.");
        Assert.AreEqual(scenePath, scene.path, $"La scène active doit être {scenePath}.");

        //Joueur
        var player = GameObject.Find(playerName);
        Assert.IsNotNull(player, $"Aucun GameObject actif n'a été trouvé avec le nom {playerName}");
        Assert.AreEqual(scene, player.scene, $"Le joueur trouvé ne vient pas de la scène {scenePath}");
        Rigidbody2D pb = player.GetComponent<Rigidbody2D>();
        Assert.IsNotNull(pb, "Il manque le composant Rigidbody 2D pour ce player.");

        //Compteur
        var canvas = GameObject.Find(counterName);
        Assert.IsNotNull(canvas, $"Aucun GameObject actif n'a été trouvé avec le nom {counterName}");
        CounterPresent counterScript = canvas.GetComponent<CounterPresent>();
        Assert.IsNotNull(counterScript, $"Il manque le composant du script CounterPresent pour {counterName}.");
        Assert.AreEqual(0, counterScript.Count, "Le compteur doit débuter avec 0.");

        //Cadeau
        var present = GameObject.Find(presentName);
        Assert.IsNotNull(present, $"Aucun GameObject actif n'a été trouvé avec le nom {presentName}");
        Assert.AreEqual(scene, present.scene, $"Le cadeau trouvé ne vient pas de la scène {scenePath}");
        Animator animator = present.GetComponent<Animator>();
        Assert.IsNotNull(animator, $"Il manque l'Animator pour {presentName}.");

        //Le joueur est placé sur le cadeau
        pb.position = present.transform.position;
        yield return new WaitForFixedUpdate();

        //Assert 1 -> Le compteur passe à 1 
        float timeWaited = 0f;
        while(counterScript.Count == 0 && timeWaited < timeout)
        {
            timeWaited += Time.deltaTime;
            yield return null;
        }
        Assert.AreEqual(1, counterScript.Count, $"Le compteur devait passer à 1 en moins de {timeout} secondes.");

        //Assert 2 -> l'animation d'ouverture joue
        timeWaited = 0f;
        while (!animator.GetCurrentAnimatorStateInfo(0).IsName(openState) && timeWaited < timeout)
        {
            timeWaited += Time.deltaTime;
            yield return null;
        }
        Assert.IsTrue(animator.GetCurrentAnimatorStateInfo(0).IsName(openState),
            $"Lorsque ouvert, le cadeau doit jouer l'animation {openState}.");

        //Assert 3 -> un cadeau ne compte pas 2 fois
        for(int i = 0; i < 10; i++)
        {
            yield return new WaitForFixedUpdate();
        }
        Assert.AreEqual(1, counterScript.Count, "Le cadeau ne doit compter qu'une seule fois.");
    }

}