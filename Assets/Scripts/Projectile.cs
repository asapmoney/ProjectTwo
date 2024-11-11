using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float damage; // Damage this projectile will deal

    void OnTriggerEnter(Collider other)
    {
        // Check if the projectile hits the player
        if (other.CompareTag("Player"))
        {
            // Get the PlayerHealth component of the player object
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                // Deal damage to the player
                playerHealth.TakeDamage(damage);
            }

            // Destroy the projectile after it hits the player
            Destroy(gameObject);
        }
    }
}
