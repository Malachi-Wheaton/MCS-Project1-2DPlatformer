using UnityEngine;
using System.Collections;

public class PlayerAttack : MonoBehaviour
{
    public GameObject attackUp;
    public GameObject attackDown;
    public GameObject attackLeft;
    public GameObject attackRight;

    public float attackDuration = 0.2f; // How long the attack lasts
    private bool isAttacking = false;

    void Update()
    {
        if (isAttacking) return;

        // Check for combined input
        if (Input.GetKey(KeyCode.W) && Input.GetKeyDown(KeyCode.Return)) // Up attack
        {
            StartCoroutine(PerformAttack(attackUp));
        }
        else if (Input.GetKey(KeyCode.S) && Input.GetKeyDown(KeyCode.Return)) // Down attack
        {
            StartCoroutine(PerformAttack(attackDown));
        }
        else if (Input.GetKey(KeyCode.A) && Input.GetKeyDown(KeyCode.Return)) // Left attack
        {
            StartCoroutine(PerformAttack(attackLeft));
        }
        else if (Input.GetKey(KeyCode.D) && Input.GetKeyDown(KeyCode.Return)) // Right attack
        {
            StartCoroutine(PerformAttack(attackRight));
        }
    }

    private IEnumerator PerformAttack(GameObject attackDirection)
    {
        isAttacking = true;
        attackDirection.SetActive(true); // Enable the attack hitbox
        yield return new WaitForSeconds(attackDuration); // Wait for the duration
        attackDirection.SetActive(false); // Disable the attack hitbox
        isAttacking = false;
    }
}



