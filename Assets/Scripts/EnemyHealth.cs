using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int health = 3; // Enemy's starting health

    public void TakeDamage(int damage)
    {
        health -= damage;
        Debug.Log($"{gameObject.name} took {damage} damage! Remaining health: {health}");

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
