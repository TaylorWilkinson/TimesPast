using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClimbStairsOnClick : MonoBehaviour, IActionOnClick {
    GameObject characterSwitchControl;
    bool harrietActive;
    bool basilActive;

    GameObject harriet, basil, trees;
    GameObject gate1, gate2, gate3, gate4;

    int stairsPos, treeStairsPos;

    bool treeStairs1, treeStairs2;

    void Start()
    {
        harriet = GameObject.Find("Harriet");
        basil = GameObject.Find("Basil");

        trees = GameObject.Find("TreeStairs");

        gate1 = GameObject.Find("gate1");
        gate2 = GameObject.Find("gate2");
        gate3 = GameObject.Find("gate3");
        gate4 = GameObject.Find("gate4");

        stairsPos = 0;
        treeStairsPos = 0;

        treeStairs1 = false;
        treeStairs2 = false;
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


        if (basilActive)
        {
            if (stairsPos == 0)
            {
                //go up stairs 
                basil.transform.position = new Vector3(10.39f, 12f, 18.79f);
            }
            else if (stairsPos == 1)
            {
                //go down stairs
                basil.transform.position = new Vector3(-1.781889f, 0.5277858f, 22.93093f);
            }


            if (gameObject.name == "stairs left")
            {
                stairsPos++;

                if (stairsPos > 1)
                {
                    stairsPos = 0;
                }
            }
        }
        else if (harrietActive) {
            if ((gate1.GetComponent<LiftGateOnClick>().heightPosValue == 0) && (gate2.GetComponent<LiftGateOnClick>().heightPosValue == 1) && (gate3.GetComponent<LiftGateOnClick>().heightPosValue == 2) && (gate4.GetComponent<LiftGateOnClick>().heightPosValue == 3)) {
                //trees going up from left to right
                treeStairs1 = true;
                treeStairs2 = false;
            }
            else if ((gate1.GetComponent<LiftGateOnClick>().heightPosValue == 3) && (gate2.GetComponent<LiftGateOnClick>().heightPosValue == 2) && (gate3.GetComponent<LiftGateOnClick>().heightPosValue == 1) && (gate4.GetComponent<LiftGateOnClick>().heightPosValue == 0))
            {
                //trees going up from right to left
                treeStairs1 = false;
                treeStairs2 = true;
            }
            else
            {
                treeStairs1 = false;
                treeStairs2 = false;
            }

            if (treeStairs1 == true) {
                harriet.transform.position = new Vector3(10.82954f, 10.79798f, -10.23493f);
            } else if (treeStairs2 == true) {
                harriet.transform.position = new Vector3(10.88005f, 10.79798f, 10.86571f);
            }

            //print("treeStairs1: " + treeStairs1 + ", treeStairs2: " + treeStairs2);

            /*
            if (treeStairsPos == 0) {
                //go up stairs 
                harriet.transform.position = new Vector3(10.88005f, 10.79798f, 10.86571f);
            }
            else if (treeStairsPos == 1) {
                //go down stairs
                harriet.transform.position = new Vector3(5.419345f, 0.5159853f, -17.0425f);
            }

            print("Tree Stairs Pos: " + treeStairsPos);

            if (gameObject.name == "TreeStairs")
            {
                treeStairsPos++;

                if (treeStairsPos > 1)
                {
                    treeStairsPos = 0;
                }
            }
            */

        }
    }
}
