using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LiftGateOnClick : MonoBehaviour, IActionOnClick
{
    GameObject gate1, gate2, gate3, gate4, gateH1, gateH2, gateH3, gateH4, tree1, tree2, tree3, tree4;
    Vector3 gateHeight1, gateHeight2, gateHeight3, gateHeight4;
    float gateHeightY1, gateHeightY2, gateHeightY3, gateHeightY4, treeY1, treeY2, treeY3, treeY4;
    bool gate1Move, gate2Move, gate3Move, gate4Move;

    //character switch control
    [SerializeField]
    GameObject requiredCharacter;

    GameObject characterSwitchControl;
    bool harrietActive;
    bool basilActive;

    [SerializeField]
    public int heightPosValue = 0;


    // Use this for initialization
    void Start() {
        gate1 = GameObject.Find("gate1");
        gate2 = GameObject.Find("gate2");
        gate3 = GameObject.Find("gate3");
        gate4 = GameObject.Find("gate4");

        tree1 = GameObject.Find("square-bush (3)");
        tree2 = GameObject.Find("square-bush (2)");
        tree3 = GameObject.Find("square-bush (1)");
        tree4 = GameObject.Find("square-bush");

        gateHeightY1 = -3f;
        gateHeightY2 = -2f;
        gateHeightY3 = -1f;
        gateHeightY4 = 0f;

        treeY1 = -0.34f;
        treeY2 = 1.58f;
        treeY3 = 3.00f;
        treeY4 = 4.95f;
    }

    public void OnObjectClick()
    {
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

        //print(this.name);

        if (basilActive == true) {
            //move the gates (which affects the trees for Harriet) only as Basil
            if (this.name == "gate1") {
                //print("Gate 1 Clicked");
                heightPosValue++;

                if (heightPosValue == 0) {
                    this.gameObject.transform.position = new Vector3(-11.38f, gateHeightY1, 10.66f);
                    tree1.transform.position = new Vector3(5.8552f, treeY1, 10.776f);
                    //play sound
                    this.GetComponent<AudioScript>().PlayAlternateSound();
                } else if (heightPosValue == 1) {
                    this.gameObject.transform.position = new Vector3(-11.38f, gateHeightY2, 10.66f);
                    tree1.transform.position = new Vector3(5.8552f, treeY2, 10.776f);
                    //play sound
                    this.GetComponent<AudioScript>().PlayAlternateSound();
                } else if (heightPosValue == 2) {
                    this.gameObject.transform.position = new Vector3(-11.38f, gateHeightY3, 10.66f);
                    tree1.transform.position = new Vector3(5.8552f, treeY3, 10.776f);
                    //play sound
                    this.GetComponent<AudioScript>().PlayAlternateSound();
                } else if (heightPosValue == 3) {
                    this.gameObject.transform.position = new Vector3(-11.38f, gateHeightY4, 10.66f);
                    tree1.transform.position = new Vector3(5.8552f, treeY4, 10.776f);
                    //play sound
                    this.GetComponent<AudioScript>().PlayAlternateSound();
                } else if (heightPosValue == 4) {
                    this.gameObject.transform.position = new Vector3(-11.38f, gateHeightY1, 10.66f);
                    tree1.transform.position = new Vector3(5.8552f, treeY1, 10.776f);
                    //play sound
                    this.GetComponent<AudioScript>().PlayAlternateSound();
                }

                if (heightPosValue >= 4) {
                    heightPosValue = 0;
                }

            } else if (this.name == "gate2") {
                //print("Gate 2 Clicked");
                heightPosValue++;

                if (heightPosValue == 0) {
                    this.gameObject.transform.position = new Vector3(-11.38f, gateHeightY1, 3.59f);
                    tree2.transform.position = new Vector3(5.8552f, treeY1, 3.68f);
                    //play sound
                    this.GetComponent<AudioScript>().PlayAlternateSound();
                } else if (heightPosValue == 1) {
                    this.gameObject.transform.position = new Vector3(-11.38f, gateHeightY2, 3.59f);
                    tree2.transform.position = new Vector3(5.8552f, treeY2, 3.68f);
                    //play sound
                    this.GetComponent<AudioScript>().PlayAlternateSound();
                } else if (heightPosValue == 2) {
                    this.gameObject.transform.position = new Vector3(-11.38f, gateHeightY3, 3.59f);
                    tree2.transform.position = new Vector3(5.8552f, treeY3, 3.68f);
                    //play sound
                    this.GetComponent<AudioScript>().PlayAlternateSound();
                } else if (heightPosValue == 3) {
                    this.gameObject.transform.position = new Vector3(-11.38f, gateHeightY4, 3.59f);
                    tree2.transform.position = new Vector3(5.8552f, treeY4, 3.68f);
                    //play sound
                    this.GetComponent<AudioScript>().PlayAlternateSound();
                } else if (heightPosValue == 4) {
                    this.gameObject.transform.position = new Vector3(-11.38f, gateHeightY1, 3.59f);
                    tree2.transform.position = new Vector3(5.8552f, treeY1, 3.68f);
                    //play sound
                    this.GetComponent<AudioScript>().PlayAlternateSound();
                }

                if (heightPosValue >= 4)
                {
                    heightPosValue = 0;
                }
            }
            else if (this.name == "gate3") {
                //print("Gate 3 Clicked");
                heightPosValue++;

                if (heightPosValue == 0) {
                    this.gameObject.transform.position = new Vector3(-11.38f, gateHeightY1, - 3.58f);
                    tree3.transform.position = new Vector3(5.8552f, treeY1, -3.58f);
                    //play sound
                    this.GetComponent<AudioScript>().PlayAlternateSound();
                } else if (heightPosValue == 1) {
                    this.gameObject.transform.position = new Vector3(-11.38f, gateHeightY2, -3.58f);
                    tree3.transform.position = new Vector3(5.8552f, treeY2, -3.58f);
                    //play sound
                    this.GetComponent<AudioScript>().PlayAlternateSound();
                } else if (heightPosValue == 2) {
                    this.gameObject.transform.position = new Vector3(-11.38f, gateHeightY3, -3.58f);
                    tree3.transform.position = new Vector3(5.8552f, treeY3, -3.58f);
                    //play sound
                    this.GetComponent<AudioScript>().PlayAlternateSound();
                } else if (heightPosValue == 3) {
                    this.gameObject.transform.position = new Vector3(-11.38f, gateHeightY4, -3.58f);
                    tree3.transform.position = new Vector3(5.8552f, treeY4, -3.58f);
                    //play sound
                    this.GetComponent<AudioScript>().PlayAlternateSound();
                } else if (heightPosValue == 4) {
                    this.gameObject.transform.position = new Vector3(-11.38f, gateHeightY1, -3.58f);
                    tree3.transform.position = new Vector3(5.8552f, treeY1, -3.58f);
                    //play sound
                    this.GetComponent<AudioScript>().PlayAlternateSound();
                }

                if (heightPosValue >= 4) {
                    heightPosValue = 0;
                }
            } else if (this.name == "gate4") {
                //print("Gate 4 Clicked");
                heightPosValue++;

                if (heightPosValue == 0) {
                    this.gameObject.transform.position = new Vector3(-11.38f, gateHeightY1, -10.66f);
                    tree4.transform.position = new Vector3(5.8552f, treeY1, -10.58f);
                    //play sound
                    this.GetComponent<AudioScript>().PlayAlternateSound();
                } else if (heightPosValue == 1) {
                    this.gameObject.transform.position = new Vector3(-11.38f, gateHeightY2, -10.66f);
                    tree4.transform.position = new Vector3(5.8552f, treeY2, -10.58f);
                    //play sound
                    this.GetComponent<AudioScript>().PlayAlternateSound();
                } else if (heightPosValue == 2) {
                    this.gameObject.transform.position = new Vector3(-11.38f, gateHeightY3, -10.66f);
                    tree4.transform.position = new Vector3(5.8552f, treeY3, -10.58f);
                    //play sound
                    this.GetComponent<AudioScript>().PlayAlternateSound();
                } else if (heightPosValue == 3) {
                    this.gameObject.transform.position = new Vector3(-11.38f, gateHeightY4, -10.66f);
                    tree4.transform.position = new Vector3(5.8552f, treeY4, -10.58f);
                    //play sound
                    this.GetComponent<AudioScript>().PlayAlternateSound();
                } else if (heightPosValue == 4) {
                    this.gameObject.transform.position = new Vector3(-11.38f, gateHeightY1, -10.66f);
                    tree4.transform.position = new Vector3(5.8552f, treeY1, -10.58f);
                    //play sound
                    this.GetComponent<AudioScript>().PlayAlternateSound();
                }

                if (heightPosValue >= 4) {
                    heightPosValue = 0;
                }
            }
        }
    }
}