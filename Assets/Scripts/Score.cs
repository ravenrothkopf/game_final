using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    // Start is called before the first frame update
    public Text scoreText;
    private int score;
    public bool collected;
 
     void Start() {
        scoreText.text = score.ToString(); 
        score = 0;
        collected = false;
     }
 
     public void IncreaseScore() {
         score += 1;
         scoreText.GetComponent<Text>().text = score.ToString();
         if (score >= 6) {
            collected = true;
            //SFXManager.sfxInstance.Audio.PlayOneShot(SFXManager.sfxInstance.Twinkle);
         }
     }
}

