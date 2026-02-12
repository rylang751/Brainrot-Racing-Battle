using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIController : MonoBehaviour
{
    public List<Transform> waypoints; // Drag your track points here
    public float arrivalDistance = 3.0f; 

    private NavMeshAgent agent;
    private int currentWaypointIndex = 0;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();

        if (waypoints.Count > 0)
        {
            agent.SetDestination(waypoints[0].position);
        }
    }

    void Update()
    {
        if (waypoints.Count == 0 || !agent.isActiveAndEnabled) return;

        // Move to next waypoint when close enough
        if (!agent.pathPending && agent.remainingDistance < arrivalDistance)
        {
            currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Count;
            agent.SetDestination(waypoints[currentWaypointIndex].position);
        }
    }
}