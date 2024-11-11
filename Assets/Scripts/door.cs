using UnityEngine;
using UnityEngine.SceneManagement; // Required for scene management

public class Door : MonoBehaviour
{
    public GameManager gameManager; // Reference to the GameManager to check the score
    public string endgame = "EndGame"; // Name of the endgame scene

    // This method will be called when the player enters the door's trigger zone
    void OnTriggerEnter(Collider other)
    {
        // Check if the object that entered the trigger is the player
        if (other.CompareTag("Player"))
        {
            // Check if the player's score is 5 or higher
            if (gameManager.score >= 5)
            {
                // If score is enough, load the endgame scene
                LoadEndGameScene();
            }
            else
            {
                // If score is too low, you can display a message (optional)
                Debug.Log("Score is too low to open the door.");
            }
        }
    }

    // Method to load the endgame scene
    void LoadEndGameScene()
    {
        // Load the endgame scene by its name
        SceneManager.LoadScene(endgame);
    }
}
