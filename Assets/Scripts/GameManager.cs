using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;  // For scene management

public class GameManager : MonoBehaviour
{
    public int score = 0;                  // The player's score
    public TextMeshProUGUI scoreText;      // Reference to the score text in the game UI
    private static GameManager instance;   // Singleton instance for persistence

    // Make sure the score persists across scenes
    void Awake()
    {
        // If no GameManager exists, set this one as the persistent one
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);  // Ensure GameManager persists across scenes
        }
        else
        {
            Destroy(gameObject);  // Destroy duplicate GameManager instances
        }
    }

    // This method adds points to the score
    public void AddScore(int points)
    {
        score += points;
        UpdateScoreUI();
    }

    // This method updates the UI to reflect the score
    private void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
        }
    }

    // This method resets the score
    public void ResetScore()
    {
        score = 0;
        UpdateScoreUI();
    }

    // This method reloads the current scene, effectively restarting the game
    public void RestartGame()
    {
        ResetScore();  // Reset score when restarting
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);  // Reload the current scene
    }

    // This method optionally allows you to go to a main menu (you can modify as needed)
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");  // Replace with your actual main menu scene name
    }
}
