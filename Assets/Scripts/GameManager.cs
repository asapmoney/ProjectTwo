using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;  

public class GameManager : MonoBehaviour
{
    public int score = 0;                  
    public TextMeshProUGUI scoreText;      
    private static GameManager instance;   

   
    void Awake()
    {
        
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); 
        }
        else
        {
            Destroy(gameObject); 
        }
    }


    public void AddScore(int points)
    {
        score += points;
        UpdateScoreUI();
    }


    private void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score.ToString();
        }
    }

   
    public void ResetScore()
    {
        score = 0;
        UpdateScoreUI();
    }

    public void RestartGame()
    {
        ResetScore();  
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); 
    }

    
    public void GoToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");  
    }
}
