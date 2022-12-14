using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player" && FindObjectOfType<Score>().collected)
        {
            SceneManager.LoadScene("boss battle");
            //sound fx stuff: SFXManager.sfxInstance.Audio.PlayOneShot(SFXManager.sfxInstance.Drop);
        }
    }
}
