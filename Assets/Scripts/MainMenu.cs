using UnityEngine;
using UnityEngine.SceneManagement; // To load different scenes
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    public Button playButton;
    public Button instructionsButton;
    public Button creditsButton;
    public Button exitButton;

    void Start()
    {
        // Assign button click events
        playButton.onClick.AddListener(PlayGame);
        instructionsButton.onClick.AddListener(GoToInstructions);
        creditsButton.onClick.AddListener(GoToCredits);
        exitButton.onClick.AddListener(ExitGame);
    }

    // Methods to load scenes or exit game
    void PlayGame()
    {
        SceneManager.LoadScene("GameScene"); // Replace with your actual game scene name
    }

    void GoToInstructions()
    {
        SceneManager.LoadScene("Instructions"); // Replace with your instructions scene name
    }

    void GoToCredits()
    {
        SceneManager.LoadScene("Credits"); // Replace with your credits scene name
    }

    void ExitGame()
    {
        Application.Quit(); // Exit the game (works in builds)
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // If in editor, stop play mode
#endif
    }
}

