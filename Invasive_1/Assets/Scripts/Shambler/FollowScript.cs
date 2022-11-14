using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowScript : MonoBehaviour
{
    UnityEngine.AI.NavMeshAgent agent;
    public Transform target;
    public int speed;
    private int focuslevel;
    private int huntTime;

    // Start is called before the first frame update
    void Start()
    {
        focuslevel = 0;
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        if(target != null && huntTime > 0){

            agent.SetDestination(target.position);
            agent.transform.position = Vector3.MoveTowards(transform.position, target.position, speed/2 * Time.deltaTime);
            Vector3 doNotTurn = new Vector3(target.position.x, gameObject.transform.position.y, target.position.z);
            transform.LookAt(doNotTurn);
        }
        else{
            focuslevel = 0;
        }
    }
    public void setTarget(Transform t, int intensity){
        if(intensity >= focuslevel){
            target = t;
            huntTime = (intensity * 200);
        }
    }
}
