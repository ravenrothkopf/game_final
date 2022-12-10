using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform player;

    public float moveSpeed;
    private Rigidbody2D rb;

    public Animator animator;

    public bool playerInArea {get; private set;}

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }
    

    void FixedUpdate(){
        Vector2 direction = (Vector2)player.position - rb.position;

        // flip enemy to face player
        if(direction.x < 0){
            this.transform.localScale = new Vector3(-4,4,4);
        }
        else{
            this.transform.localScale = new Vector3(4,4,4);
        }

        if(playerInArea){
            direction.Normalize();
            rb.velocity = new Vector2((direction.x) * moveSpeed, (direction.y) * moveSpeed);
            animator.SetFloat("speed", 1f);
        }
        else{
            rb.velocity = new Vector2(0f, 0f);
            animator.SetFloat("speed", 0f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision){
        if(collision.CompareTag("Player")){
            playerInArea = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision){
        if(collision.CompareTag("Player")){
            playerInArea = false;
        }
    }
}
