using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
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
