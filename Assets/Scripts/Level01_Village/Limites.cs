using UnityEngine;

namespace Arielle
{
    public static class Limites
    {
        public static Vector2 Limiter(Vector2 position, Vector2 min, Vector2 max)
        {
            float x = Mathf.Clamp(position.x, min.x, max.x);
            float y = Mathf.Clamp(position.y, min.y, max.y);
            return new Vector2(x, y);
        }
    }
}