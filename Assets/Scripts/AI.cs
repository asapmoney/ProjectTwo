using UnityEngine;
using System.Collections.Generic;

public class AIPatrol : MonoBehaviour
{
    public List<Transform> waypoints;  
    public float speed = 2f;          
    public float detectionDistance = 2f; 
    public float rotationSpeed = 2f;   

    private int currentWaypoint = 0;   
    private Vector3 targetPosition;   
    public Transform player;           
    public float chaseRange = 10f;     

    private bool isChasing = false;    

    void Start()
    {
        if (waypoints.Count > 0)
        {
            targetPosition = waypoints[currentWaypoint].position;
        }
    }

    void Update()
    {
        
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        if (distanceToPlayer < chaseRange)
        {
            if (!isChasing)
            {
                
                isChasing = true;
                StopPatrolling();
            }
            Chase();
        }
        else if (isChasing)
        {
            
            isChasing = false;
            StartPatrolling();
        }

        
        if (!isChasing)
        {
            MoveTowardsTarget();
            CheckWallDetection();
            Patrol();
        }
    }

    void MoveTowardsTarget()
    {
        Vector3 direction = (targetPosition - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * rotationSpeed);
        transform.position += transform.forward * speed * Time.deltaTime;
    }

    void Patrol()
    {
     
        if (Vector3.Distance(transform.position, targetPosition) < 0.5f)
        {
            SelectNextWaypoint();
        }
    }

    void CheckWallDetection()
    {
       
        RaycastHit hit;
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        if (Physics.Raycast(transform.position, forward, out hit, detectionDistance))
        {
            if (hit.collider.CompareTag("Wall"))
            {
                SelectNewWaypoint();
            }
        }
    }

    void SelectNextWaypoint()
    {
        if (waypoints.Count == 0) return;

        currentWaypoint = (currentWaypoint + 1) % waypoints.Count;
        targetPosition = waypoints[currentWaypoint].position;
    }

    void SelectNewWaypoint()
    {
        if (waypoints.Count == 0) return;

       
        int newWaypoint = currentWaypoint;
        while (newWaypoint == currentWaypoint)
        {
            newWaypoint = Random.Range(0, waypoints.Count);
        }
        currentWaypoint = newWaypoint;
        targetPosition = waypoints[currentWaypoint].position;
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.forward * detectionDistance);
    }

    void Chase()
    {
        Vector3 targetPositionFlat = new Vector3(player.position.x, transform.position.y, player.position.z);

        RaycastHit hit;
        Vector3 direction = (targetPositionFlat - transform.position).normalized;
        if (Physics.Raycast(transform.position, direction, out hit, detectionDistance))
        {
            if (hit.collider.CompareTag("Wall"))
            {
                return;
            }
        }

        transform.position = Vector3.MoveTowards(transform.position, targetPositionFlat, speed * Time.deltaTime);
        Vector3 moveDirection = (targetPositionFlat - transform.position).normalized;
        Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    void StartPatrolling()
    {
        targetPosition = waypoints[currentWaypoint].position;
    }

    void StopPatrolling()
    {
    }
}
