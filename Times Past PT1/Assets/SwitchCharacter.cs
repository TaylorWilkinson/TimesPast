using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCharacter : MonoBehaviour {

    GameObject harriet, basil;
    int characterSelect;

    // Use this for initialization
    void Start () {
        characterSelect = 1;

        harriet = GameObject.Find("Harriet");
        basil = GameObject.Find("Basil");
    }
	
	// Update is called once per frame
	void Update () {
        //change character when pressing space bar
        if (Input.GetKeyDown("space"))
        {
            //Debug.Log("Space bar pressed");

            //update characterSelect value
            if (characterSelect == 1) {

                characterSelect = 2;

            } else if (characterSelect == 2) {

                characterSelect = 1;
            }
        }

        if (characterSelect == 1) {
            //Enable Harriet's Character Controller
            if (harriet.GetComponent<CharacterController>())
            {
                //harriet.GetComponent<CharacterController>().enabled = true;
                harriet.GetComponent<MovementClass>().enabled = true;
            }
            //Disable Basil's Character Controller
            if (basil.GetComponent<CharacterController>())
            {
                //basil.GetComponent<CharacterController>().enabled = false;
                basil.GetComponent<MovementClass>().enabled = false;
            }
        }
        else if (characterSelect == 2) {
            //Disable Harriet's Character Controller
            if (harriet.GetComponent<CharacterController>())
            {
                //harriet.GetComponent<CharacterController>().enabled = false;
                harriet.GetComponent<MovementClass>().enabled = false;
            }
            //Enable Basil's Character Controller
            if (basil.GetComponent<CharacterController>())
            {
                //basil.GetComponent<CharacterController>().enabled = true;
                basil.GetComponent<MovementClass>().enabled = true;
            }

            /*
             * player.SetActive(t/f); doesn't work because toggles visability
             * try this with toggling environment items
            harriet.SetActive(false);
            basil.SetActive(true);
            */
        }
    }
}
