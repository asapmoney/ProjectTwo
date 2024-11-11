using UnityEngine;
using UnityEngine.SceneManagement; 

public class Door : MonoBehaviour
{
    public GameManager gameManager; 
    public string endgame = "EndGame"; 

 
    void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("Player"))
        {
            if (gameManager.score >= 5)
            {
                LoadEndGameScene();
            }
            else
            {
                Debug.Log("Score is too low to open the door.");
            }
        }
    }

    void LoadEndGameScene()
    {
        SceneManager.LoadScene(endgame);
    }
}
