using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UITextTypewriter : MonoBehaviour
{
    Text txt;
    string story;
    public bool complete = false;
    // Start is called before the first frame update
    void Start()
    {
        txt = GetComponent<Text>();
        story = txt.text;
        txt.text = "";

        StartCoroutine("PlayText");
    }

    IEnumerator PlayText()
    {
        foreach (char c in story)
        {
            txt.text += c;
            yield return new WaitForSeconds(0.025f);
        }
        complete = true;
    }

}
