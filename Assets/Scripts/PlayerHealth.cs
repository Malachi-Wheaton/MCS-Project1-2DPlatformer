using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 10;
    public int health;
    public Slider healthBar;
    public TextMeshProUGUI healthText;

    public float invincibilityDuration = 1.5f; // Time the player is invincible
    private bool isInvincible = false;

    private SpriteRenderer spriteRenderer; // For visual effect

    void Start()
    {
        health = maxHealth;
        spriteRenderer = GetComponent<SpriteRenderer>(); // Get the player's sprite
        UpdateHealthUI();
    }

    public void TakeDamage(int damage)
    {
        if (isInvincible) return; // Ignore damage if invincible

        health -= damage;
        if (health < 0)
        {
            health = 0; // Ensure health doesn't go negative
        }

        UpdateHealthUI(); // Update health bar UI
        StartCoroutine(InvincibilityFrames()); // Start I-frames

        if (health <= 0)
        {
            Die();
        }
    }

    void UpdateHealthUI()
    {
        if (healthBar != null)
        {
            healthBar.value = (float)health / maxHealth; // Set slider value between 0-1
        }
        if (healthText != null)
        {
            healthText.text = health + " / " + maxHealth; // Update text display
        }
    }

    IEnumerator InvincibilityFrames()
    {
        isInvincible = true;
        float elapsed = 0f;
        float flashInterval = 0.2f; // Time between flashes

        while (elapsed < invincibilityDuration)
        {
            spriteRenderer.enabled = !spriteRenderer.enabled; // Toggle visibility
            yield return new WaitForSeconds(flashInterval);
            elapsed += flashInterval;
        }

        spriteRenderer.enabled = true; // Ensure sprite is visible
        isInvincible = false;
    }

    void Die()
    {
        Debug.Log("Player has died!");
        Destroy(gameObject); // Destroy player object on death
    }
}




