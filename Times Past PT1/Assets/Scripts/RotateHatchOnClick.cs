using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateHatchOnClick : MonoBehaviour, IActionOnClick {
    WinStateLevel2 winStateLvl2;

    public GameObject ceilingProngs;

    public int rotateDegrees;

    public int hatchRotationValue = 0;

    [SerializeField]
    public int hatchWinState = 0;

    //character switch control
    [SerializeField]
    public GameObject requiredCharacter;

    GameObject characterSwitchControl;
    bool harrietActive;
    bool basilActive;

    GameObject skylightProngs;
    Animator animProngs;

    void Start() {
        skylightProngs = GameObject.Find("pSphere8");
        animProngs = skylightProngs.GetComponent<Animator>();
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

        if ((requiredCharacter.name == "Basil") && (basilActive == true)) {
            //rotate skylight fixture as Basil
            //ceilingProngs.transform.Rotate(0, rotateDegrees, 0, Space.Self);
            hatchRotationValue++;
            hatchRotationValue = hatchRotationValue % 5;

            //print(hatchRotationValue);

            if (hatchRotationValue == 1) {
                animProngs.SetInteger("rotateValue", 1);
            } else if (hatchRotationValue == 2) {
                animProngs.SetInteger("rotateValue", 2);
            }
            else if (hatchRotationValue == 3) {
                animProngs.SetInteger("rotateValue", 3);
            }
            else if (hatchRotationValue == 4) {
                animProngs.SetInteger("rotateValue", 4);
            }
            else {
                animProngs.SetInteger("rotateValue", 5);
            }
        }
    }
}
