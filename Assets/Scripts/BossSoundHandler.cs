using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossSoundHandler : MonoBehaviour
{
    public AudioSource bgMusic;
    public AudioSource deathSound;
    public AudioSource winSound;

    public bool bg = true;
    public bool death = false;
    public bool win = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void BgMusic(){
        bg = true;
        death = false;
        bgMusic.Play();
    }

    public void EndSound(){
        if(bgMusic.isPlaying)
            bg = false;
        {
            bg.Stop();
        }
        if(death){
            
        }
        

    }
}
