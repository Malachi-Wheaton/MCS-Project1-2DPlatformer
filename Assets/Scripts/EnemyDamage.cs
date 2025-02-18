using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterDamage : MonoBehaviour
{
    public int damage;
    private PlayerHealth playerHealth;  // Removed the public reference so we can assign it in code

    void Start()
    {
        // Find the Player object and get the PlayerHealth component
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            playerHealth = player.GetComponent<PlayerHealth>();
        }
        else
        {
            Debug.LogError("Player object not found! Make sure the player has the 'Player' tag.");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player")) // CompareTag is more efficient
        {
            if (playerHealth != null) // Check if playerHealth is assigned
            {
                playerHealth.TakeDamage(damage);
            }
            else
            {
                Debug.LogError("PlayerHealth is not assigned.");
            }
        }
    }
}
