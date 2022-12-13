using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    private bool isOpened;
    void Start(){
        isOpened = false;
    }
    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player" && FindObjectOfType<Score>().collected)
        {
            if (!isOpened){
                Destroy(this.gameObject);
                SceneManager.LoadScene("boss battle");
                //sound fx stuff: SFXManager.sfxInstance.Audio.PlayOneShot(SFXManager.sfxInstance.Drop);
                isOpened = true;
            }
        }
        this.gameObject.GetComponent<BoxCollider2D>().isTrigger = false;
    }
    private void OnTriggerExit2D(Collider2D collision){
        this.gameObject.GetComponent<BoxCollider2D>().isTrigger = true;
    }
}
