using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowScript : MonoBehaviour
{
    UnityEngine.AI.NavMeshAgent agent;
    public Transform target;
    public int speed;
    private int focuslevel;
    public int huntTime;
    public Transform[] waypoints;
    private int currentWaypointIndex = 0;
    private int stunTimer = 0;

    // Start is called before the first frame update
    void Start()
    {
        focuslevel = 0;
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        stunTimer--;
        if(target != null && huntTime > 0 && stunTimer < 0){

            agent.SetDestination(target.position);
            agent.transform.position = Vector3.MoveTowards(transform.position, target.position, speed/2 * Time.deltaTime);
            Vector3 doNotTurn = new Vector3(target.position.x, gameObject.transform.position.y, target.position.z);
            transform.LookAt(doNotTurn);
        }
        else{
          /*  Transform wp = waypoints[currentWaypointIndex];
                if (Vector3.Distance(transform.position, wp.position)< 0.01f)
                {
                    currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
                }

                else
                {
                    transform.position = Vector3.MoveTowards(transform.position, wp.position, speed/2 * Time.deltaTime);
                    transform.LookAt(wp.position);
                }
                */
            focuslevel = 0;
        }
    }
    public void setTarget(Transform t, int intensity){
        if(intensity > focuslevel){
            target = t;
            huntTime = (intensity * 200);
        }
    }

    public int getHuntTime(){
        return huntTime;
    }
    private void OnCollisionEnter(Collision collision){
        if(collision.gameObject.tag == "Throwable"){
            stunTimer = 120;
            Debug.Log("oww");
        }
    }
}
