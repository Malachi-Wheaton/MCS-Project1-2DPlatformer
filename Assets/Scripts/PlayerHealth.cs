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

    public float invincibilityDuration = 1.5f;
    private bool isInvincible = false;

    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;
    private PlayerMovement playerMovement; // Ensure you have a movement script to disable

    void Start()
    {
        health = maxHealth;
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        playerMovement = GetComponent<PlayerMovement>();

        UpdateHealthUI();
    }

    public void TakeDamage(int damage)
    {
        if (isInvincible) return;

        health -= damage;
        if (health < 0)
            health = 0;

        UpdateHealthUI();
        StartCoroutine(InvincibilityFrames());

        if (health <= 0)
        {
            Die();
        }
    }

    public void UpdateHealthUI()
    {
        if (healthBar != null)
        {
            healthBar.value = (float)health / maxHealth;
        }
        if (healthText != null)
        {
            healthText.text = health + " / " + maxHealth;
        }
    }

    IEnumerator InvincibilityFrames()
    {
        isInvincible = true;
        float elapsed = 0f;
        float flashInterval = 0.2f;

        while (elapsed < invincibilityDuration)
        {
            spriteRenderer.enabled = !spriteRenderer.enabled;
            yield return new WaitForSeconds(flashInterval);
            elapsed += flashInterval;
        }

        spriteRenderer.enabled = true;
        isInvincible = false;
    }

    void Die()
    {
        Debug.Log("Player has died!");
        GameManager.instance.RespawnPlayer(gameObject);
    }


    IEnumerator Respawn()
    {
        // Disable movement & physics
        gameObject.SetActive(false);
        rb.velocity = Vector2.zero;
        if (playerMovement != null)
            playerMovement.enabled = false;

        yield return new WaitForSeconds(2f);

        // Reset health
        health = maxHealth;
        UpdateHealthUI();

        // Move player to respawn point
        transform.position = RespawnPoint.respawnPosition;

        // Reactivate player
        gameObject.SetActive(true);
        if (playerMovement != null)
            playerMovement.enabled = true;
    }
}






