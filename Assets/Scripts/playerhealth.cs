using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

public class PlayerHealth : MonoBehaviour
{
    public string endgame = "EndGame";
    public float maxHealth = 100f;  
    public float health;            
    public Slider healthSlider;     

    void Start()
    {
        health = maxHealth;
        if (healthSlider != null)
        {
            healthSlider.maxValue = maxHealth;
            healthSlider.value = health;
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        
        health = Mathf.Max(health, 0f);

        if (healthSlider != null)
        {
            healthSlider.value = health;
        }

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        LoadEndGameScene();
        Debug.Log("Player has died");
    }
        void LoadEndGameScene()
    {
        SceneManager.LoadScene(endgame);
    }
}
