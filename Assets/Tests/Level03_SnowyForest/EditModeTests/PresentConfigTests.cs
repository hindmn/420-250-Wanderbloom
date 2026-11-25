using System;
using System.Collections;
using NUnit.Framework;
using UnityEditor;
using UnityEditor.Animations;
using UnityEditor.SceneManagement;
using UnityEngine;
using UnityEngine.TestTools;
using System.Collections.Generic;

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
        const string presentGroupName = "Presents Group";

        //Scène
        SceneAsset sceneAsset = AssetDatabase.LoadAssetAtPath<SceneAsset>(scenePath);
        Assert.IsNotNull(sceneAsset, $"Aucune scène n'a été trouvé  à cet emplacement {scenePath}.");
        var scene = EditorSceneManager.OpenScene(scenePath);
        Assert.IsTrue(scene.isLoaded, "La scène n'est pas chargée.");

        //Cadeaux
        GameObject group = Array.Find(scene.GetRootGameObjects(), go => go.name == presentGroupName);
        Assert.IsNotNull(group, $"Le groupe {presentGroupName} n'existe pas.");
        List<GameObject> presents = new List<GameObject>();

        foreach (Transform enfant in group.transform)
        {
            if (enfant.name.StartsWith(presentName)) presents.Add(enfant.gameObject);
        }
        Assert.AreEqual(expectedCount, presents.Count,
            $"Le total de cadeaux doit être {expectedCount} dans le groupe {presentGroupName}");

        foreach (GameObject present in presents)
        {
            string nom = present.name;
            Assert.IsTrue(present.activeSelf, $"{nom} doit être activé dans la scène.");

            var zone = present.GetComponent<BoxCollider2D>();
            Assert.IsNotNull(zone, $"Il manque le Box Collider 2D pour {nom}.");
            Assert.IsTrue(zone.enabled, $"Le Box Collider 2D de {nom} doit être activé.");
            Assert.IsTrue(zone.isTrigger,
                "Le Box Collider 2D doit être un trigger pour détecter le joueur sans le bloquer.");

            //Animation
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
            Assert.IsNotNull(openParam, $"Le paramètre {expectedTrigger} n'existe pas.");
            Assert.AreEqual(AnimatorControllerParameterType.Trigger, openParam.type,
                $"Le type du paramètre {expectedTrigger} doit être un Trigger.");

            var openTransition = Array.Find(defaultState.transitions,
                t => t.destinationState.name == expectedOpenState);
            Assert.IsNotNull(openTransition,
                $"Il n'y a aucune transition de {expectedDefaultState} à {expectedOpenState}.");
            Assert.IsFalse(openTransition.hasExitTime,
                "La transition doit partir directement après sans Exit Time.");
            Assert.IsTrue(Array.Exists(openTransition.conditions, c => c.parameter == expectedTrigger),
                $"La condition de la transition doit être {expectedTrigger}.");

            //Effet sonore
            var audio = present.GetComponent<AudioSource>();
            Assert.IsNotNull(audio, $"Le composant AudioSource pour {nom} est manquant.");
            Assert.IsTrue(audio.enabled, $"Il faut activer l'AudioSource pour {nom}.");
            Assert.IsFalse(audio.playOnAwake, $"L'AudioSource de {nom} doit jouer uniquement à l'ouverture.");
            Assert.AreEqual(0f, audio.spatialBlend, $"Le son pour {nom} doit être en 2D donc Spatial Blend = 0.");

            var presentScript = present.GetComponent<Present>();
            Assert.IsNotNull(presentScript, $"Il faut ajouter un composant du script Present dans {nom}.");
            SerializedObject serializedObject = new SerializedObject(presentScript);

            var audioClip = serializedObject.FindProperty("sparklesSound").objectReferenceValue as AudioClip;
            Assert.IsNotNull(audioClip, $"Il faut assigné un son au champ Sparkles Sound dans l'Inspector de {nom}.");
            Assert.AreEqual(expectedBellSound, audioClip.name, $"L'effet sonore attendue est {expectedBellSound}.");

            //Étincelles (Sparkles)
            Transform transformSparkles = present.transform.Find(expectedSparklesName);
            Assert.IsNotNull(transformSparkles, $"L'enfant {expectedSparklesName} dans {nom} est manquant.");
            var sparkles = transformSparkles.GetComponent<ParticleSystem>();
            Assert.IsNotNull(sparkles, $"Le Particle System pour {expectedSparklesName} est manquant.");
            //Vérifie que c'est le même objet!
            Assert.AreSame(sparkles, serializedObject.FindProperty("sparkles").objectReferenceValue,
                $"Il faut que le champ Sparkles de {nom} pointe vers ses propres étincelles.");

            var main = sparkles.main;
            Assert.IsFalse(main.playOnAwake, "Les étincelles ne doivent pas jouer au démarrage.");
            Assert.IsFalse(main.loop, $"Les étincelles de {nom} doivent jouer uniquement UNE fois.");
            Assert.AreEqual(ParticleSystemStopAction.Destroy, main.stopAction,
                $"Il faut que les étincelles de {nom} soient détruites à la fin.");
        }
    }
}
