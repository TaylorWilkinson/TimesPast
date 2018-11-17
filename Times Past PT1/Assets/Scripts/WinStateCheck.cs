using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinStateCheck : MonoBehaviour
{
    //old win state for alpha
    /*
     * Level One Win State:
     * 1) Mirrors in correct orientation
     * 2) Plates in correct orientation
     * 3) If both of these elements are met, then the level is complete! 
    */

    GameObject rubble, middleLight, rightLight, middleMirror, rightMirror;
    GameObject halfPillarR1, halfPillarR2, fullPillarR1, fullPillarR2, newPillar, newPillar2, newVinesR1, newVinesR2;
    GameObject leftTable, rightTable;
    GameObject inscriptionL, inscriptionR, inscriptionLCorrect, inscriptionRCorrect;

    bool middleMirrorCorrect;
    bool rightMirrorCorrect;

    bool leftTableCorrect;
    bool rightTableCorrect;

    // Use this for initialization
    void Start()
    {
        //MIRROR PUZZLE OBJECTS
        rubble = GameObject.Find("Caved In Rubble");
        middleLight = GameObject.Find("Point Light Middle");
        rightLight = GameObject.Find("Point Light Right");
        middleMirror = GameObject.Find("MirrorMiddle");
        rightMirror = GameObject.Find("MirrorRight");
        halfPillarR1 = GameObject.Find("Half Pillar Right");
        halfPillarR2 = GameObject.Find("Half Pillar Right 2");
        fullPillarR1 = GameObject.Find("Full Pillar Right");
        fullPillarR2 = GameObject.Find("Full Pillar Right 2");
        newVinesR1 = GameObject.Find("New Vines Right 1");
        newVinesR2 = GameObject.Find("New Vines Right 2");
        newPillar = GameObject.Find("New Pillar Right");
        newPillar2 = GameObject.Find("New Pillar Right 2");

        //PLATE PUZZLE OBJECTS
        leftTable = GameObject.Find("Table and Plates Left");
        rightTable = GameObject.Find("Table and Plates Right");
        inscriptionL = GameObject.Find("inscription left language");
        inscriptionLCorrect = GameObject.Find("inscription left language correct");
        inscriptionR = GameObject.Find("inscription right language");
        inscriptionRCorrect = GameObject.Find("inscription right language correct");

        //set up inscription SpriteRenderer states
        inscriptionL.GetComponent<SpriteRenderer>().enabled = true;
        inscriptionLCorrect.GetComponent<SpriteRenderer>().enabled = false;
        inscriptionR.GetComponent<SpriteRenderer>().enabled = true;
        inscriptionRCorrect.GetComponent<SpriteRenderer>().enabled = false;

        //setting mirror & table orientation booleans
        middleMirrorCorrect = false;
        rightMirrorCorrect = false;
        leftTableCorrect = false;
        rightTableCorrect = false;

    }

    // Update is called once per frame
    void Update() {
        //SOLVING MIRROR PUZZLE:
        //If both mirrors are correctly placed, it removes the rubbles and fixes the pillars in the right alcove

        //determine if mirrors are in correct orientation
        middleMirrorCorrect |= (middleMirror.GetComponent<RotateOnClick>().rotateCount) == (middleMirror.GetComponent<RotateOnClick>().winningFaceCount);
        rightMirrorCorrect |= (rightMirror.GetComponent<RotateOnClick>().rotateCount) == (rightMirror.GetComponent<RotateOnClick>().winningFaceCount);

        //both mirrors are correct
        if ((middleMirrorCorrect == true) && (rightMirrorCorrect == true))
        {
            rightMirror.GetComponent<RotateOnClick>().mirrorLight.enabled = true;
            Destroy(rubble);

            //remove half pillars, and make them full
            Destroy(halfPillarR1);
            Destroy(halfPillarR2);
            newPillar.GetComponent<MeshRenderer>().enabled = true;
            newPillar2.GetComponent<MeshRenderer>().enabled = true;
            newVinesR1.GetComponentInChildren<MeshRenderer>().enabled = true;
            newVinesR2.GetComponentInChildren<MeshRenderer>().enabled = true;
        }


        //SOLVING PLATE PUZZLE: 
        //When the plates in a specific alcove are arrange correctly, make the engraving glow

        //determine if table is in correct orientation
        /*
        leftTableCorrect |= leftTable.GetComponent<RearrangeTableOnClick>().posValue == leftTable.GetComponent<RearrangeTableOnClick>().correctPlateOrientation;
        rightTableCorrect |= rightTable.GetComponent<RearrangeTableOnClick>().posValue == rightTable.GetComponent<RearrangeTableOnClick>().correctPlateOrientation;
        */

        //if left tables are correct
        if (leftTableCorrect == true) {
            //Debug.Log("Correct Left Plates");
            inscriptionL.GetComponent<SpriteRenderer>().enabled = false;
            inscriptionLCorrect.GetComponent<SpriteRenderer>().enabled = true;
        }

        //if right tables are correct
        if (rightTableCorrect == true) {
            //Debug.Log("Correct Right Plates");
            inscriptionR.GetComponent<SpriteRenderer>().enabled = false;
            inscriptionRCorrect.GetComponent<SpriteRenderer>().enabled = true;
        }
    }
}
