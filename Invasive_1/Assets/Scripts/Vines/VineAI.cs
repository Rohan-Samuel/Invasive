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
        public float hearingRange = 6f;
        public float attackRange = 3f;

        private Animator animator;

        public Transform target;

        public float turnSpeed = 2f;


        float DistanceToPlayer()
        {
            Vector3 player = target.position;
            return Vector2.Distance(transform.position, player);
        }

        void RotateTowardsPlayer()
        {
            Vector3 direction = target.position - transform.position;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), turnSpeed * Time.deltaTime);
            animator.SetTrigger("BackToIdle");
        }

        void AttackPlayer()
        {
            
            animator.SetTrigger("OnAttackRange");
        }


        void Start()
        {
            animator = GetComponent<Animator>();

            fsm = new StateMachine(this);

            fsm.AddState("Listen", new State());

            fsm.AddState("LookAtPlayer", new State(
                onLogic: (state) => RotateTowardsPlayer()));

            fsm.AddState("AttackPlayer", new State(
                onLogic: (state) => AttackPlayer())) ;

            fsm.SetStartState("Listen");

            

            fsm.AddTransition(new Transition(
                "Listen",
                "LookAtPlayer",
                (transition) => DistanceToPlayer() < hearingRange
                ));

            fsm.AddTransition(new Transition(
               "LookAtPlayer",
               "Listen",
               (transition) => DistanceToPlayer() > hearingRange
               ));

            fsm.AddTransition(new Transition(
               "LookAtPlayer",
               "AttackPlayer",
               (transition) => DistanceToPlayer() < attackRange
               ));

            fsm.AddTransition(new Transition(
               "AttackPlayer",
               "LookAtPlayer",
               (transition) => DistanceToPlayer() > attackRange
               ));
            
            fsm.Init();
        }

        // Update is called once per frame
        void Update()
        {
            fsm.OnLogic();

            
        }
    }
}