using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour
{
    public GameObject attackUp;
    public GameObject attackDown;
    public GameObject attackLeft;
    public GameObject attackRight;

    public float attackDuration = 0.2f; // How long the attack lasts
    public float playerKnockbackForce = 5f; // Knockback force for the player
    public float enemyKnockbackForce = 7f; // Knockback force for the enemy
    private bool isAttacking = false;

    private GameObject currentAttackHitbox; // Track the active attack hitbox
    private Vector2 attackDirection; // Store attack direction

    void Update()
    {
        if (isAttacking) return;

        if (Input.GetKey(KeyCode.W) && Input.GetKeyDown(KeyCode.Return)) // Up attack
        {
            attackDirection = Vector2.up;
            StartCoroutine(PerformAttack(attackUp));
        }
        else if (Input.GetKey(KeyCode.S) && Input.GetKeyDown(KeyCode.Return)) // Down attack
        {
            attackDirection = Vector2.down;
            StartCoroutine(PerformAttack(attackDown));
        }
        else if (Input.GetKey(KeyCode.A) && Input.GetKeyDown(KeyCode.Return)) // Left attack
        {
            attackDirection = Vector2.left;
            StartCoroutine(PerformAttack(attackLeft));
        }
        else if (Input.GetKey(KeyCode.D) && Input.GetKeyDown(KeyCode.Return)) // Right attack
        {
            attackDirection = Vector2.right;
            StartCoroutine(PerformAttack(attackRight));
        }
    }

    private IEnumerator PerformAttack(GameObject attackHitbox)
    {
        isAttacking = true;
        currentAttackHitbox = attackHitbox;
        currentAttackHitbox.SetActive(true);

        ApplyPlayerKnockback(); // Apply knockback to the player

        yield return new WaitForSeconds(attackDuration);

        currentAttackHitbox.SetActive(false);
        isAttacking = false;
    }

    private void ApplyPlayerKnockback()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = Vector2.zero; // Reset velocity
            rb.AddForce(-attackDirection * playerKnockbackForce, ForceMode2D.Impulse);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isAttacking && collision.CompareTag("Enemy"))
        {
            Enemy enemy = collision.GetComponent<Enemy>();
            if (enemy != null)
            {
                Vector2 knockbackDir = (collision.transform.position - transform.position).normalized;
                enemy.TakeDamage(1, knockbackDir, enemyKnockbackForce);
            }
        }
    }
}



