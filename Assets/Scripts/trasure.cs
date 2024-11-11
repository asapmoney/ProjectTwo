using UnityEngine;

public class Treasure : MonoBehaviour
{
    public int points = 1; 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager gameManager = FindObjectOfType<GameManager>(); 
            if (gameManager != null)
            {
                gameManager.AddScore(points); 
            }
            Destroy(gameObject); 
        }
    }
}
