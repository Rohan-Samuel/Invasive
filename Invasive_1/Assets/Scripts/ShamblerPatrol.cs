using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace RNS
{
    public class ShamblerPatrol : MonoBehaviour
    {
        public Transform[] waypoints;
        private int currentWaypointIndex = 0;
        private float speed = 2f;

        private void Update()
        {
            Transform wp = waypoints[currentWaypointIndex];
            if (Vector3.Distance(transform.position, wp.position)< 0.01f)
            {
                currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
            }

            else
            {
                transform.position = Vector3.MoveTowards(transform.position, wp.position, speed * Time.deltaTime);
                transform.LookAt(wp.position);
            }
        }
    }
}