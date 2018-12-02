using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateOnClick : MonoBehaviour, IActionOnClick {

    //[SerializeField]
    public int totalRotate;

    //[SerializeField]
    public int rotateCount = 0;

    //[SerializeField]
    //private int winningFaceCount = 2;

    public int winningFaceCount = 1;

    //[SerializeField]
    //private Light mirrorLight;
    public Light mirrorLight;

    [SerializeField]
    public int[] reflectiveValues;

    //character switch control
    [SerializeField]
    public GameObject requiredCharacter;

    GameObject characterSwitchControl;
    bool harrietActive;
    bool basilActive;

    GameObject mirrorBack, mirrorMiddle, mirrorFar, mirrorTopBack, mirrorTopMiddle, mirrorTopFar;
    Animator animMirrorBack, animMirrorMiddle, animMirrorFar;

    void Start() {
        mirrorBack = GameObject.Find("Mirror Top L Back");
        mirrorMiddle = GameObject.Find("Mirror Top L Middle");
        mirrorFar = GameObject.Find("Mirror Top L Far");

        mirrorTopBack = GameObject.Find("BackMirrorLight");
        mirrorTopMiddle = GameObject.Find("MiddleMirrorLight");
        mirrorTopFar = GameObject.Find("FarkMirrorLightr");

        animMirrorBack = mirrorBack.GetComponent<Animator>();
        animMirrorMiddle = mirrorMiddle.GetComponent<Animator>();
        animMirrorFar = mirrorFar.GetComponent<Animator>();
    }

    public void OnObjectClick() {
        //determine active character
        characterSwitchControl = GameObject.Find("CharacterSwitchControl");
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

        //if requiredCharacter is Basil, and he's active
        if ((requiredCharacter.name == "Basil") && (basilActive == true)) {
            //do the rotate logic here
            //transform.Rotate(0, 90, 0);
            rotateCount++;
            rotateCount = rotateCount % totalRotate;

            this.GetComponent<AudioScript>().PlaySound();


            //print(rotateCount);

            if (rotateCount == winningFaceCount)
            {
                //Debug.Log(gameObject.name + "Correct mirror orientation");
            }

            //print(this.name);

            if (this.name == "BackMirrorLight"){
                if (rotateCount == 1)
                {
                    animMirrorBack.SetInteger("rotateVal", 1);
                }
                else if (rotateCount == 2)
                {
                    animMirrorBack.SetInteger("rotateVal", 2);
                }
                else if (rotateCount == 3)
                {
                    animMirrorBack.SetInteger("rotateVal", 3);
                }
                else
                {
                    animMirrorBack.SetInteger("rotateVal", 4);
                }
            } else if (this.name == "MiddleMirrorLight") {
                if (rotateCount == 1)
                {
                    animMirrorMiddle.SetInteger("rotateVal", 1);
                }
                else if (rotateCount == 2)
                {
                    animMirrorMiddle.SetInteger("rotateVal", 2);
                }
                else if (rotateCount == 3)
                {
                    animMirrorMiddle.SetInteger("rotateVal", 3);
                }
                else
                {
                    animMirrorMiddle.SetInteger("rotateVal", 4);
                }
            } else if (this.name == "FarMirrorLight") {
                if (rotateCount == 1)
                {
                    animMirrorFar.SetInteger("rotateVal", 1);
                }
                else if (rotateCount == 2)
                {
                    animMirrorFar.SetInteger("rotateVal", 2);
                }
                else if (rotateCount == 3)
                {
                    animMirrorFar.SetInteger("rotateVal", 3);
                }
                else
                {
                    animMirrorFar.SetInteger("rotateVal", 4);
                }
            }


            bool lightOn = false;

            for (int i = 0; i < reflectiveValues.Length; i++)
            {
                if (rotateCount == reflectiveValues[i])
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
        } //end basil check
    }
}
