using UnityEngine;

public static class ReglementsGlace
{
    public static Vector2 NextVelocity(Vector2 currentVelocity, 
        Vector2 input, float moveSpeed,bool onIce, float iceControl, float deltaTime)
    {
        Vector2 targetVelocity = input * moveSpeed;
        if (!onIce)
        {
            return targetVelocity;
        }
        if(input == Vector2.zero)
        {
            return currentVelocity;
        }
        return Vector2.MoveTowards(currentVelocity, targetVelocity, iceControl * deltaTime);
    }
}
