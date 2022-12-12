using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_idle : StateMachineBehaviour
{
    Transform player;
    bool playerAlive;
    Rigidbody2D rb;
    public float chaseRange = 5f;

    Enemy boss;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        playerAlive = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().isAlive;
        rb = animator.GetComponent<Rigidbody2D>();
        boss = animator.GetComponent<Enemy>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if(playerAlive){
        boss.FacePlayer();

        if(Vector2.Distance(player.position, rb.position) < chaseRange){
            animator.SetBool("moving", true);
        }
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       
    }
}
