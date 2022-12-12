using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySounds : MonoBehaviour
{
    AudioSource aud;

    void Start(){
        aud = GetComponent<AudioSource>();
    }

    public void playSound(){
        aud.Play();
    }
}
