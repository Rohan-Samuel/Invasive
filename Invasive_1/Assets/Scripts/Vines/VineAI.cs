using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM;


namespace RNS
{
    public class VineAI : MonoBehaviour
    {
        public float rotationSpeed = 2f;

        private StateMachine fsm;
        public float hearingRange = 5f;

        public Transform target;


        float PlayerDirection()
        {
            Vector3 player = target.position;
            return Vector2.Angle(transform.position, player);
        }

        void RotateTowardsPlayer()
        {
            Vector3 player = target.position;
            transform.LookAt(target);
        }


        void Start()
        {
            fsm = new StateMachine();
        }

        // Update is called once per frame
        void Update()
        {
            RotateTowardsPlayer();
        }
    }
}