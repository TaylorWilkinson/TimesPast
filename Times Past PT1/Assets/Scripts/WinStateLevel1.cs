using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinStateLevel1 : MonoBehaviour {

    /*
     * Tutorial Win State:
     * 1) Harriet interacts with the tree and notes how it exists for her
     * 2) After Harriet interacts with the tree, Basil can pluck the sprout on the ground
    */

    GameObject keyhole;

    GameObject mirrorBack, mirrorMiddle, mirrorFar, middleLight;
    GameObject alcoveRubble, farRubble;

    GameObject halfPillarAlcove1, halfPillarAlcove2, newPillarAlcove1, newPillarAlcove2;
    GameObject alcoveVines1, alcoveVines2;

    GameObject halfPillarHall1, halfPillarHall2, newPillarHall1, newPillarHall2;
    GameObject hallVines1, hallVines2;

    GameObject hallPlant1, hallPlant2, hallPlant3, hallPlant4, hallPlant5, alcovePlant1, alcovePlant2, alcovePlant3, alcovePlant4, alcovePlant5;

    GameObject characterSwitchControl;
    bool harrietActive, basilActive;

    bool backMirrorCorrect, middleMirrorCorrect, farMirrorCorrect;

    GameObject leftTable, rightTable, inscriptionL, inscriptionR, inscriptionLCorrect, inscriptionRCorrect;
    bool leftTableCorrect, rightTableCorrect;

    //puzzle solved objects
    GameObject levelCompleteSound;
    public bool mirrorPuzzleSolved, platesPuzzleSolved;

    //Achievement Checkers:
    int treasureRoomCheck;
    bool treasureRoomFound;

    // Use this for initialization
    void Start() {
        keyhole = GameObject.Find("keyhole");

        mirrorBack = GameObject.Find("BackMirrorLight");
        mirrorMiddle = GameObject.Find("MiddleMirrorLight");
        mirrorFar = GameObject.Find("FarMirrorLight");

        middleLight = GameObject.Find("Point Light Middle");

        halfPillarAlcove1 = GameObject.Find("HalfPillarHall2");
        halfPillarAlcove2 = GameObject.Find("HalfPillarHall4");
        newPillarAlcove1 = GameObject.Find("NewPillarHall2");
        newPillarAlcove2 = GameObject.Find("NewPillarHall4");
        alcoveVines1 = GameObject.Find("PillarVines3");
        alcoveVines2 = GameObject.Find("PillarVines4");

        halfPillarHall1 = GameObject.Find("HalfPillarHall6");
        halfPillarHall2 = GameObject.Find("HalfPillarHall5");
        newPillarHall1 = GameObject.Find("NewPillarHall6");
        newPillarHall2 = GameObject.Find("NewPillarHall5");
        hallVines1 = GameObject.Find("PillarVines5");
        hallVines2 = GameObject.Find("PillarVines6");

        alcoveRubble = GameObject.Find("Alcove Rubble");
        farRubble = GameObject.Find("Caved In Rubble");

        //plants in sunlight
        hallPlant1 = GameObject.Find("hallPlant1");
        hallPlant2 = GameObject.Find("hallPlant2");
        hallPlant3 = GameObject.Find("hallPlant3");
        hallPlant4 = GameObject.Find("hallPlant4");
        hallPlant5 = GameObject.Find("hallPlant5");
        alcovePlant1 = GameObject.Find("alcovePlant1");
        alcovePlant2 = GameObject.Find("alcovePlant2");
        alcovePlant3 = GameObject.Find("alcovePlant3");
        alcovePlant4 = GameObject.Find("alcovePlant4");
        alcovePlant5 = GameObject.Find("alcovePlant5");

        hallPlant1.SetActive(false);
        hallPlant2.SetActive(false); 
        hallPlant3.SetActive(false);
        hallPlant4.SetActive(false);
        hallPlant5.SetActive(false);
        alcovePlant1.SetActive(false);
        alcovePlant2.SetActive(false);
        alcovePlant3.SetActive(false);
        alcovePlant4.SetActive(false);
        alcovePlant5.SetActive(false);

        backMirrorCorrect = false;
        middleMirrorCorrect = false;
        farMirrorCorrect = false;

        //set middle light to be off unless it's reflecting
        middleLight.GetComponent<Light>().enabled = false;

        //PLATE PUZZLE OBJECTS
        leftTable = GameObject.Find("Table and Plates Left");
        rightTable = GameObject.Find("Table and Plates Right");
        inscriptionL = GameObject.Find("circles-left");
        inscriptionLCorrect = GameObject.Find("circles-left-complete");
        inscriptionR = GameObject.Find("circles-right");
        inscriptionRCorrect = GameObject.Find("circles-right-complete");

        //set up inscription SpriteRenderer states
        /*
        inscriptionL.GetComponent<SpriteRenderer>().enabled = true;
        inscriptionLCorrect.GetComponent<SpriteRenderer>().enabled = false;
        inscriptionR.GetComponent<SpriteRenderer>().enabled = true;
        inscriptionRCorrect.GetComponent<SpriteRenderer>().enabled = false;
        */
        inscriptionL.SetActive(true);
        inscriptionLCorrect.SetActive(false);
        inscriptionR.SetActive(true);
        inscriptionRCorrect.SetActive(false);

        leftTableCorrect = false;
        rightTableCorrect = false;

        keyhole.SetActive(false);

        levelCompleteSound = GameObject.Find("LevelCompleteSound");
        mirrorPuzzleSolved = false;
        platesPuzzleSolved = false;


        //Achievement Checkers:
        treasureRoomCheck = 0;
        treasureRoomFound = false;
    }

    // Update is called once per frame
    void Update() {
        //DETERMINE ACTIVE CHARACTER
        CheckCharacter();
        CheckWinState();
        AchievementCheck();
    }

    IEnumerator playMirrorWinSound()
    {
        while (mirrorPuzzleSolved  == false)
        {
            levelCompleteSound.GetComponent<AudioScript>().PlaySound();
            yield return new WaitForSeconds(0.5f);
         //   mirrorPuzzleSolved = true;
        }
    }

    IEnumerator playPlateWinSound()
    {
        while (platesPuzzleSolved == false)
        {
            levelCompleteSound.GetComponent<AudioScript>().PlaySound();
            yield return new WaitForSeconds(0.5f);
            //platesPuzzleSolved = true;
        }
    }

    IEnumerator Lvl3Cutscene() {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(5);
    }

    void CheckCharacter() {
        //DETERMINE ACTIVE CHARACTER
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
    }

    void AchievementCheck()
    {
        if (treasureRoomFound == false)
        {
            if (treasureRoomCheck > 0)
            {
                AchievementManager.instance.UnlockAchievement(Achievement.A1);
                treasureRoomFound = true;
            }
        }
    }

    void CheckWinState()
    {
        /*
         * WIN STATE FOR THIS LEVEL:
         * A) Optional Hint: Read the script in the right alcove as Harriet, and remove the tapestry to read it as Basil, to figure out next step
         * B) Rotate the middle and far mirrors to remove the rubble, as Basil
         * C) Rearrange the plates based on the diagrams, as Harriet
         * 
        */

        // SECTION B: MIRRORS
        //Checks for the middle and far mirrors:
        /*
        farMirrorCorrect |= ((mirrorFar.GetComponent<RotateOnClick>().rotateCount) == (mirrorFar.GetComponent<RotateOnClick>().winningFaceCount));
        middleMirrorCorrect |= ((mirrorMiddle.GetComponent<RotateOnClick>().rotateCount) == (mirrorMiddle.GetComponent<RotateOnClick>().winningFaceCount));
        */

        if ((mirrorBack.GetComponent<RotateOnClick>() != null) || (mirrorMiddle.GetComponent<RotateOnClick>() != null) || (mirrorFar.GetComponent<RotateOnClick>() != null))
        {
            //because RotateOnClick is immediately not turned on, check if it isn't null to do the win state stuff
            if ((mirrorFar.GetComponent<RotateOnClick>().rotateCount) == (mirrorFar.GetComponent<RotateOnClick>().winningFaceCount))
            {
                farMirrorCorrect = true;
            }
            else if ((mirrorFar.GetComponent<RotateOnClick>().rotateCount) != (mirrorFar.GetComponent<RotateOnClick>().winningFaceCount))
            {
                farMirrorCorrect = false;
            }

            if ((mirrorMiddle.GetComponent<RotateOnClick>().rotateCount) == (mirrorMiddle.GetComponent<RotateOnClick>().winningFaceCount))
            {
                middleMirrorCorrect = true;
            }
            else if ((mirrorMiddle.GetComponent<RotateOnClick>().rotateCount) != (mirrorMiddle.GetComponent<RotateOnClick>().winningFaceCount))
            {
                middleMirrorCorrect = false;
            }

            if ((farMirrorCorrect == true) && (middleMirrorCorrect == true))
            {
                //Main Mirror Puzzle Solved: Play Sound!
                StartCoroutine(playMirrorWinSound());
                mirrorPuzzleSolved = true;

                middleLight.GetComponent<Light>().enabled = true;

                //Destroy(farRubble);
                //Destroy(halfPillarHall1);
                //Destroy(halfPillarHall2);

                farRubble.SetActive(false);

                halfPillarHall1.SetActive(false);
                halfPillarHall2.SetActive(false);

                newPillarHall1.GetComponent<MeshRenderer>().enabled = true;
                newPillarHall2.GetComponent<MeshRenderer>().enabled = true;

                newPillarHall1.GetComponent<BoxCollider>().enabled = true;
                newPillarHall2.GetComponent<BoxCollider>().enabled = true;
                //hallVines1.GetComponentInChildren<MeshRenderer>().enabled = true;
                //hallVines2.GetComponentInChildren<MeshRenderer>().enabled = true;
                foreach (MeshRenderer mr in hallVines1.GetComponentsInChildren<MeshRenderer>())
                {
                    mr.enabled = true;
                }
                foreach (MeshRenderer mr in hallVines2.GetComponentsInChildren<MeshRenderer>())
                {
                    mr.enabled = true;
                }
                //foreach (MeshRenderer mr in hallPlants.GetComponentsInChildren<MeshRenderer>()) {
                //    mr.enabled = true;
                //}
                hallPlant1.SetActive(true);
                hallPlant2.SetActive(true);
                hallPlant3.SetActive(true);
                hallPlant4.SetActive(true);
                hallPlant5.SetActive(true);
            }
            else if ((farMirrorCorrect == false) || (middleMirrorCorrect == false))
            {
                middleLight.GetComponent<Light>().enabled = false;

                //Destroy(farRubble);
                //Destroy(halfPillarHall1);
                //Destroy(halfPillarHall2);

                if (harrietActive)
                {
                    farRubble.SetActive(true);

                    halfPillarHall1.SetActive(true);
                    halfPillarHall2.SetActive(true);

                    newPillarHall1.GetComponent<MeshRenderer>().enabled = false;
                    newPillarHall2.GetComponent<MeshRenderer>().enabled = false;

                    newPillarHall1.GetComponent<BoxCollider>().enabled = false;
                    newPillarHall2.GetComponent<BoxCollider>().enabled = false;
                    //hallVines1.GetComponentInChildren<MeshRenderer>().enabled = false;
                    //hallVines2.GetComponentInChildren<MeshRenderer>().enabled = false;
                    foreach (MeshRenderer mr in hallVines1.GetComponentsInChildren<MeshRenderer>())
                    {
                        mr.enabled = false;
                    }
                    foreach (MeshRenderer mr in hallVines2.GetComponentsInChildren<MeshRenderer>())
                    {
                        mr.enabled = false;
                    }
                    //foreach (MeshRenderer mr in hallPlants.GetComponentsInChildren<MeshRenderer>())
                    //{
                    //    mr.enabled = false;
                    //}
                    hallPlant1.SetActive(false);
                    hallPlant2.SetActive(false);
                    hallPlant3.SetActive(false);
                    hallPlant4.SetActive(false);
                    hallPlant5.SetActive(false);
                }
            }

            //Checks for back mirror, revealing the left alcove with treasure in it
            if ((mirrorBack.GetComponent<RotateOnClick>().rotateCount) == (mirrorBack.GetComponent<RotateOnClick>().winningFaceCount))
            {
                backMirrorCorrect = true;
            }
            else if ((mirrorBack.GetComponent<RotateOnClick>().rotateCount) != (mirrorBack.GetComponent<RotateOnClick>().winningFaceCount))
            {
                backMirrorCorrect = false;
            }

            if (backMirrorCorrect == true)
            {
                treasureRoomCheck = 1;
                /*ACHIEVEMENT: UNVEIL THE TREASURE ROOM */

                //Destroy(alcoveRubble);
                //Destroy(halfPillarAlcove1);
                //Destroy(halfPillarAlcove2);

                alcoveRubble.SetActive(false);

                halfPillarAlcove1.SetActive(false);
                halfPillarAlcove2.SetActive(false);

                newPillarAlcove1.GetComponent<MeshRenderer>().enabled = true;
                newPillarAlcove2.GetComponent<MeshRenderer>().enabled = true;
                //alcoveVines1.GetComponentInChildren<MeshRenderer>().enabled = true;
                //alcoveVines2.GetComponentInChildren<MeshRenderer>().enabled = true;
                foreach (MeshRenderer mr in alcoveVines1.GetComponentsInChildren<MeshRenderer>())
                {
                    mr.enabled = true;
                }
                foreach (MeshRenderer mr in alcoveVines2.GetComponentsInChildren<MeshRenderer>())
                {
                    mr.enabled = true;
                }
                //foreach (MeshRenderer mr in alcovePlants.GetComponentsInChildren<MeshRenderer>())
                //{
                //    mr.enabled = true;
                //}
                alcovePlant1.SetActive(true);
                alcovePlant2.SetActive(true);
                alcovePlant3.SetActive(true);
                alcovePlant4.SetActive(true);
                alcovePlant5.SetActive(true);
            }
            else if (backMirrorCorrect == false)
            {
                if (harrietActive)
                {
                    alcoveRubble.SetActive(true);

                    halfPillarAlcove1.SetActive(true);
                    halfPillarAlcove2.SetActive(true);

                    newPillarAlcove1.GetComponent<MeshRenderer>().enabled = false;
                    newPillarAlcove2.GetComponent<MeshRenderer>().enabled = false;
                    //alcoveVines1.GetComponentInChildren<MeshRenderer>().enabled = false;
                    //alcoveVines2.GetComponentInChildren<MeshRenderer>().enabled = false;
                    foreach (MeshRenderer mr in alcoveVines1.GetComponentsInChildren<MeshRenderer>())
                    {
                        mr.enabled = false;
                    }
                    foreach (MeshRenderer mr in alcoveVines2.GetComponentsInChildren<MeshRenderer>())
                    {
                        mr.enabled = false;
                    }
                    /*
                    foreach (MeshRenderer mr in alcovePlants.GetComponentsInChildren<MeshRenderer>())
                    {
                        mr.enabled = false;
                    }
                    */
                    alcovePlant1.SetActive(false);
                    alcovePlant2.SetActive(false);
                    alcovePlant3.SetActive(false);
                    alcovePlant4.SetActive(false);
                    alcovePlant5.SetActive(false);
                }
            }
        }

        // SECTION C: PLATES
        //determine if table is in correct orientation
        if (leftTable.GetComponent<RearrangeTablesOnClick>().posValue == leftTable.GetComponent<RearrangeTablesOnClick>().correctPlateOrientation)
        {
            leftTableCorrect = true;
        }
        else if (leftTable.GetComponent<RearrangeTablesOnClick>().posValue != leftTable.GetComponent<RearrangeTablesOnClick>().correctPlateOrientation)
        {
            leftTableCorrect = false;
        }

        if (rightTable.GetComponent<RearrangeTablesOnClick>().posValue == rightTable.GetComponent<RearrangeTablesOnClick>().correctPlateOrientation)
        {
            rightTableCorrect = true;
        }
        else if (rightTable.GetComponent<RearrangeTablesOnClick>().posValue != rightTable.GetComponent<RearrangeTablesOnClick>().correctPlateOrientation)
        {
            rightTableCorrect = false;
        }

        /*
        leftTableCorrect |= leftTable.GetComponent<RearrangeTableOnClick>().posValue == leftTable.GetComponent<RearrangeTableOnClick>().correctPlateOrientation;
        rightTableCorrect |= rightTable.GetComponent<RearrangeTableOnClick>().posValue == rightTable.GetComponent<RearrangeTableOnClick>().correctPlateOrientation;
        */

        //if left tables are correct
        if (leftTableCorrect == true)
        {
            //Debug.Log("Correct Left Plates");
            //inscriptionL.GetComponent<SpriteRenderer>().enabled = false;
            //inscriptionLCorrect.GetComponent<SpriteRenderer>().enabled = true;
            inscriptionL.SetActive(false);
            inscriptionLCorrect.SetActive(true);
        }
        else
        {
            inscriptionL.SetActive(true);
            inscriptionLCorrect.SetActive(false);
        }

        //if right tables are correct
        if (rightTableCorrect == true)
        {
            //Debug.Log("Correct Right Plates");
            //inscriptionR.GetComponent<SpriteRenderer>().enabled = false;
            //inscriptionRCorrect.GetComponent<SpriteRenderer>().enabled = true;
            inscriptionR.SetActive(false);
            inscriptionRCorrect.SetActive(true);
        }
        else
        {
            inscriptionR.SetActive(true);
            inscriptionRCorrect.SetActive(false);
        }

        /*
         * FINAL CHECK: BOTH MIRRORS ARE ALIGNED, AND THE TABLES ARE CORRECTLY ORIENTED
        */
        if ((farMirrorCorrect == true) && (middleMirrorCorrect == true) && (leftTableCorrect == true) && (rightTableCorrect == true))
        {
            //Debug.Log("LEVEL COMPLETE");

            //Plate Puzzle Solved: Play Sound!
            StartCoroutine(playPlateWinSound());
            platesPuzzleSolved = true;

            keyhole.SetActive(true);

            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                //turn screenpoint into ray, from the camera into mouse position
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit, 100.0f))
                {
                    if (hit.transform != null)
                    {
                        print("hit: " + hit.transform.gameObject + ", this: " + this.transform.gameObject);

                        BoxCollider bc;
                        if (bc = hit.transform.GetComponent<BoxCollider>())
                        {
                            if (hit.transform.gameObject == keyhole.transform.gameObject)
                            {
                                //check if object being clicked is equal to the "this" object the script is attached to.
                                if (harrietActive == true)
                                {
                                    keyhole.GetComponent<AudioScript>().PlaySound();
                                    StartCoroutine(Lvl3Cutscene());
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}