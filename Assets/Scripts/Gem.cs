using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{
    private bool isCollected;
    void Start(){
        isCollected = false;
    }
    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if (!isCollected){
                Destroy(this.gameObject);
                //sound fx stuff: SFXManager.sfxInstance.Audio.PlayOneShot(SFXManager.sfxInstance.Drop);
                FindObjectOfType<Score>().IncreaseScore();
                isCollected = true;
            }
        }
    }
}
