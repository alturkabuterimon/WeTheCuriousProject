using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypingText : MonoBehaviour {
    //This is attatched to the text component with the full text already written out, but this doesn't work with a button so... 

    public int numOfButtonsPressed = 0;
    public AudioSource typingSound;

    Text txt;
    string Test;
    public GameObject correctDialogueBox, finalButton;


    void Start()
    {
        //Get the text that needs to be typed

        txt = GetComponentInChildren<Text>();
        Test = txt.text; //set the text as a string
        txt.text = ""; //set the text as blank before it's written

        correctDialogueBox.SetActive(false);
        finalButton.SetActive(false); //Button that moves onto the next scene. Appears only after numOfButtonsPressed = 5

    }
        public void OnClick()
    {
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

        yield return new WaitForSeconds(1.5f); //waits 1.5 seconds before clearing the text from the screen
        
        txt.text = "";
        correctDialogueBox.SetActive(true);

        numOfButtonsPressed += 1;
        Debug.Log(numOfButtonsPressed);

        if(numOfButtonsPressed == 5)
        {
            finalButton.SetActive(true);
        }
    }
}
