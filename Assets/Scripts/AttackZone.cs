using UnityEngine;

public class AttackZone : MonoBehaviour
{
    public int damage = 1; // Amount of damage dealt by this attack

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the object has the "Enemy" tag
        if (collision.CompareTag("Enemy"))
        {
            Debug.Log($"Hit {collision.name}!");
            Enemy enemy = collision.GetComponent<Enemy>(); // Get the Enemy script
            if (enemy != null)
            {
                enemy.TakeDamage(damage); // Apply damage to the enemy
            }
        }
    }
}



