using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxhealth = 10;
    public int health;
    public HealthBar healthBar; // Reference to the health bar script

    void Start()
    {
        health = maxhealth;
        if (healthBar != null)
        {
            healthBar.SetMaxHealth(maxhealth); // Initialize the health bar
        }
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (healthBar != null)
        {
            healthBar.SetHealth(health); // Update the health bar when taking damage
        }

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Add death animation, effects, or respawn logic here
        Destroy(gameObject); // Destroy the player
    }
}
