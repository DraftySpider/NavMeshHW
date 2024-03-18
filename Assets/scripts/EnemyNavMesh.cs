using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class EnemyNavMesh : MonoBehaviour
{
    [SerializeField] FieldOfView playerWithinRange;

    [SerializeField] private Transform movePositionTransform; //Target to follow

    private NavMeshAgent navMeshAgent;

    private void Awake() 
    { 
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update() //makes navigating agent follow target
    {   
        if (playerWithinRange.canSeePlayer){
            navMeshAgent.destination = movePositionTransform.position;
        }
    }
}
