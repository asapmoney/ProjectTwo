using UnityEngine;
using UnityEngine.UI;

public class RestartButton : MonoBehaviour
{
    public GameManager gameManager;  

    private void Start()
    {

        GetComponent<Button>().onClick.AddListener(RestartGame);
    }

 
    private void RestartGame()
    {
        if (gameManager != null)
        {
            gameManager.RestartGame();  
        }
    }
}
