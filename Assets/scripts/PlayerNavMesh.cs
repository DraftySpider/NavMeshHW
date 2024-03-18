using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerNavMesh : MonoBehaviour
{
    [SerializeField] private Transform movePositionTransform; //Target to follow

    private NavMeshAgent navMeshAgent;

    private void Awake() 
    { 
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update() //makes navigating agent follow target
    {
        navMeshAgent.destination = movePositionTransform.position;
    }
}
