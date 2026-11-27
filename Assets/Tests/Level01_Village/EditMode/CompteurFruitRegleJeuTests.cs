using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
using Arielle;

public class CompteurFruitRegleJeuTests
{
    
    [Test]
    public void NouveauCompteurCommenceAZero()
    {
        var compteur = new CompteurFruitRegleJeu(10);
        Assert.AreEqual(0, compteur.Nombre);
    }

    [Test]
    public void AjouterAugmenteDeUn() {
        var compteur = new CompteurFruitRegleJeu(10);
        compteur.Ajouter();
        Assert.AreEqual(1, compteur.Nombre);
    }


    [Test]
    public void Retirer_DiminueDeUn()
    {
        var compteur = new CompteurFruitRegleJeu(10);
        compteur.Ajouter();
        compteur.Ajouter();
        compteur.Retirer();
        Assert.AreEqual(1, compteur.Nombre);
    }

    [Test]
    public void Retirer_AZero_ResteAZero()
    {
        var compteur = new CompteurFruitRegleJeu(10);
        compteur.Retirer();
        Assert.AreEqual(0, compteur.Nombre);
    }

    [Test]
    public void Ajouter_AuMaximum_NeDepassePas()
    {
        var compteur = new CompteurFruitRegleJeu(2);
        compteur.Ajouter();
        compteur.Ajouter();
        compteur.Ajouter(); 
        Assert.AreEqual(2, compteur.Nombre);
    }



}
