using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI; 

public class AIController : MonoBehaviour
{
    private NavMeshAgent agent; 
    private Transform playerTarget;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        GameObject playerObject = GameObject.FindGameObjectWithTag("Player");
        if (playerObject!= null)
        {
            playerTarget = playerObject.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTarget != null && agent.isActiveAndEnabled)
        {
            agent.SetDestination(playerTarget.position);
        }
    }
}
