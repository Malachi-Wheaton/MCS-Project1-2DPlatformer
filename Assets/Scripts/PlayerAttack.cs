using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject attackHitbox;
    public float attackDuration = 0.2F;

    private bool isAttacking = false;

    void Start()
    {
        attackHitbox.SetActive(false); // Disable hitbox at start
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L) && !isAttacking) // Change to your attack button
        {
            StartCoroutine(SwingAttack());
        }
    }

    IEnumerator SwingAttack()
    {
        isAttacking = true;
        attackHitbox.SetActive(true);
        yield return new WaitForSeconds(attackDuration);
        attackHitbox.SetActive(false);
        isAttacking = false;
    }


}
