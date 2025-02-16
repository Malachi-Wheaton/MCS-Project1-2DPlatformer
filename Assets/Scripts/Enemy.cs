using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health = 3; // Enemy's starting health
    public float speed = 2f; // Movement speed of the enemy
    public float detectionRange = 5f; // How far the enemy can "see" the player
    public float stoppingDistance = 0.5f; // Distance to stop before reaching the player

    private Transform player; // Reference to the player's transform

    void Start()
    {
        // Find the player in the scene (assuming the player has the "Player" tag)
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject != null)
        {
            player = playerObject.transform;
        }
    }

    void Update()
    {
        if (player == null) return; // Do nothing if the player isn't assigned

        // Calculate the distance to the player
        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        // If the player is within detection range and outside stopping distance, move toward the player
        if (distanceToPlayer <= detectionRange && distanceToPlayer > stoppingDistance)
        {
            MoveTowardPlayer();
        }
    }

    private void MoveTowardPlayer()
    {
        // Move the enemy toward the player
        Vector2 direction = (player.position - transform.position).normalized; // Get the direction to the player
        transform.position += (Vector3)direction * speed * Time.deltaTime; // Move the enemy
    }

    public void TakeDamage(int damage, Vector2 knockbackDirection, float knockbackForce)
    {
        health -= damage;
        Debug.Log($"{gameObject.name} took {damage} damage! Remaining health: {health}");

        // Apply knockback if the enemy has a Rigidbody2D
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = Vector2.zero; // Reset current movement
            rb.AddForce(knockbackDirection * knockbackForce, ForceMode2D.Impulse);
        }

        if (health <= 0)
        {
            Die();
        }
    }


    private void Die()
    {
        Debug.Log($"{gameObject.name} has been defeated!");
        Destroy(gameObject); // Remove the enemy from the scene
    }
}
