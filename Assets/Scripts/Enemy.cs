using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform player;

    public float moveSpeed;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
    }

    void FixedUpdate(){
        Vector2 direction = (Vector2)player.position - rb.position;
        direction.Normalize();
        rb.velocity = new Vector2((direction.x) * moveSpeed, (direction.y) * moveSpeed);
    }
}
