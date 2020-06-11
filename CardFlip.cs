using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

//Code modified from: http://www.programmersought.com/article/7433161693/

//whether the card is on the front or back
public enum CardState
{
    front, back
}


public class CardFlip : MonoBehaviour {

    public GameObject frontOfCard, backOfCard; //front and back of card
    public CardState cardState = CardState.front; //current state of card
    public float time = 0.3f;
    public bool isActive = true; //true mean flip is happening

    //Initialise the angle of the card according to it's state
    public void Initalise()
    {
        if(cardState == CardState.front)
        {
            frontOfCard.transform.eulerAngles = Vector3.zero;
            backOfCard.transform.eulerAngles = new Vector3(0, 90, 0);
        }
        else
        {
            frontOfCard.transform.eulerAngles = new Vector3(0, 90, 0);
            backOfCard.transform.eulerAngles = Vector3.zero;
        }
    }

    // Use this for initialization
    void Start()
    {
        Initalise();
    }

    //If the card starts on it's back
    public void StartBack()
    {
        if (isActive)
        {
            Debug.Log(isActive);
            StartCoroutine(ToBack());
        }
    }


    //Coroutines to flip to back. 
    IEnumerator ToBack()
    {
        Debug.Log("Animation started");
        isActive = true;
        frontOfCard.transform.DORotate(new Vector3(0, 90, 0), time);

        for (float i = time; i >= 0; i -= Time.deltaTime)
        {
            yield return 0;
            backOfCard.transform.DORotate(new Vector3(0, 0, 0), time);
        }
            
    }
}
