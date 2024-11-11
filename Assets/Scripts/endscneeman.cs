using UnityEngine;
using UnityEngine.SceneManagement; 
using TMPro; 

public class EndSceneManager : MonoBehaviour
{
    public TextMeshProUGUI gameOverText; 
    public TextMeshProUGUI finalScoreText; 
    public TextMeshProUGUI statusText;  
    private GameManager gameManager;  

    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();

       
        if (gameManager != null)
        {
           
            gameOverText.text = "Game Over!";
            finalScoreText.text = "Final Score: " + gameManager.score;

            
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

    public void RestartGame()
    {
        SceneManager.LoadScene("MainGameScene"); 
    }

    public void GoToStartScene()
    {
        SceneManager.LoadScene("StartScene"); 
    }
}
