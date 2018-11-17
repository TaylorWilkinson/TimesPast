using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RearrangeTablesOnClick : MonoBehaviour, IActionOnClick {
    GameObject plateL1, plateL2, plateL3, plateL4, plateR1, plateR2, plateR3, plateR4;
    Vector3 platePositionL1, platePositionL2, platePositionL3, platePositionL4, platePositionR1, platePositionR2, platePositionR3, platePositionR4;

    //character switch control
    [SerializeField]
    GameObject requiredCharacter;

    GameObject characterSwitchControl;
    bool harrietActive;
    bool basilActive;

    bool leftPlatesMoving;
    bool rightPlatesMoving;

    public int posValue;
    public int correctPlateOrientation;

    void Start()
    {
        //Find GameObjects
        plateL1 = GameObject.Find("PlateL1");
        plateL2 = GameObject.Find("PlateL2");
        plateL3 = GameObject.Find("PlateL3");
        plateL4 = GameObject.Find("PlateL4");
        plateR1 = GameObject.Find("PlateR1");
        plateR2 = GameObject.Find("PlateR2");
        plateR3 = GameObject.Find("PlateR3");
        plateR4 = GameObject.Find("PlateR4");

        //determine the set position of plates that clicking will cycle through
        platePositionL1 = new Vector3(-45.1f, 3.123001f, -20.66996f);
        platePositionL2 = new Vector3(-46.24625f, 3.123001f, -20.66996f);
        platePositionL3 = new Vector3(-47.39f, 3.123001f, -20.66996f);
        platePositionL4 = new Vector3(-48.56802f, 3.123001f, -20.66996f);

        platePositionR1 = new Vector3(-47.59785f, 3.123003f, 20.66995f);
        platePositionR2 = new Vector3(-46.45409f, 3.123003f, 20.66995f);
        platePositionR3 = new Vector3(-45.22655f, 3.123003f, 20.66995f);
        platePositionR4 = new Vector3(-48.74409f, 3.123003f, 20.66995f);
    }

    public void OnObjectClick() {
        //rearrange objects logic here

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

        //check which table is being rearranged
        if (gameObject.name == "Table and Plates Left")
        {
            leftPlatesMoving = true;
            rightPlatesMoving = false;
        }
        else if (gameObject.name == "Table and Plates Right")
        {
            leftPlatesMoving = false;
            rightPlatesMoving = true;
        }

        //determine if required character is active
        if ((requiredCharacter.name == "Harriet") && (harrietActive == true))
        {
            if (leftPlatesMoving)
            {
                posValue++;

                if (posValue == 0)
                {
                    plateL1.transform.position = platePositionL1;
                    plateL2.transform.position = platePositionL2;
                    plateL3.transform.position = platePositionL3;
                }
                else if (posValue == 1)
                {
                    plateL1.transform.position = platePositionL2;
                    plateL2.transform.position = platePositionL3;
                    plateL3.transform.position = platePositionL4;
                }
                else if (posValue == 2)
                {
                    plateL1.transform.position = platePositionL3;
                    plateL2.transform.position = platePositionL4;
                    plateL3.transform.position = platePositionL1;
                }
                else if (posValue == 3)
                {
                    plateL1.transform.position = platePositionL4;
                    plateL2.transform.position = platePositionL1;
                    plateL3.transform.position = platePositionL2;
                }
                else if (posValue == 4)
                {
                    plateL1.transform.position = platePositionL1;
                    plateL2.transform.position = platePositionL2;
                    plateL3.transform.position = platePositionL3;
                }

                if (posValue >= 4)
                {
                    posValue = 0;
                }
            }
            else if (rightPlatesMoving)
            {
                posValue++;

                if (posValue == 0)
                {
                    plateR1.transform.position = platePositionR1;
                    plateR2.transform.position = platePositionR2;
                    plateR3.transform.position = platePositionR3;
                }
                else if (posValue == 1)
                {
                    plateR1.transform.position = platePositionR2;
                    plateR2.transform.position = platePositionR3;
                    plateR3.transform.position = platePositionR4;
                }
                else if (posValue == 2)
                {
                    plateR1.transform.position = platePositionR3;
                    plateR2.transform.position = platePositionR4;
                    plateR3.transform.position = platePositionR1;
                }
                else if (posValue == 3)
                {
                    plateR1.transform.position = platePositionR4;
                    plateR2.transform.position = platePositionR1;
                    plateR3.transform.position = platePositionR2;
                }
                else if (posValue == 4)
                {
                    plateR1.transform.position = platePositionR1;
                    plateR2.transform.position = platePositionR2;
                    plateR3.transform.position = platePositionR3;
                }

                if (posValue >= 4)
                {
                    posValue = 0;
                }
            } //end leftPlatesMoving or rightPlatesMoving if-else stmts
        } //end Harriet character check if stmt
    }
}
