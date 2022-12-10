using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy_running : StateMachineBehaviour
{
    Transform player;
    Rigidbody2D rb;
    public float speed = 3f;
    public float attackRange = 1f;
    public float chaseRange = 5f;

    Enemy boss;

    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        rb = animator.GetComponent<Rigidbody2D>();
        boss = animator.GetComponent<Enemy>();
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    override public void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        boss.FacePlayer();
        Vector2 direction = new Vector2(player.position.x, player.position.y);
        Vector2 newPos = Vector2.MoveTowards(rb.position, direction, speed * Time.fixedDeltaTime);
        rb.MovePosition(newPos);

        if(Vector2.Distance(player.position, rb.position) < attackRange){
            animator.SetTrigger("attack");
        }

        if(Vector2.Distance(player.position, rb.position) > chaseRange){
            animator.SetBool("moving", false);
        }
    }

    // OnStateExit is called when a transition ends and the state machine finishes evaluating this state
    override public void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
       animator.ResetTrigger("attack");
    }

}
