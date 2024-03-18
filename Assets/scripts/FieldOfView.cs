using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//source: https://youtu.be/j1-OyLo77ss?si=vwYzD_EYGwAuC5LI

public class FieldOfView : MonoBehaviour
{
    public float radius;
    [Range(0,360)] public float angle;

    public GameObject playerRef;

    public LayerMask targetMask;
    public LayerMask obstructionMask;

    public bool canSeePlayer;

    private void Start()    //declares player model as the player
    {
        playerRef = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(FOVRoutine());
    }


    private IEnumerator FOVRoutine() //sets time between checks for what's inside fov
    {
        WaitForSeconds wait = new WaitForSeconds(0.2f);

        while (true){
            yield return wait;
            FieldOfViewCheck();
        }
    }

    private void FieldOfViewCheck() //detect whether player is within fov
    {
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, radius, targetMask); //sets fov and who it applies to

        if (rangeChecks.Length != 0){ //if there's something within range
            Transform target = rangeChecks[0].transform;
            Vector3 directionToTarget = (target.position - transform.position).normalized;

            if(Vector3.Angle(transform.forward, directionToTarget) < angle/2){
                float distanceToTarget = Vector3.Distance(transform.position, target.position);
                if(!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionMask)){
                    canSeePlayer = true;
                } else { canSeePlayer = false; }

            } else { canSeePlayer = false; }
        } else if (canSeePlayer) { canSeePlayer = false; } //sets canSeePlayer to false if player leaves FOV
    }
}
