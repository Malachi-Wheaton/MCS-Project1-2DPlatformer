using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMainMenu : MonoBehaviour
{
    public void BackToMain()
    {
        SceneManager.LoadScene("MainMenu"); // Replace with your Main Menu scene name
    }
}

