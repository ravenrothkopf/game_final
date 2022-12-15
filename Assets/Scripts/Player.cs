using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    // moving player
    public float playerSpeed = 5f;
    private Rigidbody2D rb;
    private Vector2 playerDirection;

    // animation contorller
    public Animator anim;
    public Animator enemyAnim;

    // health
    public int maxHealth;
    int curHealth;
    public bool isAlive = true;
    public healthbar healthbar;

    //load next scene
    [SerializeField]
    private float delayBeforeLoading = 10f;
    [SerializeField]
    private string sceneNameToLoad;
    private float timeElapsed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        curHealth = maxHealth;
        healthbar.SetMaxHealth(maxHealth);
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

        timeElapsed += Time.deltaTime;
        
        if (timeElapsed > delayBeforeLoading && isAlive == false)
        {
            SceneManager.LoadScene("Game_Over_Lose");
        }
    
    }

    void FixedUpdate(){
        rb.velocity = new Vector2(playerDirection.x * playerSpeed, playerDirection.y * playerSpeed);
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
        isAlive = false;
        GameObject.FindGameObjectWithTag("bg").GetComponent<bossBgSound>().stopBg();
        rb.constraints = RigidbodyConstraints2D.FreezePosition;
        anim.SetBool("isDead", true);
        this.enabled = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("collision");
        if(collision.gameObject.tag == "Door" && FindObjectOfType<Score>().collected)
        {
            SceneManager.LoadScene("boss battle");
            //sound fx stuff: SFXManager.sfxInstance.Audio.PlayOneShot(SFXManager.sfxInstance.Drop);
        }
    }
}

 
