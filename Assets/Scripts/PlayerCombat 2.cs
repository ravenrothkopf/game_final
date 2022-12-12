using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{

    // animation contorller
    public Animator anim;

    // attacking
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemyLayer;
    public int attackDamage = 20;
    public float attackRate = 2f;
    float nextAttackTime = 0f;

    // Update is called once per frame
    void Update()
    {
        if(Time.time >= nextAttackTime){
            if(Input.GetKeyDown(KeyCode.Space)){
                Attack();
                nextAttackTime = Time.time + 1f/ attackRate;
            }
        }
        
    }

    void Attack(){
        anim.SetTrigger("attack");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayer);

        foreach(Collider2D enemy in hitEnemies){
            enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
        }
    }

    void OnDrawGizmosSelected(){
        if(attackPoint ==null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
