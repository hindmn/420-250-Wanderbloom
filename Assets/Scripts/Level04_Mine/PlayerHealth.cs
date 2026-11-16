
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;

    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;

    public float damageEffectDuration = 0.3f;
    public AudioClip damageSound;

    [Range(0f, 1f)]
    public float damageSoundVolume = 0.5f;

    private int currentHealth;
    private SpriteRenderer spriteRenderer;
    private Color originalColor;
    private Coroutine damageEffect;

    void Start()
    {
        currentHealth = maxHealth;
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();

        if (spriteRenderer != null)
            originalColor = spriteRenderer.color;

        UpdateHearts();
    }


    public void TakeDamage(int damage)
    {
        if (currentHealth <= 0)
            return;

        currentHealth -= damage;
        currentHealth = Mathf.Max(currentHealth, 0);

        UpdateHearts();

        if (damageSound != null)
        {
            AudioSource.PlayClipAtPoint(
                damageSound,
                transform.position,
                damageSoundVolume
            );
        }

        if (spriteRenderer != null)
        {
            if (damageEffect != null)
                StopCoroutine(damageEffect);

            damageEffect = StartCoroutine(DamageEffect());
        }

        Debug.Log("Vie restante : " + currentHealth);

        if (currentHealth == 0)
            Debug.Log("Game Over !");
    }


    IEnumerator DamageEffect()
    {
        spriteRenderer.color = new Color(1f, 0.65f, 0.65f);

        yield return new WaitForSeconds(damageEffectDuration);

        spriteRenderer.color = originalColor;
        damageEffect = null;
    }

    void UpdateHearts()
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            if (hearts[i] == null)
                continue;

            if (i < currentHealth)
                hearts[i].sprite = fullHeart;
            else
                hearts[i].sprite = emptyHeart;
        }
    }
}
