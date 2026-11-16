
using UnityEngine;

public class BatDamage : MonoBehaviour
{
    public int damage = 1;
    public float damageCooldown = 1.5f;

    private float nextDamageTime;

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player") && Time.time >= nextDamageTime)
        {
            PlayerHealth health = other.GetComponent<PlayerHealth>();

            if (health != null)
            {
                health.TakeDamage(damage);
                nextDamageTime = Time.time + damageCooldown;
            }
        }
    }
}
