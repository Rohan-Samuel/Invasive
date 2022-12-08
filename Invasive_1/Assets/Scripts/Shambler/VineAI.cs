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
        public float hearingRange = 14f;
        public float attackRange = 7f;

        private Animator animator;

        public Transform target;

        public float turnSpeed = 2f;

        public int huntTime = 0;
        public int focuslevel = 0;

        float DistanceToPlayer()
        {
            Vector3 player = target.position;
            return Vector2.Distance(transform.position, player);
        }

        void RotateTowardsPlayer()
        {
            animator.SetTrigger("BackToIdle");

            Vector3 direction = target.position - transform.position;
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), turnSpeed * Time.deltaTime);
            
        }

        void AttackPlayer()
        {


            
            animator.SetTrigger("OnAttackRange");

        }


        void Start()
        {
            animator = GetComponent<Animator>();
            target = GameObject.FindGameObjectWithTag("Player").transform;
            fsm = new StateMachine(this);

            fsm.AddState("Listen", new State());

            fsm.AddState("LookAtPlayer", new State(
                onLogic: (state) => RotateTowardsPlayer()));

            fsm.AddState("AttackPlayer", new State(
                onLogic: (state) => AttackPlayer())) ;

            fsm.SetStartState("LookAtPlayer");

            

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
               (transition) => !animator.GetCurrentAnimatorStateInfo(0).IsName("Attack")
               ));
            
            fsm.Init();
        }

        // Update is called once per frame
        void Update()
        {
            fsm.OnLogic();

            huntTime--;
            if(huntTime < 0){
                focuslevel = 0;
                target = GameObject.FindGameObjectWithTag("Player").transform;
            }
            if (target == null){
                target = GameObject.FindGameObjectWithTag("Player").transform;
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

    }
}