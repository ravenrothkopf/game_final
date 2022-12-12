using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // health
    public int maxHealth;
    int curHealth;
    public healthbar healthbar;

    // taking damage
    public Animator anim;

    void Start(){
        curHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
    }

    public void TakeDamage(int damage){
        curHealth -= damage;
        anim.SetTrigger("hurt");
        healthbar.SetHealth(curHealth);
        
        // play animation

        if(curHealth <=0){
            Die();
        }

    }

    void Die(){
        // die animation
        GameObject.FindGameObjectWithTag("bg").GetComponent<bossBgSound>().stopBg();
        anim.SetBool("isDead", true);

        // disable enemy 
        GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition;
        this.enabled = false; 

        Debug.Log("died");
    }

    // face player
    public Transform player;

    public void FacePlayer(){

        // flip enemy to face player
        if(transform.position.x > player.position.x){
            this.transform.localScale = new Vector3(-4,4,4);
        }
        else{
            this.transform.localScale = new Vector3(4,4,4);
        }
    }
}
