using UnityEngine;

public class AIController : MonoBehaviour
{
    public float attackRange = 5f;        
    public Transform player;              
    public GameObject projectilePrefab;   
    public float projectileSpeed = 10f;   
    public float damage = 1f;             

    public AudioClip shootSound;         
    private AudioSource audioSource;      

    void Start()
    {
      
        audioSource = GetComponent<AudioSource>();

        
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }
    }

    void Update()
    {
       
        if (Vector3.Distance(transform.position, player.position) < attackRange)
        {
            RaycastHit hit;
            
            if (Physics.Raycast(transform.position, (player.position - transform.position).normalized, out hit, attackRange))
            {
                if (hit.transform == player)
                {
                    AttackPlayer(); 
                }
            }
        }
    }

    void AttackPlayer()
    {
        if (shootSound != null && audioSource != null)
        {
            audioSource.PlayOneShot(shootSound);  
        }

        
        GameObject projectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        Rigidbody rb = projectile.GetComponent<Rigidbody>();
        rb.velocity = (player.position - transform.position).normalized * projectileSpeed;

      
        Projectile projectileScript = projectile.GetComponent<Projectile>();
        if (projectileScript != null)
        {
            projectileScript.damage = damage;
        }

      
        Destroy(projectile, 2f);
    }
}
