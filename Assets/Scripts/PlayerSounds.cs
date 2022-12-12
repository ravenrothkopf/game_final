using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSounds : MonoBehaviour
{
    public AudioSource hit;
    public AudioSource die;

    public void playHit(){
        hit.Play();
    }

    public void playDie(){
        die.Play();
    }
}
