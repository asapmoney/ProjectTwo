using UnityEngine;
using UnityEngine.SceneManagement; // Required for scene management
using TMPro; // Required for TextMeshPro

public class EndSceneManager : MonoBehaviour
{
    public TextMeshProUGUI gameOverText;  // Text element for "Game Over"
    public TextMeshProUGUI finalScoreText;  // Text element for final score
    public TextMeshProUGUI statusText;  // Text element to show "You Died" or "You Escaped!"
    private GameManager gameManager;  // Reference to GameManager

    void Start()
    {
        // Find the GameManager in the scene (this will work if GameManager uses DontDestroyOnLoad)
        gameManager = FindObjectOfType<GameManager>();

        // Ensure that the GameManager was found
        if (gameManager != null)
        {
            // Display the game over message and the final score
            gameOverText.text = "Game Over!";
            finalScoreText.text = "Final Score: " + gameManager.score;

            // Show the appropriate message based on the score
            if (gameManager.score < 5)
            {
                statusText.text = "You Died!";
            }
            else
            {
                statusText.text = "You Escaped!";
            }
        }
        else
        {
            Debug.LogError("GameManager not found! Make sure it is set up correctly.");
        }
    }

    // Method to restart the game (reloads the game scene)
    public void RestartGame()
    {
        // Reload the main game scene (replace with your actual game scene name)
        SceneManager.LoadScene("MainGameScene"); // Replace with your actual game scene name
    }

    // Method to return to the start scene
    public void GoToStartScene()
    {
        // Load the start scene (replace with your actual start scene name)
        SceneManager.LoadScene("StartScene"); // Replace with your actual start scene name
    }
}
