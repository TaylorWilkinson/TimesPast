using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotateObject : MonoBehaviour {
    int degreesOfRotation;
    int faceValue;

    int face;
    int middleFace;
    int rightFace;

    GameObject mirrorMiddle, mirrorRight, left, middle, right;

    //variables for character check
    int characterSelect;
    bool harrietActive;
    bool basilActive;

    //bool for win states
    bool middleCorrect;
    bool rightCorrect;

    // Use this for initialization
    void Start()
    {
        degreesOfRotation = 90;
        faceValue = 3;

        mirrorMiddle = GameObject.Find("MirrorMiddle");
        mirrorRight = GameObject.Find("MirrorRight");

        /*
        left = GameObject.Find("Point Light Left");
        middle = GameObject.Find("Point Light Middle");
        right = GameObject.Find("Point Light Right");
        */

        //face = 0;
        middleFace = 0;
        rightFace = 0;

        characterSelect = 0;

        middleCorrect = false;
        rightCorrect = false;
    }

    // Update is called once per frame
    void Update()
    {
        //if (face > 7) face = 0;
        //if (face > faceValue) face = 0;

        if (middleFace > faceValue) middleFace = 0;
        if (rightFace > faceValue) rightFace = 0;


        faceValue = ((360 / degreesOfRotation) - 1);


        //print("middle face: " + middleFace + ", right face: " + rightFace);

        //determine past or present status on spacebar press
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
        //set active status based on characterSelect
        if (characterSelect == 0)
        {
            harrietActive = true;
            basilActive = false;
        }
        else if (characterSelect == 1)
        {
            harrietActive = false;
            basilActive = true;
        }

        //If middleCorrect and rightCorrect are true, disable ClickableObject
        /*
        if ((middleCorrect == true) && (rightCorrect == true)) {
            //middle and right orientations are correct - disable ClickableObject
            mirrorMiddle.GetComponent<ClickableObject>().enabled = false;
            mirrorRight.GetComponent<ClickableObject>().enabled = false;
        }
        else {
            mirrorMiddle.GetComponent<ClickableObject>().enabled = true;
            mirrorRight.GetComponent<ClickableObject>().enabled = true;
        }
        */
    }

    void OnMouseDown() {
        //transform.Rotate(new Vector3(0, 45, 0));
        //face++;

        //transform.Rotate(new Vector3(0, -degreesOfRotation, 0));

        //print("Face value: " + face + ", FOR MIRROR: " + this.name);

        if (basilActive == true) {
            if (this.name == "MirrorMiddle") {
                middleFace++;
                print("MiddleFace: " + middleFace);
            } else if (this.name == "MirrorRight"){
                rightFace++;
                print("RightFace: " + rightFace);
            }


            //print("Face value: " + face + ", FOR MIRROR: " + this.name);

            if ((this.name == "MirrorMiddle") && (middleFace == 2)) {
                //print("MIDDLE WIN STATE");
                //middleCorrect = true;
            }

            if ((this.name == "MirrorRight") && (rightFace == 3)) {
                //print("RIGHT WIN STATE");
                //rightCorrect = true;
            }
        }
    }

    public int getFace()
    {
        return face;
    }

    public int getMiddleFace()
    {
        return middleFace;
    }

    public int getRightFace()
    {
        return rightFace;
    }
}
