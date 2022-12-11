using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{

    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask attackMask;
    public int attackDamage = 20;
    //public float attackRate = 2f;
    //float nextAttackTime = 0f;

    void Attack(){
        Collider2D hitPlayer = Physics2D.OverlapCircle(attackPoint.position, attackRange, attackMask);

        if(hitPlayer != null){
            hitPlayer.GetComponent<Player>().TakeDamage(attackDamage);
        } 
    }

    void OnDrawGizmosSelected(){
        if(attackPoint ==null)
            return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
