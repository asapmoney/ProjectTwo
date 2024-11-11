using UnityEngine;
using UnityEngine.UI;

public class RestartButton : MonoBehaviour
{
    public GameManager gameManager;  // Reference to the GameManager

    private void Start()
    {
        // Add listener to button to call RestartGame when clicked
        GetComponent<Button>().onClick.AddListener(RestartGame);
    }

    // Restart the game by calling the RestartGame method in GameManager
    private void RestartGame()
    {
        if (gameManager != null)
        {
            gameManager.RestartGame();  // Restart the game and reset the score
        }
    }
}
