using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogueOnClick : MonoBehaviour {

    //[SerializeField]
    //GameObject playerSpeaking;

    //[SerializeField]
    //GameObject dialogueCanvas;

    [SerializeField]
    GameObject dialogueHarriet;
    [SerializeField]
    GameObject dialogueBasil;
    [SerializeField]
    GameObject dialogueAltBasil;

    //public TextMeshProUGUI harrietNameDisplay;
    public TextMeshProUGUI harrietDialogDisplay;

    //public TextMeshProUGUI basilNameDisplay;
    public TextMeshProUGUI basilDialogDisplay;

    public TextMeshProUGUI altDialogDisplay;

    public string harrietDialogue;

    public string basilDialogue;

    public string basilAltDialogue;

    /*
    public TextMeshProUGUI nameDisplay;
    public TextMeshProUGUI dialogDisplay;
    */

    //character switch control
    GameObject characterSwitchControl;
    bool harrietActive;
    bool basilActive;

    //Dialogue delay value
    float delaySeconds = 2f;

    public bool harrietHasClicked;
    GameObject interactionChecker;

    void Start() {
        characterSwitchControl = GameObject.Find("CharacterSwitchControl");

        harrietActive = true;
        basilActive = false;

        //dialogueCanvas.GetComponent<Canvas>().enabled = false;

        dialogueHarriet.GetComponent<Canvas>().enabled = false;
        dialogueBasil.GetComponent<Canvas>().enabled = false;
        dialogueAltBasil.GetComponent<Canvas>().enabled = false;

        harrietHasClicked = false;
        interactionChecker = GameObject.Find("Win State Controller");
    }

    void Update() {
        //determine active character
        if ((characterSwitchControl.GetComponent<SwitchCharacter>().characterSelect) == 0)
        {
            harrietActive = true;
            basilActive = false;
        }
        else if ((characterSwitchControl.GetComponent<SwitchCharacter>().characterSelect) == 1)
        {
            basilActive = true;
            harrietActive = false;
        }
        //print("Basil change: " + interactionChecker.GetComponent<InteractionTrigger>().basilDialogueChange);

        clickAndUpdateCanvas();
    }

    void clickAndUpdateCanvas() {
        if (Input.GetMouseButtonDown(0)) {
            RaycastHit hit;
            //turn screenpoint into ray, from the camera into mouse position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 100.0f)) {
                if (hit.transform != null) {
                    //print("hit: " + hit.transform.gameObject + ", this: " + this.transform.gameObject);

                    CapsuleCollider cc;
                    if (cc = hit.transform.GetComponent<CapsuleCollider>()) {
                        if (hit.transform.gameObject == this.transform.gameObject) {
                            //check if object being clicked is equal to the "this" object the script is attached to.
                            if (harrietActive == true) {
                                harrietHasClicked = true;
                                dialogueHarriet.GetComponent<Canvas>().enabled = true;
                                harrietDialogDisplay.text = harrietDialogue;

                                StartCoroutine(CloseDialogueTimer());
                            }
                            else if (basilActive == true) {
                                //dialogueBasil.GetComponent<Canvas>().enabled = true;
                                //basilDialogDisplay.text = basilDialogue;
                                //check if Basil's dialogue has changed
                                if (interactionChecker.GetComponent<InteractionTrigger>().basilDialogueChange == false)
                                {
                                    dialogueBasil.GetComponent<Canvas>().enabled = true;
                                    basilDialogDisplay.text = basilDialogue;
                                    StartCoroutine(CloseDialogueTimer());
                                }
                                else if (interactionChecker.GetComponent<InteractionTrigger>().basilDialogueChange == true)
                                {
                                    //dialogueBasil.GetComponent<Canvas>().enabled = true;
                                    //basilDialogDisplay.text = basilAltDialogue;
                                    //StartCoroutine(CloseDialogueTimer());

                                    if (interactionChecker.GetComponent<InteractionTrigger>().basilDialogueChange == true)
                                    {
                                        //print("DIALOGUE CHANGES!");
                                        dialogueAltBasil.GetComponent<Canvas>().enabled = true;
                                        altDialogDisplay.text = basilAltDialogue;
                                        StartCoroutine(CloseDialogueTimer());
                                    }
                                    else if (interactionChecker.GetComponent<InteractionTrigger>().basilDialogueChange == false) {
                                        //print("normal dialog");
                                        dialogueBasil.GetComponent<Canvas>().enabled = true;
                                        basilDialogDisplay.text = basilAltDialogue;
                                        StartCoroutine(CloseDialogueTimer());
                                    }
                                }
                            }
                        }
                    }

                    BoxCollider bc;
                    if (bc = hit.transform.GetComponent<BoxCollider>()) {
                        if (hit.transform.gameObject == this.transform.gameObject) {
                            //check if object being clicked is equal to the "this" object the script is attached to.
                            if (harrietActive == true) {
                                harrietHasClicked = true;
                                dialogueHarriet.GetComponent<Canvas>().enabled = true;
                                harrietDialogDisplay.text = harrietDialogue;

                                StartCoroutine(CloseDialogueTimer());
                            }
                            else if (basilActive == true) {
                                //dialogueBasil.GetComponent<Canvas>().enabled = true;
                                //basilDialogDisplay.text = basilDialogue;
                                //check if Basil's dialogue has changed
                                if (interactionChecker.GetComponent<InteractionTrigger>().basilDialogueChange == false)
                                {
                                    dialogueBasil.GetComponent<Canvas>().enabled = true;
                                    basilDialogDisplay.text = basilDialogue;
                                    StartCoroutine(CloseDialogueTimer());
                                }
                                else if (interactionChecker.GetComponent<InteractionTrigger>().basilDialogueChange == true) {
                                    //dialogueBasil.GetComponent<Canvas>().enabled = true;
                                    //basilDialogDisplay.text = basilAltDialogue;
                                    //StartCoroutine(CloseDialogueTimer());

                                    if (interactionChecker.GetComponent<InteractionTrigger>().basilDialogueChange == true) {
                                        //print("DIALOGUE CHANGES!");
                                        dialogueAltBasil.GetComponent<Canvas>().enabled = true;
                                        altDialogDisplay.text = basilAltDialogue;
                                        StartCoroutine(CloseDialogueTimer());
                                    } else if (interactionChecker.GetComponent<InteractionTrigger>().basilDialogueChange == false) {
                                        //print("normal dialog");
                                        dialogueBasil.GetComponent<Canvas>().enabled = true;
                                        basilDialogDisplay.text = basilAltDialogue;
                                        StartCoroutine(CloseDialogueTimer());
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }

    IEnumerator CloseDialogueTimer() {
        yield return new WaitForSeconds(delaySeconds);

        //print(delaySeconds);

        //dialogueCanvas.GetComponent<Canvas>().enabled = false;
        dialogueHarriet.GetComponent<Canvas>().enabled = false;
        dialogueBasil.GetComponent<Canvas>().enabled = false;
        dialogueAltBasil.GetComponent<Canvas>().enabled = false;
    }
}
