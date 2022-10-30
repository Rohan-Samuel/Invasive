using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySight : MonoBehaviour
{
   /* public float fieldOFViewAngle = 110f;
    public bool playerInSight;
    public Vector3 personalLastSighting;

    private NavMeshCollider cor;
    private SphereCollider col;
    private Animator anim;
    private LastPlayerSighting LastPlayerSighting;
    private GameObject player;
    private Animator playerAnim;
    private PlayerHealth playerHealth;
    private HashIDs hash;
    private Vector3 previousSighting;


   void Awake(){
       nav = GetComponent<UnityEngine.AI.NavMeshAgent>();
       col = GetComponent<SphereCollider>();
       anim = GetComponent<Animator>();
       LastPlayerSighting = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<LastPlayerSighting>();
       player = GameObject.FindGameObjectWithTag(Tags.player);
       playerAnim = player.GetComponent<Animator>();
       playerHealth = player.GetComponent<PlayerHealth>();
       hash = GameObject.FindGameObjectWithTag(Tags.gameController).GetComponent<HashIDs>();

       personalLastSighting = LastPlayerSighting.resetPosition;
       previousSighting = LastPlayerSighting.resetPosition;

   }

   void Update(){
       if (LastPlayerSighting.position != previousSighting){
           personalLastSighting = LastPlayerSighting.position;
       }
       previousSighting = LastPlayerSighting.position;
       if(playerHealth.health > 0f){
           anim.SetBool(hash.playerInSightBool, playerInSight);
       } else{
           anim.SetBool(hash.playerInSightBool, false);
       }
   }

       void OnTriggerStay(Collider other){
           if(other.gameObject == player){
               playerInSight = false;
               Vector3 direction = other.transform.position - transform.position;
               float angle = Vector3.Angle(direction, trnasform.forward);

               if(angle < fieldOFViewAngle * 0.5f){
                   RaycastHit hit;

                   if(Physics.Raycast(transform.position + transform.up , direction.normalized, out hit, col.radius)){
                       if (hit.collider.gameObject == player){
                           playerInSight = true;
                           LastPlayerSighting.position = player.transform.position;
                       }
                   }
               }

           }
       }

       void OnTriggerExit(Collider other){
           if (other.gameObject == player){
               playerInSight = false;
           }
       }
*/
}
