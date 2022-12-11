using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{
    private bool isCollected;
    public AudioSource audioSource;
    public AudioClip collectClip;

    void Start(){
        isCollected = false;
    }
    // Update is called once per frame
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if (!isCollected){
                audioSource.Play();
                transform.position = Vector3.one * 9999f;
                Destroy(this.gameObject, collectClip.length);
                //sound fx stuff: SFXManager.sfxInstance.Audio.PlayOneShot(SFXManager.sfxInstance.Drop);
                FindObjectOfType<Score>().IncreaseScore();
                isCollected = true;
            }
        }
    }
}
