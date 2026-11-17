using System;
using System.Collections;
using NUnit.Framework;
using UnityEditor;
using UnityEditor.Animations;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.TestTools;

public class PresentConfigTests
{
    [Test]
    public void TestsConfigSnowyForest()
    {
        const string scenePath = "Assets/Scenes/Level03_SnowyForest.unity";
        const string presentName = "Present ";
        const int expectedCount = 15;
        const string expectedDefaultState = "Present_Closed";
        const string expectedOpenState = "Present_Open";
        const string expectedTrigger = "Open";
        const string expectedSparklesName = "Sparkles";
        const string expectedBellSound = "mixkit-christmas-magic-bell-hit-939";

        //Scène
        SceneAsset sceneAsset = AssetDatabase.LoadAssetAtPath<SceneAsset>(scenePath);
        Assert.IsNotNull(sceneAsset, $"Aucune scène n'a été trouvé  à cet emplacement {scenePath}.");
        var scene = EditorSceneManager.OpenScene(scenePath);
        Assert.IsTrue(scene.isLoaded, "La scène n'est pas chargée.");

        //Cadeaux
        GameObject[] presents = Array.FindAll(scene.GetRootGameObjects(), go => go.name.StartsWith(presentName));
        Assert.AreEqual(expectedCount, presents.Length,
            $"Il doit y avoir {expectedCount} cadeaux à la racine de la scène.");
        
        foreach(GameObject present in presents)
        {
            string nom = present.name;
            Assert.IsTrue(present.activeSelf, $"{nom} doit être activé dans la scène.");

            var zone = present.GetComponent<BoxCollider2D>();
            Assert.IsNotNull(zone, $"Il manque le Box Collider 2D pour {nom}.");
            Assert.IsTrue(zone.enabled, $"Le Box Collider 2D de {nom} doit être activé.");
            Assert.IsTrue(zone.isTrigger,
                "Le Box Collider 2D doit être un trigger pour détecter le joueur sans le bloquer.");

            var animator = present.GetComponent<Animator>();
            Assert.IsNotNull(animator, $"Il manque l'Animator pour {nom}.");
            Assert.IsTrue(animator.enabled, $"L'Animator de {nom} doit être activé.");

            AnimatorController controller = animator.runtimeAnimatorController as AnimatorController;
            Assert.IsNotNull(controller, $"Il manque l'Animator Controller pour {nom}");
            Assert.IsTrue(controller.layers.Length > 0, $"Il n'y a aucune couche dans le contrôleur de {nom}");

            var stateMachine = controller.layers[0].stateMachine;
            var defaultState = stateMachine.defaultState;
            Assert.IsNotNull(defaultState, "Il n'y a aucun état initial défini.");
            Assert.AreEqual(expectedDefaultState, defaultState.name,
                $"L'état initial attendue est {expectedDefaultState}.");

            var openParam = Array.Find(controller.parameters, p => p.name == expectedTrigger);
            Assert.IsNotNull(openParam, $"Le paramètre {openParam} n'existe pas.");
            Assert.AreEqual(AnimatorControllerParameterType.Trigger, openParam.type,
                $"Le type du paramètre {expectedTrigger} doit être un Trigger.");

            var openTransition = Array.Find(defaultState.transitions,
                t => t.destinationState.name == expectedOpenState);
            Assert.IsNotNull(openTransition,
                $"Il n'y a aucune transition de {expectedDefaultState} à {expectedOpenState}.");
            
        }
    }
}
