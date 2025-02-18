using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    public GameObject winScreen; // Assign your win screen UI Panel here
    public BoxCollider2D Victor;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Check if the player touched the goal
        {
            winScreen.SetActive(true); // Show the win screen UI
            Time.timeScale = 0f; // Pause the game
            Debug.Log("Detect Player");
        }
    }

    public void LoadMainMenu()
    {
        Time.timeScale = 1f; // Resume time before loading scene
        SceneManager.LoadScene("MainMenu"); // Change to your main menu scene name
    }
}




