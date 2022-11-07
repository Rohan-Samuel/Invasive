using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// https://www.youtube.com/watch?v=ho7-pVNU62g&t=395s

public class EnemySences : MonoBehaviour
{
    public float viewRadius;
    public float viewAngle;

    public LayerMask targetPlayer;

    public LayerMask obstacleMask;

    public GameObject player;

    UnityEngine.AI.NavMeshAgent agent;
    public Transform target;


    // Start is called before the first frame update
    void Start()
    {
        // agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        // player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerTarget = (player.transform.position - transform.position).normalized;

        if (Vector3.Angle(transform.forward, playerTarget) <viewAngle / 2){
            float distanceToTarget = Vector3.Distance(transform.position, player.transform.position);
            if(distanceToTarget < viewRadius){
                if (Physics.Raycast(transform.position, playerTarget, distanceToTarget, obstacleMask) == false){
                    Debug.Log("I have seen you!");
                    agent.SetDestination(target.position);
                    
                }
                
            }

            
            
        }
        Debug.Log("I don't see you!");
        // Physics.Raycast(transform.position, playerTarget, distanceToTarget, obstacleMask) == true;
        

    }
}
