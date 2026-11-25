using NUnit.Framework;
using UnityEngine;

public class ReglementsGlaceTests
{
    private const float moveSpeed = 4f;
    private const float iceControl = 6f;
    private const float deltaTime = 0.02f;
    //Pour accepter les nombres à virgule si leur différence est plus petite que 0.0001
    private const float tolerance = 0.0001f;

    //Compare 2 Vector2 avec la tolérance pour éviter de répéter les mêmes lignes plusieurs fois
    private void AssertVector(Vector2 expected, Vector2 actual, string message)
    {
        Assert.AreEqual(expected.x, actual.x, tolerance, message + " (x)");
        Assert.AreEqual(expected.y, actual.y, tolerance, message + " (y)");
    }

    [Test]
    public void JoueurSurNeige_AppuieSurTouche()
    {
        //Arrange
        Vector2 currentVelocity = Vector2.zero;
        Vector2 input = Vector2.right;
        //Act
        Vector2 result = ReglementsGlace.NextVelocity(
            currentVelocity, input, moveSpeed, false, iceControl, deltaTime);
        //Assert
        AssertVector(new Vector2(4f, 0f), result,
            "Lorsque le joueur est sur la neige, il doit atteindre sa vitesse immédiatement.");
    }

    [Test]
    public void JoueurSurNeige_RelacheTouche()
    {
        //Arrange
        Vector2 currentVelocity = new Vector2(4f, 0f);
        Vector2 input = Vector2.zero;
        //Act
        Vector2 result = ReglementsGlace.NextVelocity(
            currentVelocity, input, moveSpeed, false, iceControl, deltaTime);
        //Assert
        AssertVector(Vector2.zero, result,
            "Lorsque le joueur est sur la neige, il doit s'arrêter immédiatement quand on relâche la touche.");
    }

    [Test]
    public void JoueurSurGlace_GardeVitesse()
    {
        //Arrange
        Vector2 currentVelocity = new Vector2(3f, -2f);
        Vector2 input = Vector2.zero;
        //Act
        Vector2 result = ReglementsGlace.NextVelocity(
            currentVelocity, input, moveSpeed, true, iceControl, deltaTime);
        //Assert
        AssertVector(currentVelocity, result,
            "Lorsque le joueur est sur la glace, il garde la même vitesse même en glissant.");
    }

    [Test]
    public void JoueurSurGlace_FaitDemiTour()
    {
        //Arrange
        Vector2 currentVelocity = new Vector2(4f, 0f);
        Vector2 input = Vector2.left;
        //Act
        Vector2 result = ReglementsGlace.NextVelocity(
            currentVelocity, input, moveSpeed, true, iceControl, deltaTime);
        //Assert -> 4 - (6 x 0.02) = 3.88 
        AssertVector(new Vector2(3.88f, 0f), result,
            "Lorsque le joueur est sur la glace, il change de vitesse maximum iceControl x deltaTime.");
    }

    [Test]
    public void JoueurSurGlace_DepassePasCible()
    {
        //Arrange
        Vector2 currentVelocity = new Vector2(3.95f, 0f);
        Vector2 input = Vector2.right;
        //Act
        Vector2 result = ReglementsGlace.NextVelocity(
            currentVelocity, input, moveSpeed, true, iceControl, deltaTime);
        //Assert
        AssertVector(new Vector2(4f, 0f), result,
            "Lorsque le joueur est sur la glace, il doit s'arrêter à la cible sans la dépasser.");
    }
}
