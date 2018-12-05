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

    bool buttonPressed;

    void Start() {
        skylightProngs = GameObject.Find("pSphere8");
        animProngs = skylightProngs.GetComponent<Animator>();

        buttonPressed = false;
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
            if(buttonPressed == false) {
                AchievementManager.instance.UnlockAchievement(Achievement.A3);
                buttonPressed = true;
            }

            this.GetComponent<AudioTalkScript>().enabled = false;

            //rotate skylight fixture as Basil
            //ceilingProngs.transform.Rotate(0, rotateDegrees, 0, Space.Self);
            hatchRotationValue++;
            hatchRotationValue = hatchRotationValue % 5;

            //play button click
            this.GetComponent<AudioScript>().PlaySound();

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
        } else if (harrietActive == true) {
            this.GetComponent<AudioTalkScript>().enabled = true;
        }

        if (hatchRotationValue == hatchWinState) {
            //play hatch moving sound
            this.GetComponent<AudioScript>().PlayAlternateSound();
        }
        if (hatchRotationValue == hatchWinState+1) {
            this.GetComponent<AudioScript>().PlayAlternateSound();
        }
    }
}
