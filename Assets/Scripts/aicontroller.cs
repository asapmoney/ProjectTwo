using UnityEngine;

public class AIController : MonoBehaviour
{
    public float attackRange = 5f;        // Range within which AI can attack the player
    public Transform player;              // The player's transform (should be assigned in the Inspector)
    public GameObject projectilePrefab;   // Prefab for the projectile
    public float projectileSpeed = 10f;   // Speed of the projectile
    public float damage = 1f;             // Damage dealt by the projectile

    public AudioClip shootSound;          // The sound to play when shooting
    private AudioSource audioSource;      // The AudioSource component

    void Start()
    {
        // Get the AudioSource component on the AI object
        audioSource = GetComponent<AudioSource>();

        // If there is no AudioSource component, we add one (optional)
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    void Update()
    {
        // Check if the player is within attack range
        if (Vector3.Distance(transform.position, player.position) < attackRange)
        {
            RaycastHit hit;
            // Raycast to check if there's no obstruction between AI and player
            if (Physics.Raycast(transform.position, (player.position - transform.position).normalized, out hit, attackRange))
            {
                if (hit.transform == player)
                {
                    AttackPlayer(); // If the player is within range and line of sight, attack!
                }
            }
        }
    }

    void AttackPlayer()
    {
        // Play the shooting sound
        if (shootSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(shootSound);  // Play the sound at the moment of firing
        }

        // Instantiate the projectile and set its velocity towards the player
        GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        rb.velocity = (player.position - transform.position).normalized * projectileSpeed;

        // Set the damage value on the projectile to communicate how much damage it does
        Projectile projectileScript = projectile.GetComponent<Projectile>();
        if (projectileScript != null)
        {
            projectileScript.damage = damage;
        }

        // Destroy the projectile after 2 seconds
        Destroy(projectile, 2f);
    }
}
