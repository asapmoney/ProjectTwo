using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // Required for scene management
 // To interact with UI elements like Slider

public class PlayerHealth : MonoBehaviour
{
    public string endgame = "EndGame";
    public float maxHealth = 100f;  // Maximum health of the player
    public float health;            // Current health of the player
    public Slider healthSlider;     // Reference to the UI Slider

    void Start()
    {
        // Initialize health at the start of the game
        health = maxHealth;

        // Ensure the health slider is set correctly at the start
        if (healthSlider != null)
        {
            healthSlider.maxValue = maxHealth;
            healthSlider.value = health;
        }
    }

    // Method to handle taking damage
    public void TakeDamage(float damage)
    {
        health -= damage;
        
        // Clamp health to ensure it doesn't go below 0
        health = Mathf.Max(health, 0f);

        // Update the health slider UI
        if (healthSlider != null)
        {
            healthSlider.value = health;
        }

        if (health <= 0)
        {
            Die(); // Call the Die method when health reaches 0
        }
    }

    void Die()
    {
        LoadEndGameScene();
        // Handle player death (e.g., show game over screen, respawn, etc.)
        Debug.Log("Player has died");
        // You can add more game-over logic here
    }
        void LoadEndGameScene()
    {
        // Load the endgame scene by its name
        SceneManager.LoadScene(endgame);
    }
}
