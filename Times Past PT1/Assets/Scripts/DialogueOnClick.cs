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
    GameObject dialogueAltHarriet;
    [SerializeField]
    GameObject dialogueBasil;
    [SerializeField]
    GameObject dialogueAltBasil;

    //public TextMeshProUGUI harrietNameDisplay;
    public TextMeshProUGUI harrietDialogDisplay;

    public TextMeshProUGUI altHarrietDialogDisplay;

    //public TextMeshProUGUI basilNameDisplay;
    public TextMeshProUGUI basilDialogDisplay;

    public TextMeshProUGUI altDialogDisplay;

    public string harrietDialogue;
    public string harrietAltDialogue;
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
    public bool basilHasClicked;
    public bool basilHasClicked2;
    GameObject interactionChecker;

    void Start() {
        characterSwitchControl = GameObject.Find("CharacterSwitchControl");

        harrietActive = true;
        basilActive = false;

        //dialogueCanvas.GetComponent<Canvas>().enabled = false;
        dialogueHarriet.GetComponent<Canvas>().enabled = false;
        dialogueAltHarriet.GetComponent<Canvas>().enabled = false;
        dialogueBasil.GetComponent<Canvas>().enabled = false;
        dialogueAltBasil.GetComponent<Canvas>().enabled = false;

        harrietHasClicked = false;
        basilHasClicked = false;
        basilHasClicked2 = false;
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
        //print("engraving click: " + interactionChecker.GetComponent<InteractionTrigger>().basilDialogueChange + ", vines click: " + interactionChecker.GetComponent<InteractionTrigger>().basilDialogueChange2);

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
                            //harriet is clicking
                            if (harrietActive == true) {
                                harrietHasClicked = true;

                                dialogueHarriet.GetComponent<Canvas>().enabled = true;
                                harrietDialogDisplay.text = harrietDialogue;
                                StartCoroutine(CloseDialogueTimer());
                            }
                            //basil is clicking
                            else if (basilActive == true) {
                                if ((this.name == "Grass_g_01"))
                                {
                                    //for tapestry check: basilDialogueChange1 = true;
                                    if (interactionChecker.GetComponent<InteractionTrigger>().basilDialogueChange == false)
                                    {
                                        //Debug.Log("Tapestry Hasn't Changed");
                                        dialogueBasil.GetComponent<Canvas>().enabled = true;
                                        basilDialogDisplay.text = basilDialogue;
                                        StartCoroutine(CloseDialogueTimer());
                                    }
                                    else if (interactionChecker.GetComponent<InteractionTrigger>().basilDialogueChange == true)
                                    {
                                        //Debug.Log("Tapestry Changed");
                                        dialogueAltBasil.GetComponent<Canvas>().enabled = true;
                                        altDialogDisplay.text = basilAltDialogue;
                                        StartCoroutine(CloseDialogueTimer());
                                    }
                                } else {
                                    dialogueBasil.GetComponent<Canvas>().enabled = true;
                                    basilDialogDisplay.text = basilDialogue;
                                    StartCoroutine(CloseDialogueTimer());
                                }
                            }
                        }
                    }

                    BoxCollider bc;
                    if (bc = hit.transform.GetComponent<BoxCollider>())
                    {
                        if (hit.transform.gameObject == this.transform.gameObject)
                        {
                            //harriet is clicking
                            if (harrietActive == true)
                            {
                                harrietHasClicked = true;

                                if ((this.name == "square-bush") || (this.name == "square-bush (1)") || (this.name == "square-bush (2)") || (this.name == "square-bush (3)")) {
                                    //Debug.Log("Clicking the tree stairs");
                                    if (interactionChecker.GetComponent<InteractionTrigger>().harrietDialogueChange == true)
                                    {
                                        dialogueAltHarriet.GetComponent<Canvas>().enabled = true;
                                        altHarrietDialogDisplay.text = harrietAltDialogue;
                                        StartCoroutine(CloseDialogueTimer());
                                    }
                                    else if (interactionChecker.GetComponent<InteractionTrigger>().harrietDialogueChange == false)
                                    {
                                        dialogueHarriet.GetComponent<Canvas>().enabled = true;
                                        harrietDialogDisplay.text = harrietDialogue;
                                        StartCoroutine(CloseDialogueTimer());
                                    }
                                }
                                else
                                {
                                    dialogueHarriet.GetComponent<Canvas>().enabled = true;
                                    harrietDialogDisplay.text = harrietDialogue;
                                    StartCoroutine(CloseDialogueTimer());
                                }
                                /*
                                dialogueHarriet.GetComponent<Canvas>().enabled = true;
                                harrietDialogDisplay.text = harrietDialogue;
                                StartCoroutine(CloseDialogueTimer());
                                */
                            }
                            //basil is clicking
                            else if (basilActive == true)
                            {
                                if ((this.name == "Tapestry Kah") || (this.name == "Bushes"))
                                {
                                    //for tapestry check: basilDialogueChange1 = true;
                                    if (interactionChecker.GetComponent<InteractionTrigger>().basilDialogueChange == false)
                                    {
                                        //Debug.Log("Tapestry Hasn't Changed");
                                        dialogueBasil.GetComponent<Canvas>().enabled = true;
                                        basilDialogDisplay.text = basilDialogue;
                                        StartCoroutine(CloseDialogueTimer());
                                    }
                                    else if (interactionChecker.GetComponent<InteractionTrigger>().basilDialogueChange == true)
                                    {
                                        //Debug.Log("Tapestry Changed");
                                        dialogueAltBasil.GetComponent<Canvas>().enabled = true;
                                        altDialogDisplay.text = basilAltDialogue;
                                        StartCoroutine(CloseDialogueTimer());
                                    }
                                }
                                else if ((this.name == "BackMirrorLight") || (this.name == "MiddleMirrorLight") || (this.name == "FarMirrorLight"))
                                {
                                    //for mirrors check: basilDialogueChange2 = true;
                                    if (interactionChecker.GetComponent<InteractionTrigger>().basilDialogueChange2 == false)
                                    {
                                        //Debug.Log("Mirrors Hasn't Changed");
                                        dialogueBasil.GetComponent<Canvas>().enabled = true;
                                        basilDialogDisplay.text = basilDialogue;
                                        StartCoroutine(CloseDialogueTimer());
                                    }
                                    else if (interactionChecker.GetComponent<InteractionTrigger>().basilDialogueChange2 == true)
                                    {
                                        //Debug.Log("Mirrors Changed");
                                        dialogueAltBasil.GetComponent<Canvas>().enabled = true;
                                        altDialogDisplay.text = basilAltDialogue;
                                        StartCoroutine(CloseDialogueTimer());
                                    }
                                } else {
                                    dialogueBasil.GetComponent<Canvas>().enabled = true;
                                    basilDialogDisplay.text = basilDialogue;
                                    StartCoroutine(CloseDialogueTimer());
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
        dialogueAltHarriet.GetComponent<Canvas>().enabled = false;
        dialogueBasil.GetComponent<Canvas>().enabled = false;
        dialogueAltBasil.GetComponent<Canvas>().enabled = false;
    }
}
