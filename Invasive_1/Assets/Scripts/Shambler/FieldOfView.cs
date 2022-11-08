using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    public float viewRadius;
    [Range(0, 360)]
    public float viewAngle;

    public LayerMask targetMask;
    public LayerMask obstacleMask;
    [HideInInspector]
    public List<Transform> visibleTarget = new List<Transform>();

    UnityEngine.AI.NavMeshAgent agent;
    private float speed = 1f;
    public Transform[] waypoints;
    private int currentWaypointIndex = 0;

    void start(){
        StartCoroutine ("FindTargetWithDelay", .2f);
    }

    IEnumerator FindTargetWithDelay (float delay){
        while(true){
            yield return new WaitForSeconds (delay);
            FindVisibleTarget ();
        }
    }

    void FindVisibleTarget(){
        Collider[] targetInViewRadius = Physics.OverlapSphere (transform.position, viewRadius, targetMask);
        Transform wp = waypoints[currentWaypointIndex];
        // agent.isStopped = true;
        for (int i=0; i<targetInViewRadius.Length; i++){
            Transform target = targetInViewRadius[i].transform;
            Vector3 dirToTarget = (target.position - transform.position).normalized;
            if (Vector3.Angle (transform.forward, dirToTarget) < viewAngle / 2){
                float dstToTarget = Vector3.Distance (transform.position, target.position);
                if (!Physics.Raycast ( transform.position, dirToTarget, dstToTarget, obstacleMask)){
                    Debug.Log("I have seen you!");
                    agent.isStopped = false;
                    transform.position = Vector3.MoveTowards(transform.position, wp.position, speed/2 * Time.deltaTime);
                    transform.LookAt(wp.position);
                   
                }
                else{
                    
                    currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
                }
            
            }
        }
    }

    public Vector3 DirFromAngle(float angleInDegrees, bool angleIsGlobal){
        if (!angleIsGlobal){
            angleInDegrees += transform.eulerAngles.y;
        }
        return new Vector3(Mathf.Sin(angleInDegrees * Mathf.Deg2Rad), 0, Mathf.Cos(angleInDegrees * Mathf.Deg2Rad));
    }

}
