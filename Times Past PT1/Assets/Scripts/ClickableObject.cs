using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClickableObject : MonoBehaviour {

    public string objectName;
    public string objectNameInOtherTime;

    //GameObject basil;
    GameObject otherObject, canvas, nameText, dialogueText;
    GameObject rubble, middleLight, rightLight, middleMirror, rightMirror;
    GameObject halfPillarR1, halfPillarR2, fullPillarR1, fullPillarR2, newPillar, newPillar2, newVinesR1, newVinesR2;
    GameObject plateL1, plateL2, plateL3, plateL4, plateR1, plateR2, plateR3, plateR4;

    int characterSelect;
    bool harrietActive;
    bool basilActive;

    int posValueL;
    int posValueR;

    Vector3 targetPosition;
    Vector3 lookAtTarget;
    Vector3 offsetCharacter;
    Quaternion playerRot;

    Vector3 mirrorRotation;

    Text nameTextInput;
    Text dialogueTextInput;

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


    void Start () {
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

        /*
        canvas = GameObject.Find("Canvas");
        nameText = GameObject.Find("Name");
        dialogueText = GameObject.Find("Dialogue");

        nameTextInput = nameText.GetComponent<Text>();
        dialogueTextInput = dialogueText.GetComponent<Text>();

        canvas.SetActive(false);
        */

        //at start, Dialogue is inactive
        //dialogueBox.SetActive(false);

        //basil = GameObject.Find("Basil");

        offsetCharacter = new Vector3(-20, 10, 0);

        mirrorRotation = new Vector3(0, 90, 0);

        characterSelect = 0;

        correctRotation = false;
    }

    // Update is called once per frame
    void Update () {
        //determine past or present status on spacebar press
        if (Input.GetKeyDown("space")) {
            //update characterSelect value
            if (characterSelect == 0) {
                characterSelect = 1;
            }
            else if (characterSelect == 1) {
                characterSelect = 0;
            }
        }

        //set active status based on characterSelect
        if (characterSelect == 0) {
            harrietActive = true;
            basilActive = false;
        }
        else if (characterSelect == 1) {
            harrietActive = false;
            basilActive = true;
        }

        /*
        print(posValueL);
        print(posValueR);
        */
        //PLATE WIN STATES
        if ((harrietActive == true) && (posValueL == 2) && (posValueR == 3)) {
            print("good job");
        }

        //interactions on mouse click
        if (Input.GetMouseButtonDown(0)) {

            RaycastHit hit;
            //turn screenpoint into ray, from the camera into mouse position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            //RaycastHit hitBasil;
            //Ray rayBasil = Camera.main.ScreenPointToRay(Input.mousePosition);


            if (Physics.Raycast(ray, out hit, 100.0f)) {
                if (hit.transform != null) {
                    //PrintName(hit.transform.gameObject);

                    CapsuleCollider cc;
                    if (cc = hit.transform.GetComponent<CapsuleCollider>()) {
                        /*
                        if (gameObject.name == "Sprout")
                        {
                            Destroy(gameObject);
                            DestroyOtherObject(gameObject);
                        }
                        */
                    }

                    BoxCollider bc;
                    if (bc = hit.transform.GetComponent<BoxCollider>())
                    {
                        //print(bc.name);

                        //Plate puzzle, Harriet or Basil can do
                        if (bc.name == "Table and Plates Left")
                        {
                            LeftPlateRotation();
                        }
                        if (bc.name == "Table and Plates Right")
                        {
                            //print("4: " + plateR4.transform.position);
                            RightPlateRotation();
                        }


                        //Basil: Remove the tapestries
                        if (bc.name == "Tapestry_Kah")
                        {
                            //print(bc.gameObject);
                            Destroy(bc.gameObject);
                        }
                        else if (bc.name == "Tapestry_Time")
                        {
                            //print(bc.gameObject);
                            Destroy(bc.gameObject);
                        }


                        //Click mirrors to rotate them 90 degrees
                        if (harrietActive == true)
                        {
                            //Harriet can't move the mirrors, so this will prompt dialogue
                            if (bc.name == "MirrorMiddle")
                            {
                                //start dialogue
                                /*
                                canvas.SetActive(true);
                                nameTextInput.text = "Harriet";
                                dialogueTextInput.text = "This looks like it should move, but I’m just too small to do it!";
                                */
                            }
                            else if (bc.name == "MirrorRight")
                            {
                                //start dialogue
                                /*
                                canvas.SetActive(true);
                                nameTextInput.text = "Harriet";
                                dialogueTextInput.text = "This looks like it should move, but I’m just too small to do it!";
                                */
                            }
                        }
                        else if (basilActive == true)
                        {
                            if (bc.name == "MirrorMiddle")
                            {
                                //print(bc.gameObject);
                                //bc.transform.Rotate(mirrorRotation);

                                //test updated rotation
                                //print("middle rotation value: " + bc.transform.rotation);
                                //print("Middle eulerAngle Y: " + bc.transform.eulerAngles);
                                //above returns 3 eulerAngles each click. This won't work.

                                rotateMiddleMirror(bc);
                            }
                            else if (bc.name == "MirrorRight") {
                                //print(bc.gameObject);
                                //bc.transform.Rotate(mirrorRotation);

                                rotateRightMirror(bc);
                                //print("RIGHT WINNING FACE: " + bc.GetComponent<ClickableObject>().winningFaceCount);

                                //print("CORRECT ROTATION: " + bc.GetComponent<ClickableObject>().correctRotation);
                            }
                        }
                    }//box colider end
                } //hit isn't null
            }//end raycast
        } // end mouse button click

        //If both rotation values are correct, remove the rubble and fix the pillars
        if (((middleMirror.GetComponent<ClickableObject>().middleRotateCount) == 3) && ((rightMirror.GetComponent<ClickableObject>().rightRotateCount) == 1)) {
            //print("READY");
            rightMirror.GetComponent<ClickableObject>().mirrorLight.enabled = true;
            Destroy(rubble);

            //remove half pillars, and make them full
            Destroy(halfPillarR1);
            Destroy(halfPillarR2);
            newPillar.GetComponent<MeshRenderer>().enabled = true;
            newPillar2.GetComponent<MeshRenderer>().enabled = true;
            newVinesR1.GetComponentInChildren<MeshRenderer>().enabled = true;
            newVinesR2.GetComponentInChildren<MeshRenderer>().enabled = true;
        }

    }//end update


    private void DestroyOtherObject(GameObject go) {
        if (objectNameInOtherTime != "") {
            Destroy(otherObject.gameObject);
            //otherObject.transform.position = new Vector3(41, -6, 28);
        }
    }

    private void PrintName(GameObject go) {
        print(go.name);
    }

    private void LeftPlateRotation() {
        posValueL++;

        if (posValueL == 0) {
            plateL1.transform.position = platePosition1;
            plateL2.transform.position = platePosition2;
            plateL3.transform.position = platePosition3;
        } else if (posValueL == 1) {
            plateL1.transform.position = platePosition2;
            plateL2.transform.position = platePosition3;
            plateL3.transform.position = platePosition4;
        } else if (posValueL == 2) {
            plateL1.transform.position = platePosition3;
            plateL2.transform.position = platePosition4;
            plateL3.transform.position = platePosition1;
        } else if (posValueL == 3) {
            plateL1.transform.position = platePosition4;
            plateL2.transform.position = platePosition1;
            plateL3.transform.position = platePosition2;
        } else if (posValueL == 4) {
            plateL1.transform.position = platePosition1;
            plateL2.transform.position = platePosition2;
            plateL3.transform.position = platePosition3;
        }

        if (posValueL >= 4) {
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

        if (posValueR >= 4){
            posValueR = 0;
        }
    }

    private void rotateMiddleMirror(BoxCollider bc) {
        bc.transform.Rotate(mirrorRotation);
        middleRotateCount++;
        middleRotateCount = middleRotateCount % totalRotate;

        if (middleRotateCount > 3) { middleRotateCount = 0; }

        if (middleRotateCount == winningFaceCount) {
            //print("Correct mirror orientation");
            correctRotation = true;
        } else {
            correctRotation = false;
        }

        bool lightOn = false;

        for (int i = 0; i < reflectiveValues.Length; i++) {
            if (middleRotateCount == reflectiveValues[i]) {
                lightOn = true;
            }
            if (lightOn) {
                mirrorLight.enabled = true;
            } else {
                mirrorLight.enabled = false;
            }
        }
    }
    private void rotateRightMirror(BoxCollider bc)
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
