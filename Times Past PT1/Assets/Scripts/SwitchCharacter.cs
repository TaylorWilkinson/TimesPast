using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCharacter : MonoBehaviour {

    GameObject harriet, basil;

    public int characterSelect;

    public CameraController cameraController;

    GameObject hFront, hBack, hLeft, hRight, bFront, bBack, bLeft, bRight;

    // Use this for initialization
    void Start () {
        characterSelect = 0;

        harriet = GameObject.Find("Harriet");
        basil = GameObject.Find("Basil");

        //toggle visibility by accessing the sprites' opacity
        hFront = GameObject.Find("Harriet_Front");
        hBack = GameObject.Find("Harriet_Back");
        hLeft = GameObject.Find("Harriet_Left");
        hRight = GameObject.Find("Harriet_Right");
        bFront = GameObject.Find("Basil_Front");
        bBack = GameObject.Find("Basil_Back");
        bLeft = GameObject.Find("Basil_Left");
        bRight = GameObject.Find("Basil_Right");
    }
	
	// Update is called once per frame
	void Update () {
        //change character when pressing space bar
        if (Input.GetKeyDown("space"))
        {
            //update characterSelect value
            if (characterSelect == 0) {
                characterSelect = 1;
            } else if (characterSelect == 1) {
                characterSelect = 0;
            }
        }

        if (characterSelect == 0) 
        {
            //Enable Harriet's Character Controller
            if (harriet.GetComponent<CharacterController>())
            {
                //enable movement
                harriet.GetComponent<MovementClass>().enabled = true;
                //move camera to Harriet
                cameraController.target = harriet.transform;

                //make Harriet active and visible
                hFront.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
                hBack.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
                hLeft.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
                hRight.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
            }
            //Disable Basil's Character Controller
            if (basil.GetComponent<CharacterController>())
            {
                //basil.GetComponent<CharacterController>().enabled = false;
                basil.GetComponent<MovementClass>().enabled = false;

                //make Basil inactive and transparent
                bFront.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 0.30f);
                bBack.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 0.30f);
                bLeft.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 0.30f);
                bRight.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 0.30f);
            }
        }
        else if (characterSelect == 1) {
            //Disable Harriet's Character Controller
            if (harriet.GetComponent<CharacterController>())
            {
                //disable movement
                harriet.GetComponent<MovementClass>().enabled = false;

                //make Harriet inactive and transparent
                hFront.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 0.30f);
                hBack.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 0.30f);
                hLeft.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 0.30f);
                hRight.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 0.30f);
            }
            //Enable Basil's Character Controller
            if (basil.GetComponent<CharacterController>())
            {
                //enable movement
                basil.GetComponent<MovementClass>().enabled = true;
                //move camera to Basil
                cameraController.target = basil.transform;

                //make Basil active and visible
                //make Basil inactive and transparent
                bFront.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
                bBack.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
                bLeft.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
                bRight.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
            }
        }
    }
}
