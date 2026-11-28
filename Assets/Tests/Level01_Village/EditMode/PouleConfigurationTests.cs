using NUnit.Framework;
using UnityEngine;
using UnityEditor.Animations;
using UnityEditor.SceneManagement;
using Arielle;

public class PouleConfigurationTests
{
    
    [Test]
    public void LaPouleEstBienConfiguree()
    {
        //Chargement de scne et on retrouve le chicken
        EditorSceneManager.OpenScene("Assets/Scenes/Level01_Village.unity");
        GameObject poule = GameObject.Find("TheChicken");
        Assert.IsNotNull(poule, "La scène doit contenir TheChicken");

        //Script de mouv de la poule
        Assert.IsNotNull(poule.GetComponent<TheChickenMovement>(), "Script TheChickenMovement manquant");

        //Rigidbody 2D where la gravité est 0 et la rotation est bloquée
        Rigidbody2D rb = poule.GetComponent<Rigidbody2D>();
        Assert.IsNotNull(rb, "Le Rigidbody2D est manquant");
        Assert.AreEqual(0f, rb.gravityScale, "La gravité doit être a zéro ; pour la vue du dessus");
        Assert.IsTrue((rb.constraints & RigidbodyConstraints2D.FreezeRotation) != 0, "La rotation Z doit être bloquée");

        //La presence du Collider2D
        Collider2D c = poule.GetComponent<Collider2D>();
        Assert.IsNotNull(c, "Le Collider2D est manquant");
        Assert.IsFalse(c.isTrigger, "La poule doit toucher le joueur, no trigger");


        //Animator -> Le controller, l'etat initial, le parametre enMarche
        Animator animator = poule.GetComponent<Animator>();
        Assert.IsNotNull(animator, "L'Animator est manquant");
        AnimatorController controller = animator.runtimeAnimatorController as AnimatorController;
        Assert.IsNotNull(controller, "Il n'y a aucun Animator Controller qui est assigné");
        Assert.IsNotNull(controller.layers[0].stateMachine.defaultState, "Aucun état initial");

        bool trouve = false;
        foreach (AnimatorControllerParameter p in controller.parameters)
            if (p.name == "EnMarche" && p.type == AnimatorControllerParameterType.Bool)
                trouve = true;
        Assert.IsTrue(trouve, "Le parametre boolean EnMarche est manquant");

        //L'audio : AudioSource qui ne joue pas au démarrage
        AudioSource audio = poule.GetComponent<AudioSource>();
        Assert.IsNotNull(audio, "L'AudioSource est manquant");
        Assert.IsFalse(audio.playOnAwake, "Le son ne doit pas jouer au lancement");
    }




    
}
