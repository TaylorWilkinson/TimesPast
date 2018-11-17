using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ObjectInteraction : MonoBehaviour {

    //character switch control
    GameObject characterSwitchControl;
    bool harrietActive;
    bool basilActive;

    public int characterSelect;
    GameObject harriet, basil;

    public string objectName;
    public string objectNameInOtherTime;

    // Below from ClickableObject.cs
    //
    GameObject otherObject;
    //Mirror Puzzle Objects
    GameObject rubble, middleLight, rightLight, middleMirror, rightMirror;
    GameObject halfPillarR1, halfPillarR2, fullPillarR1, fullPillarR2, newPillar, newPillar2, newVinesR1, newVinesR2;
    GameObject plateL1, plateL2, plateL3, plateL4, plateR1, plateR2, plateR3, plateR4;
    GameObject inscriptionL, inscriptionR, inscriptionLCorrect, inscriptionRCorrect;

    //Clickable Dialogue Objects
    GameObject canvas1, nameText, dialogueText;
    //Dialogue TextMesh Displays
    public TextMeshProUGUI nameDisplay;
    public TextMeshProUGUI dialogDisplay;

    int posValueL;
    int posValueR;

    Vector3 targetPosition;
    Vector3 lookAtTarget;
    Vector3 offsetCharacter;
    Quaternion playerRot;

    Vector3 mirrorRotation;

    Vector3 platePosition1;
    Vector3 platePosition2;
    Vector3 platePosition3;
    Vector3 platePosition4;
    Vector3 platePositionR1;
    Vector3 platePositionR2;
    Vector3 platePositionR3;
    Vector3 platePositionR4;

    //Rotating Mirror values
    [SerializeField]
    private int totalRotate = 4;
    [SerializeField]
    private int rotateCount = 0;
    [SerializeField]
    private int winningFaceCount = 2;
    [SerializeField]
    private Light mirrorLight;
    [SerializeField]
    private int[] reflectiveValues;
    private int middleRotateCount = 0;
    private int rightRotateCount = 0;
    bool correctRotation;

    bool correctMirrors;
    bool correctPlates;

    // Use this for initialization
    void Start() {
        characterSwitchControl = GameObject.Find("CharacterSwitchControl");
        characterSelect = 0;
        harriet = GameObject.Find("Harriet");
        basil = GameObject.Find("Basil");

        //Interactive Dialog
        canvas1 = GameObject.Find("Canvas1");
        //canvas1.SetActive(false);
        canvas1.GetComponent<Canvas>().enabled = false;

        //BELOW FROM OTHER SCRIPT VVVVV
        //instantiate game objects
        otherObject = GameObject.Find(objectNameInOtherTime);

        middleLight = GameObject.Find("Point Light Middle");
        rightLight = GameObject.Find("Point Light Right");

        middleMirror = GameObject.Find("MirrorMiddle");
        rightMirror = GameObject.Find("MirrorRight");

        rubble = GameObject.Find("Caved In Rubble");

        halfPillarR1 = GameObject.Find("Half Pillar Right");
        halfPillarR2 = GameObject.Find("Half Pillar Right 2");
        fullPillarR1 = GameObject.Find("Full Pillar Right");
        fullPillarR2 = GameObject.Find("Full Pillar Right 2");
        newVinesR1 = GameObject.Find("New Vines Right 1");
        newVinesR2 = GameObject.Find("New Vines Right 2");
        newPillar = GameObject.Find("New Pillar Right");
        newPillar2 = GameObject.Find("New Pillar Right 2");

        plateL1 = GameObject.Find("PlateL1");
        plateL2 = GameObject.Find("PlateL2");
        plateL3 = GameObject.Find("PlateL3");
        plateL4 = GameObject.Find("PlateL4");
        plateR1 = GameObject.Find("PlateR1");
        plateR2 = GameObject.Find("PlateR2");
        plateR3 = GameObject.Find("PlateR3");
        plateR4 = GameObject.Find("PlateR4");

        platePosition1 = new Vector3(8.5f, 2.1f, 11.7f);
        platePosition2 = new Vector3(8.5f, 2.1f, 10.6f);
        platePosition3 = new Vector3(8.5f, 2.1f, 9.4f);
        platePosition4 = new Vector3(8.5f, 2.1f, 8.2f);

        platePositionR1 = new Vector3(8.5f, 2.1f, -9.2f);
        platePositionR2 = new Vector3(8.5f, 2.1f, -10.3f);
        platePositionR3 = new Vector3(8.5f, 2.1f, -11.5f);
        platePositionR4 = new Vector3(8.5f, 2.1f, -8.0f);

        int posValueL = 0;
        int posValueR = 0;

        offsetCharacter = new Vector3(-20, 10, 0);

        mirrorRotation = new Vector3(0, 90, 0);

        correctRotation = false;

        //glowing inscriptions
        inscriptionL = GameObject.Find("inscription left language");
        inscriptionLCorrect = GameObject.Find("inscription left language correct");
        inscriptionR = GameObject.Find("inscription right language");
        inscriptionRCorrect = GameObject.Find("inscription right language correct");

        //set up inscription SpriteRenderer states
        inscriptionL.GetComponent<SpriteRenderer>().enabled = true;
        inscriptionLCorrect.GetComponent<SpriteRenderer>().enabled = false;
        inscriptionR.GetComponent<SpriteRenderer>().enabled = true;
        inscriptionRCorrect.GetComponent<SpriteRenderer>().enabled = false;

        correctMirrors = false;
        correctPlates = false;

    }

    // Update is called once per frame
    void Update() {
        /*
        //old movement 
        characterSwitchUpdate();

        if (characterSelect == 0)
        {
            HarrietInteractions();
        }
        else if (characterSelect == 1)
        {
            BasilInteractions();
        }
        */

        //Debug.Log(characterSwitchControl.GetComponent<SwitchCharacter>().characterSelect);

        if ((characterSwitchControl.GetComponent<SwitchCharacter>().characterSelect) == 0)
        {
            HarrietInteractions();
            harrietActive = true;
            basilActive = false;
            //print("HARRIET ACTIVE");
        }
        else if ((characterSwitchControl.GetComponent<SwitchCharacter>().characterSelect) == 1)
        {
            BasilInteractions();
            basilActive = true;
            harrietActive = false;
            //print("BASIL ACTIVE WOWOWOOW");
        }

        /*
        //If both rotation values are correct, remove the rubble and fix the pillars
        if (((middleMirror.GetComponent<ObjectInteraction>().middleRotateCount) == 3) && ((rightMirror.GetComponent<ObjectInteraction>().rightRotateCount) == 1))
        {
            //print("READY");
            rightMirror.GetComponent<ObjectInteraction>().mirrorLight.enabled = true;
            Destroy(rubble);

            //remove half pillars, and make them full
            Destroy(halfPillarR1);
            Destroy(halfPillarR2);
            newPillar.GetComponent<MeshRenderer>().enabled = true;
            newPillar2.GetComponent<MeshRenderer>().enabled = true;
            newVinesR1.GetComponentInChildren<MeshRenderer>().enabled = true;
            newVinesR2.GetComponentInChildren<MeshRenderer>().enabled = true;

            //stop rotation
            mirrorRotation = new Vector3(0, 0, 0);
        }

        //Check for correct table arrangements
        if ((characterSelect == 0) && (posValueL == 2) && (posValueR == 3))
        {
            print("YOU'VE SOLVED MY TABLE RIDDLE");
        }
        */
        //SOLVING MIRROR PUZZLE
        //If both rotation values are correct, remove the rubble and fix the pillars
        if (((middleMirror.GetComponent<ObjectInteraction>().middleRotateCount) == 3) && ((rightMirror.GetComponent<ObjectInteraction>().rightRotateCount) == 1))
        {
            //print("READY");
            rightMirror.GetComponent<ObjectInteraction>().mirrorLight.enabled = true;
            Destroy(rubble);

            //remove half pillars, and make them full
            Destroy(halfPillarR1);
            Destroy(halfPillarR2);
            newPillar.GetComponent<MeshRenderer>().enabled = true;
            newPillar2.GetComponent<MeshRenderer>().enabled = true;
            newVinesR1.GetComponentInChildren<MeshRenderer>().enabled = true;
            newVinesR2.GetComponentInChildren<MeshRenderer>().enabled = true;

            correctMirrors = true;
        }

        //print(posValueR);


        //SOLVING PLATE PUZZLE
        //Make engraving glow when arranged correctly
        if (posValueL == 2)
        {
            //Debug.Log("Correct Left Plates");
            //inscriptionL.GetComponent<SpriteRenderer>().enabled = false;
            //inscriptionLCorrect.GetComponent<SpriteRenderer>().enabled = true;
        }

        if (posValueR == 3)
        {
            //Debug.Log("Correct Right Plates");
            //inscriptionR.GetComponent<SpriteRenderer>().enabled = false;
            //inscriptionRCorrect.GetComponent<SpriteRenderer>().enabled = true;
        }

        //Check for correct table arrangements
        if ((characterSelect == 0) && (posValueL == 2) && (posValueR == 3))
        {
            //print("YOU'VE SOLVED MY TABLE RIDDLE");
            //tell player they got correct orientation

            //correctPlates = true;
        }
    } //end update

    void characterSwitchUpdate()
    {
        //change character when pressing space bar
        if (Input.GetKeyDown("space"))
        {
            //update characterSelect value
            if (characterSelect == 0)
            {
                characterSelect = 1;
            }
            else if (characterSelect == 1)
            {
                characterSelect = 0;
            }
        }
        //print(characterSelect);
    }


    void HarrietInteractions()
    {
        //print("HARRIET IN CONTROL");
        if (Input.GetMouseButtonDown(0))
        {

            RaycastHit hit;
            //turn screenpoint into ray, from the camera into mouse position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                if (hit.transform != null)
                {
                    //PrintName(hit.transform.gameObject);

                    CapsuleCollider cc;
                    if (cc = hit.transform.GetComponent<CapsuleCollider>())
                    {
                        //
                    }

                    BoxCollider bc;
                    if (bc = hit.transform.GetComponent<BoxCollider>())
                    {
                        //MIRROR TESTS
                        if (bc.name == "MirrorMiddle")
                        {
                            /*
                            canvas1.GetComponent<Canvas>().enabled = true;
                            nameDisplay.text = "Harriet";
                            dialogDisplay.text = "This looks like it should move, but I’m just too small to do it!";
                            //print("Harriet can't rotate!");
                            */
                            if (correctMirrors == false)
                            {
                                canvas1.GetComponent<Canvas>().enabled = true;
                                nameDisplay.text = "Harriet";
                                dialogDisplay.text = "This looks like it should move, but I’m just too small to do it!";
                            }
                            else if (correctMirrors == true)
                            {
                                canvas1.GetComponent<Canvas>().enabled = true;
                                nameDisplay.text = "Harriet";
                                dialogDisplay.text = "Good job Basil! The light has made plants grow, and now the cave-in never happened!";
                            }
                        }
                        if (bc.name == "MirrorRight")
                        {
                            /*
                            canvas1.GetComponent<Canvas>().enabled = true;
                            nameDisplay.text = "Harriet";
                            dialogDisplay.text = "This looks like it should move, but I’m just too small to do it!";
                            //print("Harriet can't rotate!");
                            */
                            if (correctMirrors == false)
                            {
                                canvas1.GetComponent<Canvas>().enabled = true;
                                nameDisplay.text = "Harriet";
                                dialogDisplay.text = "This looks like it should move, but I’m just too small to do it!";
                            }
                            else if (correctMirrors == true)
                            {
                                canvas1.GetComponent<Canvas>().enabled = true;
                                nameDisplay.text = "Harriet";
                                dialogDisplay.text = "Good job Basil! The light has made plants grow, and now the cave-in never happened";
                            }
                        }

                        //TABLE TESTS
                        //Plate puzzle, Harriet or Basil can do
                        if (bc.name == "Table and Plates Left")
                        {
                            canvas1.GetComponent<Canvas>().enabled = true;
                            nameDisplay.text = "Harriet";
                            dialogDisplay.text = "All that practice setting the table for my mother led to this!";
                            LeftPlateRotation();
                        }
                        if (bc.name == "Table and Plates Right")
                        {
                            canvas1.GetComponent<Canvas>().enabled = true;
                            nameDisplay.text = "Harriet";
                            dialogDisplay.text = "Golly, playing with sunlight to open a door. How intuitive!";
                            RightPlateRotation();
                        }

                        //Pillars with Plants
                        if (bc.name == "Full Pillar Left 1")
                        {
                            canvas1.GetComponent<Canvas>().enabled = true;
                            nameDisplay.text = "Harriet";
                            dialogDisplay.text = "Look at that! The vines seem to be keeping this pillar from collapsing! They must’ve grown strong from all the sunlight they’re getting. I sure wish it worked like that for humans!.";
                        }
                        if (bc.name == "Full Pillar Left 2")
                        {
                            canvas1.GetComponent<Canvas>().enabled = true;
                            nameDisplay.text = "Harriet";
                            dialogDisplay.text = "Look at that! The vines seem to be keeping this pillar from collapsing! They must’ve grown strong from all the sunlight they’re getting. I sure wish it worked like that for humans!.";
                        }


                        //Rubble
                        if (bc.name == "Caved In Rubble")
                        {
                            canvas1.GetComponent<Canvas>().enabled = true;
                            nameDisplay.text = "Harriet";
                            dialogDisplay.text = "Golly, it’ll take months of excavation for me to get past all this! Shame the pillars on this side didn’t hold up.";
                        }


                        //Engravings
                        if (bc.name == "inscription left language")
                        {
                            canvas1.GetComponent<Canvas>().enabled = true;
                            nameDisplay.text = "Harriet";
                            dialogDisplay.text = "Wow, I’ve never seen a language like this before. Hey Basil! Can you read this?";
                        }
                        if (bc.name == "inscription right language")
                        {
                            canvas1.GetComponent<Canvas>().enabled = true;
                            nameDisplay.text = "Harriet";
                            dialogDisplay.text = "I wish I could read this language. It’s so unfair, I feel like Time is playing favourites!";
                        }

                        //Glowing Engravings
                        //Engravings
                        if (bc.name == "inscription left language completed")
                        {
                            canvas1.GetComponent<Canvas>().enabled = true;
                            nameDisplay.text = "Harriet";
                            dialogDisplay.text = "I did it! I feel like Indiana Jones!";
                        }
                        if (bc.name == "inscription right language completed")
                        {
                            canvas1.GetComponent<Canvas>().enabled = true;
                            nameDisplay.text = "Harriet";
                            dialogDisplay.text = "I did it! I feel like Indiana Jones!";
                        }
                    }
                }
            }
        }
    }

    void BasilInteractions()
    {
        //print("BASIL IN CONTROL");
        if (Input.GetMouseButtonDown(0))
        {

            RaycastHit hit;
            //turn screenpoint into ray, from the camera into mouse position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                if (hit.transform != null)
                {
                    //PrintName(hit.transform.gameObject);

                    CapsuleCollider cc;
                    if (cc = hit.transform.GetComponent<CapsuleCollider>())
                    {
                        //
                    }

                    BoxCollider bc;
                    if (bc = hit.transform.GetComponent<BoxCollider>())
                    {
                        //MIRROR TESTS
                        /*
                        if (bc.name == "MirrorMiddle")
                        {
                            RotateMiddleMirror(bc);
                        }
                        if (bc.name == "MirrorRight")
                        {
                            RotateRightMirror(bc);
                        }
                        */

                        //Tapestries (click to remove)
                        /*
                        if (bc.name == "Tapestry_Kah")
                        {
                            Destroy(bc.gameObject);
                        }
                        if (bc.name == "Tapestry_Time")
                        {
                            Destroy(bc.gameObject);
                        }
                        */

                        //Engravings
                        if (bc.name == "inscription left english")
                        {
                            canvas1.GetComponent<Canvas>().enabled = true;
                            nameDisplay.text = "Basil";
                            dialogDisplay.text = "Fascinating, a clue! It reads: 'Respect the strength of weeded stone To keep upright like splinted bone, For even with these spaces bright, Just know that more is left to right.'";
                        }
                        if (bc.name == "inscription right english")
                        {
                            canvas1.GetComponent<Canvas>().enabled = true;
                            nameDisplay.text = "Basil";
                            dialogDisplay.text = "I never noticed that this was here! It says: 'May you see that decay and growth, While age-wrought, have their uses both. Now fill with light these spaces here To bring about the turn of gears.' A shame that the veil of night covers the sky for me now, for it seems as though daylight’s golden glow is key for this puzzle.";
                        }

                        //Plate Dialogue
                        if (bc.name == "Table and Plates Left")
                        {
                            canvas1.GetComponent<Canvas>().enabled = true;
                            nameDisplay.text = "Basil";
                            dialogDisplay.text = "I would not dare touch the offering plates!";
                        }
                        if (bc.name == "Table and Plates Right")
                        {
                            canvas1.GetComponent<Canvas>().enabled = true;
                            nameDisplay.text = "Basil";
                            dialogDisplay.text = "I would not dare touch the offering plates!";
                        }

                    }
                }
            }
        }
    }

    void RotateMiddleMirror(BoxCollider bc) {
        if (correctMirrors == false)
        {
            //print("direction: " + middleRotateCount);

            bc.transform.Rotate(mirrorRotation);
            middleRotateCount++;
            middleRotateCount = middleRotateCount % totalRotate;

            if (middleRotateCount > 3) { middleRotateCount = 0; }

            if (middleRotateCount == winningFaceCount)
            {
                //print("Correct mirror orientation");
                correctRotation = true;
            }
            else
            {
                correctRotation = false;
            }

            bool lightOn = false;

            for (int i = 0; i < reflectiveValues.Length; i++)
            {
                if (middleRotateCount == reflectiveValues[i])
                {
                    lightOn = true;
                }
                if (lightOn)
                {
                    mirrorLight.enabled = true;
                }
                else
                {
                    mirrorLight.enabled = false;
                }
            }
        }
    }

    void RotateRightMirror(BoxCollider bc) {
        if (correctMirrors == false)
        {
            bc.transform.Rotate(mirrorRotation);
            rightRotateCount++;
            rightRotateCount = rightRotateCount % totalRotate;

            if (rightRotateCount > 3) { rightRotateCount = 0; }

            if (rightRotateCount == winningFaceCount)
            {
                //print("Correct mirror orientation");
                correctRotation = true;
            }
            else
            {
                correctRotation = false;
            }

            bool lightOn = false;

            for (int i = 0; i < reflectiveValues.Length; i++)
            {
                if (rightRotateCount == reflectiveValues[i])
                {
                    lightOn = true;
                }
                if (lightOn)
                {
                    mirrorLight.enabled = true;
                }
                else
                {
                    mirrorLight.enabled = false;
                }
            }
        }
    }

    private void DestroyOtherObject(GameObject go)
    {
        if (objectNameInOtherTime != "")
        {
            Destroy(otherObject.gameObject);
        }
    }

    private void PrintName(GameObject go)
    {
        print(go.name);
    }

    private void LeftPlateRotation()
    {
        posValueL++;

        if (posValueL == 0)
        {
            plateL1.transform.position = platePosition1;
            plateL2.transform.position = platePosition2;
            plateL3.transform.position = platePosition3;
        }
        else if (posValueL == 1)
        {
            plateL1.transform.position = platePosition2;
            plateL2.transform.position = platePosition3;
            plateL3.transform.position = platePosition4;
        }
        else if (posValueL == 2)
        {
            plateL1.transform.position = platePosition3;
            plateL2.transform.position = platePosition4;
            plateL3.transform.position = platePosition1;
        }
        else if (posValueL == 3)
        {
            plateL1.transform.position = platePosition4;
            plateL2.transform.position = platePosition1;
            plateL3.transform.position = platePosition2;
        }
        else if (posValueL == 4)
        {
            plateL1.transform.position = platePosition1;
            plateL2.transform.position = platePosition2;
            plateL3.transform.position = platePosition3;
        }

        if (posValueL >= 4)
        {
            posValueL = 0;
        }
    }

    private void RightPlateRotation()
    {
        posValueR++;

        if (posValueR == 0)
        {
            plateR1.transform.position = platePositionR1;
            plateR2.transform.position = platePositionR2;
            plateR3.transform.position = platePositionR3;
        }
        else if (posValueR == 1)
        {
            plateR1.transform.position = platePositionR2;
            plateR2.transform.position = platePositionR3;
            plateR3.transform.position = platePositionR4;
        }
        else if (posValueR == 2)
        {
            plateR1.transform.position = platePositionR3;
            plateR2.transform.position = platePositionR4;
            plateR3.transform.position = platePositionR1;
        }
        else if (posValueR == 3)
        {
            plateR1.transform.position = platePositionR4;
            plateR2.transform.position = platePositionR1;
            plateR3.transform.position = platePositionR2;
        }
        else if (posValueR == 4)
        {
            plateR1.transform.position = platePositionR1;
            plateR2.transform.position = platePositionR2;
            plateR3.transform.position = platePositionR3;
        }

        if (posValueR >= 4)
        {
            posValueR = 0;
        }
    }

}//end script