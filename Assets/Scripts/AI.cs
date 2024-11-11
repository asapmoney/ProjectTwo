using UnityEngine;
using System.Collections.Generic;

public class AIPatrol : MonoBehaviour
{
    public List<Transform> waypoints;  // List of waypoints
    public float speed = 2f;           // Movement speed
    public float detectionDistance = 2f; // Wall detection range
    public float rotationSpeed = 2f;   // Rotation speed

    private int currentWaypoint = 0;   // Current waypoint index
    private Vector3 targetPosition;    // Current target position
    public Transform player;           // Reference to the player
    public float chaseRange = 10f;     // Distance at which AI starts chasing the player

    private bool isChasing = false;    // Whether the AI is currently chasing the player

    void Start()
    {
        if (waypoints.Count > 0)
        {
            targetPosition = waypoints[currentWaypoint].position;
        }
    }

    void Update()
    {
        // If the player is within chase range, switch to chase mode
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);
        if (distanceToPlayer < chaseRange)
        {
            if (!isChasing)
            {
                // Start chasing the player
                isChasing = true;
                StopPatrolling();
            }
            Chase();
        }
        else if (isChasing)
        {
            // Player is out of range, stop chasing and resume patrolling
            isChasing = false;
            StartPatrolling();
        }

        // If not chasing, patrol the waypoints
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
        // Check if we've reached the current waypoint
        if (Vector3.Distance(transform.position, targetPosition) < 0.5f)
        {
            SelectNextWaypoint();
        }
    }

    void CheckWallDetection()
    {
        // Raycasting to detect walls while patrolling
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

        // Select a random waypoint different from the current one
        int newWaypoint = currentWaypoint;
        while (newWaypoint == currentWaypoint)
        {
            newWaypoint = Random.Range(0, waypoints.Count);
        }
        currentWaypoint = newWaypoint;
        targetPosition = waypoints[currentWaypoint].position;
    }

    // Optional: Visualize Raycast in the Scene view
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.forward * detectionDistance);
    }

    void Chase()
    {
        // Make sure the AI only moves horizontally (on the XZ plane).
        Vector3 targetPositionFlat = new Vector3(player.position.x, transform.position.y, player.position.z);

        // Perform raycast to check if there's a wall in front of the AI
        RaycastHit hit;
        Vector3 direction = (targetPositionFlat - transform.position).normalized;
        if (Physics.Raycast(transform.position, direction, out hit, detectionDistance))
        {
            // If there is a wall ahead, stop chasing
            if (hit.collider.CompareTag("Wall"))
            {
                return;
            }
        }

        // Move towards the player horizontally, ignoring the Y-axis
        transform.position = Vector3.MoveTowards(transform.position, targetPositionFlat, speed * Time.deltaTime);
        Vector3 moveDirection = (targetPositionFlat - transform.position).normalized;
        Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
    }

    void StartPatrolling()
    {
        // Resume patrolling by setting the target position to the current waypoint
        targetPosition = waypoints[currentWaypoint].position;
    }

    void StopPatrolling()
    {
        // Optional: Disable patrolling logic if needed, like stopping movement
        // In this case, we just stop the waypoint selection until the player is out of range
        // This could be expanded with additional behaviors like pausing movement
    }
}
