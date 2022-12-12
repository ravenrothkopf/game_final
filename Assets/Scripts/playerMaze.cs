using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMaze : MonoBehaviour
{
    // moving player
    public float playerSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 playerDirection;

    // animation contorller
    public Animator anim;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float directionY = Input.GetAxisRaw("Vertical");
        float directionX = Input.GetAxisRaw("Horizontal");
        playerDirection = new Vector2(directionX, directionY).normalized;

        if(directionX<0){
            this.transform.localScale = new Vector3(-0.12f,0.12f,0.12f);
        }
        else if(directionX>0){
            this.transform.localScale = new Vector3(0.12f,0.12f,0.12f);
        }

        if( Mathf.Abs(directionX)*playerSpeed > 0 || Mathf.Abs(directionY)*playerSpeed > 0){
            anim.SetBool("speed", true);
        }
        else{
            anim.SetBool("speed", false);
        }
    
    }

    void FixedUpdate(){
        rb.velocity = new Vector2(playerDirection.x * playerSpeed, playerDirection.y * playerSpeed);
    }
}
