using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public void RespawnPlayer(GameObject player)
    {
        StartCoroutine(RespawnRoutine(player));
    }
    
    public void WinGame()
    {
        Debug.Log("Game Over! You Won!");
        // Example: Load a win screen or show a UI message
        // SceneManager.LoadScene("WinScreen"); // Uncomment if using a win scene
        Time.timeScale = 0f; // Pause game (optional)
    }


    private IEnumerator RespawnRoutine(GameObject player)
    {
        Debug.Log("Respawn started!");

        // Disable the player
        player.SetActive(false);

        yield return new WaitForSeconds(2f); // Wait for respawn delay

        // Reset position
        player.transform.position = RespawnPoint.respawnPosition;

        // Reset health
        PlayerHealth playerHealth = player.GetComponent<PlayerHealth>();
        if (playerHealth != null)
        {
            playerHealth.health = playerHealth.maxHealth;
            playerHealth.UpdateHealthUI();
        }

        // Reactivate player
        player.SetActive(true);
        Debug.Log("Respawn complete!");
    }
}


