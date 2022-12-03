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
    public int stunTimer = 0;
    public int waitDuration;
    private int pauseTime;
    Vector3 startPoint;

    // Start is called before the first frame update
    void Start()
    {
        
        pauseTime = waitDuration;
        focuslevel = 0;
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.speed = speed;
        startPoint = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        stunTimer--;
        huntTime--;
        if((target != null) && (huntTime > 0) && (stunTimer < 0)){
            
            agent.SetDestination(target.position);
            agent.transform.position = Vector3.MoveTowards(transform.position, target.position, (focuslevel*speed)/6  * Time.deltaTime);
            Vector3 doNotTurn = new Vector3(target.position.x, gameObject.transform.position.y, target.position.z);
            transform.LookAt(doNotTurn);
        }
        else if (stunTimer == 0){
            agent.speed = speed;
        }
        else if (stunTimer < 0){
            //Transform wp = startPoint;
                if (Vector3.Distance(transform.position, startPoint)< 0.1f)
                {
                    // pauseTime--;
                    //if(pauseTime == 0){
                    //    pauseTime = waitDuration;
                    //    currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
                    //}
                }
                else
                {
                    agent.SetDestination(startPoint);
                    transform.position = Vector3.MoveTowards(transform.position, startPoint, (focuslevel*speed)/6 * Time.deltaTime);
                    Vector3 doNotTurn = new Vector3(startPoint.x, gameObject.transform.position.y, startPoint.z);
                    transform.LookAt(doNotTurn);
                }
                
            focuslevel = 0;
        }
        else {
            agent.transform.position = Vector3.MoveTowards(transform.position, transform.position, 0);
        }
    }
    public void setTarget(Transform t, int intensity){
        if(t == target){
            huntTime = (intensity * 100);
        }
        else if (intensity > focuslevel){
            target = t;
            huntTime = (intensity * 100);
            focuslevel = intensity;
        }
    }

    public int getHuntTime(){
        return huntTime;
    }
    private void OnCollisionEnter(Collision collision){
        if(collision.gameObject.tag == "Throwable"){
            stunTimer = 120;
            agent.speed = 0;
            Debug.Log("oww");
        }
    }
}
