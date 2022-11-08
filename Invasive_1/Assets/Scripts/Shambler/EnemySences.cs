using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// https://www.youtube.com/watch?v=ho7-pVNU62g&t=395s
namespace RNS
{
    public class EnemySences : MonoBehaviour
{
    public float viewRadius;
    public float viewAngle;

    public LayerMask targetPlayer;

    public LayerMask obstacleMask;

    public GameObject player;

    UnityEngine.AI.NavMeshAgent agent;
    public Transform target;
    
    private float speed = 1f ;
    // public Transform[] waypoints;
    private int currentWaypointIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        // Transform wp = waypoints[currentWaypointIndex];
        Vector3 playerTarget = (player.transform.position - transform.position).normalized;

        if (Vector3.Angle(transform.forward, playerTarget) <viewAngle / 2){
            float distanceToTarget = Vector3.Distance(transform.position, player.transform.position);
            if(distanceToTarget < viewRadius){
                if (Physics.Raycast(transform.position, playerTarget, distanceToTarget, obstacleMask) == false){
                    Debug.Log("I have seen you!");
                    agent.isStopped = false;
                    agent.SetDestination(target.position);
                    agent.transform.position = Vector3.MoveTowards(transform.position, target.position, speed/2 * Time.deltaTime);
                    // agent.transform.LookAt(wp.position);
                    
                }
                
            }  
            
        }
        Debug.Log("I don't see you!");
        agent.isStopped = true;
        

    }

    void OnTriggerStay(Collider other)
    {
        if (other.attachedRigidbody)
        {
            other.attachedRigidbody.AddForce(Vector3.up * 10);
        }
    }
}

}

