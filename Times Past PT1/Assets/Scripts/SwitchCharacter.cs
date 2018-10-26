using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCharacter : MonoBehaviour {

    GameObject harriet, basil;

    public int characterSelect;

    public CameraController cameraController;


    // Use this for initialization
    void Start () {
        characterSelect = 0;

        harriet = GameObject.Find("Harriet");
        basil = GameObject.Find("Basil");
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
                harriet.GetComponent<MovementClass>().enabled = true;
                cameraController.target = harriet.transform;
            }
            //Disable Basil's Character Controller
            if (basil.GetComponent<CharacterController>())
            {
                //basil.GetComponent<CharacterController>().enabled = false;
                basil.GetComponent<MovementClass>().enabled = false;
            }
        }
        else if (characterSelect == 1) {
            //Disable Harriet's Character Controller
            if (harriet.GetComponent<CharacterController>())
            {
                harriet.GetComponent<MovementClass>().enabled = false;
            }
            //Enable Basil's Character Controller
            if (basil.GetComponent<CharacterController>())
            {
                basil.GetComponent<MovementClass>().enabled = true;
                cameraController.target = basil.transform;
            }
        }
    }
}
