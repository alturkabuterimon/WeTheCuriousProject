using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypingText4 : MonoBehaviour {

    //This is attatched to the text component with the full text already written out, but this doesn't work with a button so... 

    Text txt;
    string Test;
    public GameObject correctBox, finalButton;
    public AudioSource typingSound;


    void Start()
    {
        //Get the text that needs to be typed

        txt = GetComponentInChildren<Text>();
        Test = txt.text; //set the text as a string
        txt.text = ""; //set the text as blank before it's written

        correctBox.SetActive(false);
        finalButton.SetActive(false);

    }
    public void OnClick()
    {
        Debug.Log("working2");
        StartCoroutine("PlayText");
    }

    IEnumerator PlayText()
    {
        typingSound.Play();
        foreach (char c in Test)
        {
            txt.text += c; //Advances the text by one character at a time. 
            yield return new WaitForSeconds(0.125f); //Waits a bit before typing the new character
        }
        typingSound.Pause();

        yield return new WaitForSeconds(1.5f);
        txt.text = "";
        correctBox.SetActive(true);

        GameObject.Find("TextTyper").GetComponent<TypingText>().numOfButtonsPressed += 1; //increments the number of buttons pressed by 1
        Debug.Log(GameObject.Find("TextTyper").GetComponent<TypingText>().numOfButtonsPressed);

        if (GameObject.Find("TextTyper").GetComponent<TypingText>().numOfButtonsPressed == 5)
        {
            finalButton.SetActive(true);
        }
    }
}
