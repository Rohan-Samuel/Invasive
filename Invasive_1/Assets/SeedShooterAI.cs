using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FSM;

public class SeedShooterAI : MonoBehaviour
{

    public float rotationSpeed = 2f;

    private StateMachine fsm;
    public float hearingRange = 6f;
    public float attackRange = 3f;

    private Animator animator;

    public Transform target;


    float DistanceToPlayer()
    {
        Vector3 player = target.position;
        return Vector2.Distance(transform.position, player);
    }

    void RotateTowardsPlayer()
    {
        Vector3 player = target.position;
        transform.LookAt(target);
        animator.SetTrigger("BackToIdle");
    }

    void AttackPlayer()
    {
        Vector3 player = target.position;
        transform.LookAt(target);
        animator.SetTrigger("OnAttackRange");
    }

    void Start()
    {
        animator = GetComponentInChildren<Animator>();

        fsm = new StateMachine(this);

        fsm.AddState("Listen", new State());

        fsm.AddState("LookAtPlayer", new State(
            onLogic: (state) => RotateTowardsPlayer()));

        fsm.AddState("AttackPlayer", new State(
            onLogic: (state) => AttackPlayer()));

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
