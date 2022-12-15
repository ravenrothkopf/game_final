using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader: MonoBehaviour
{
    [SerializeField]
    private float delayBeforeLoading = 10f;
    private float timeElapsed;
    [SerializeField]
    public Player playerobj;

    void Update()
    {
        timeElapsed += Time.deltaTime;

        if (timeElapsed > delayBeforeLoading && playerobj.isAlive == false)
        {
            SceneManager.LoadScene("Game_Over_Lose");
        }
    }
}
