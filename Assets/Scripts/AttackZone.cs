using UnityEngine;

public class AttackZone : MonoBehaviour
{
    public int damage = 1; // Amount of damage the attack deals

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Enemy enemy = collision.GetComponent<Enemy>();
            if (enemy != null)
            {
                Vector2 knockbackDirection = (collision.transform.position - transform.position).normalized;
                float knockbackForce = 7f; // Adjust this value for enemy knockback strength

                enemy.TakeDamage(1, knockbackDirection, knockbackForce); // Send knockback data
            }
        }
    }
}




