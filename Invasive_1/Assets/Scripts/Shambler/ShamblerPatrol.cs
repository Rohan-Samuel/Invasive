using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RNS
{
    public class ShamblerPatrol : MonoBehaviour
    {
        public Transform[] waypoints;
        private int currentWaypointIndex = 0;
        private float speed = 1f;

        private void Update()
        {   
            if(gameObject.GetComponent<FollowScript>().huntTime < 0){
                Transform wp = waypoints[currentWaypointIndex];
                if (Vector3.Distance(transform.position, wp.position)< 0.01f)
                {
                    currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
                }

                else
                {
                    transform.position = Vector3.MoveTowards(transform.position, wp.position, speed/2 * Time.deltaTime);
                    transform.LookAt(wp.position);
                }
            }
        }
    }
}