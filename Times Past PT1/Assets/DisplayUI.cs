using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayUI : MonoBehaviour {

    public string myString; //use to display text
    private Text myText; //reference to text UI element
    public string textObjName; //name of text object
    public float fadeTime; //use to fade text in and out
    private bool displayInfo; //use to determine whether or not to display text


	// Use this for initialization
	void Start () {

        //myText = GameObject.Find("Text").GetComponent<Text>();
        myText = GameObject.Find(textObjName).GetComponent<Text>();
        myText.color = Color.clear; //make invisible at start

        //hide cursor
        //Screen.showCursor = false;

        //lock cursor to center of screen
        //Screen.lockCursor = true;
		
	}
	
	// Update is called once per frame
	void Update () {

        FadeText();

        /*
        if (Input.GetKeyDown)
        */
		
	}

    void OnMouseOver()
    {
        //show info when hovering
        displayInfo = true;
    }

    void OnMouseExit()
    {
        //when not hovering, hide info
        displayInfo = false;
    }

    void FadeText() {
        if (displayInfo) {
            myText.text = myString;
            myText.color = Color.Lerp(myText.color, Color.white, fadeTime * Time.deltaTime);
            //use Lerp (linear interpolation) to change color from 1st color (clear) to white over given time
        } else {
            myText.color = Color.Lerp(myText.color, Color.clear, fadeTime * Time.deltaTime);
            //use Lerp to change color from white back to clear
        }
    }
}
