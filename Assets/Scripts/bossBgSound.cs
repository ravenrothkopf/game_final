using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossBgSound : MonoBehaviour
{
    public AudioSource bg;

    public void stopBg(){
        if(bg.isPlaying)
        {
            Debug.Log("stop bg");
            bg.Stop();
        }
    }

}
