using UnityEngine;

public class AttackZone : MonoBehaviour
{
    public int damage = 1; // Amount of damage the attack deals

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object entering the hitbox is an enemy
        EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();
        if (enemyHealth != null)
        {
            enemyHealth.TakeDamage(damage); // Deal damage to the enemy
        }
    }
}




