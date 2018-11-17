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
            transform.Rotate(0, 90, 0);
            rotateCount++;
            rotateCount = rotateCount % totalRotate;

            //print(rotateCount);

            if (rotateCount == winningFaceCount)
            {
                //Debug.Log(gameObject.name + "Correct mirror orientation");
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
