using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinStateLevel2: MonoBehaviour {

    GameObject buttonLeft, buttonRight;

    GameObject skylight, hatch, skylightLight, plants, trees, gate1, gate2, gate3, gate4;
    GameObject tree1, tree2, tree3, tree4;

    GameObject keyhole;

    Vector3 hatchPos1, hatchPos2;
    int hatchState;

    public bool treeStairsReady;

    public bool treeStairs1, treeStairs2;

    Animator animHatch;

    //Character check
    GameObject characterSwitchControl;
    bool harrietActive, basilActive;

    //puzzle solved objects
    GameObject levelCompleteSound;
    public bool skylightPuzzleSolved, stairsPuzzleSolved;

    // Use this for initialization
    void Start () {
        //buttonLeft = GameObject.Find("ButtonLeft");
        buttonRight = GameObject.Find("ButtonRight");

        skylight = GameObject.Find("pronged-part");
        hatch = GameObject.Find("hatch-part");
        skylightLight = GameObject.Find("Point Light Sun Skylight");
        plants = GameObject.Find("FutureFlora");

        skylightLight.GetComponent<Light>().enabled = true;
        plants.GetComponentInChildren<MeshRenderer>().enabled = true;

        hatchState = 0;
        hatchPos1 = new Vector3 (6.4f, 48.5f, 15f);
        hatchPos2 = new Vector3 (6.4f, 48.5f, 0.1f);

        //rotate skylight on start
        skylight.transform.Rotate(0, 144, 0, Space.Self);

        gate1 = GameObject.Find("gate1");
        gate2 = GameObject.Find("gate2");
        gate3 = GameObject.Find("gate3");
        gate4 = GameObject.Find("gate4");

        trees = GameObject.Find("TreeStairs");

        tree1 = GameObject.Find("square-bush");
        tree2 = GameObject.Find("square-bush (1)");
        tree3 = GameObject.Find("square-bush (2)");
        tree4 = GameObject.Find("square-bush (3)");

        treeStairsReady = false;

        keyhole = GameObject.Find("keyhole");

        keyhole.SetActive(false);

        animHatch = hatch.GetComponent<Animator>();

        levelCompleteSound = GameObject.Find("LevelCompleteSound");
        skylightPuzzleSolved = false;
        stairsPuzzleSolved = false;
    }
	
	// Update is called once per frame
	void Update () {
        //Check active character
        CheckCharacter();

        /*
         * SKYLIGHT PUZZLE
         * 
        */

        if (hatchState == 0) {
            hatchState = 1;
        } else if (hatchState == 1) {
            hatchState = 0;
        }

        if (hatchState == 0) {
            //hatch opened, light enabled, plants growing
            //hatch.transform.position = hatchPos1;
            animHatch.SetBool("isOpened", true);

            skylightLight.GetComponent<Light>().enabled = true;
            plants.GetComponent<CapsuleCollider>().enabled = true;
            foreach (MeshRenderer mr in plants.GetComponentsInChildren<MeshRenderer>()) {
                mr.enabled = true;
            }
        } else if (hatchState == 1) {
            //hatch closed, light disabled, no plants
            //hatch.transform.position = hatchPos2;
            animHatch.SetBool("isOpened", false);

            skylightLight.GetComponent<Light>().enabled = false;
            plants.GetComponent<CapsuleCollider>().enabled = false; 
            foreach (MeshRenderer mr in plants.GetComponentsInChildren<MeshRenderer>()) {
                mr.enabled = false;
            }
        }


        if (buttonRight.GetComponent<RotateHatchOnClick>().hatchRotationValue == buttonRight.GetComponent<RotateHatchOnClick>().hatchWinState) {
            //Win state: Close the skylight, remove the plants for Harriet, remove the spotlight
            hatchState = 0;

            //Skylight Puzzle Solved: Play Sound!
            StartCoroutine(playSkylightWinSound());
            skylightPuzzleSolved = true;
        } else if (buttonRight.GetComponent<RotateHatchOnClick>().hatchRotationValue != buttonRight.GetComponent<RotateHatchOnClick>().hatchWinState) {
            hatchState = 1;
        }

        /*
         * INSCRIPTION PUZZLE
        */

        /*
         * WATER PUZZLE
        */
        if (((gate1.GetComponent<LiftGateOnClick>().heightPosValue == 0) && (gate2.GetComponent<LiftGateOnClick>().heightPosValue == 1) && (gate3.GetComponent<LiftGateOnClick>().heightPosValue == 2) && (gate4.GetComponent<LiftGateOnClick>().heightPosValue == 3)) ||
            ((gate1.GetComponent<LiftGateOnClick>().heightPosValue == 3) && (gate2.GetComponent<LiftGateOnClick>().heightPosValue == 2) && (gate3.GetComponent<LiftGateOnClick>().heightPosValue == 1) && (gate4.GetComponent<LiftGateOnClick>().heightPosValue == 0))) {
            //print("bushes are now stairs for Harriet");
            treeStairsReady = true;
        } else {
            treeStairsReady = false;
        }


        //print("Trees: " + treeStairsReady);



        /*
         * WIN STATE
         * 
        */
        if (treeStairsReady == true) {
            keyhole.SetActive(true);

            //Tree Stairs Puzzle Solved: Play Sound!
            StartCoroutine(playStairsWinSound());
            stairsPuzzleSolved = true;

            //if (trees.GetComponent<Clickable>() == null) {
            //    trees.AddComponent<Clickable>();
            //    trees.AddComponent<ClimbStairsOnClick>();
            //}


            //if ((tree1.GetComponent<Clickable>() == null) || (tree2.GetComponent<Clickable>() == null) || (tree3.GetComponent<Clickable>() == null) || (tree4.GetComponent<Clickable>() == null))
            //{
            //    tree1.AddComponent<Clickable>();
            //    tree1.AddComponent<ClimbStairsOnClick>();

            //    tree2.AddComponent<Clickable>();
            //    tree2.AddComponent<ClimbStairsOnClick>();

            //    tree3.AddComponent<Clickable>();
            //    tree3.AddComponent<ClimbStairsOnClick>();

            //    tree4.AddComponent<Clickable>();
            //    tree4.AddComponent<ClimbStairsOnClick>();
            //}

            if (Input.GetMouseButtonDown(0)) {
                RaycastHit hit;
                //turn screenpoint into ray, from the camera into mouse position
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit, 100.0f))
                {
                    if (hit.transform != null)
                    {
                        //print("hit: " + hit.transform.gameObject + ", this: " + this.transform.gameObject);

                        BoxCollider bc;
                        if (bc = hit.transform.GetComponent<BoxCollider>())
                        {
                            if (hit.transform.gameObject == keyhole.transform.gameObject) {
                                //check if object being clicked is equal to the "this" object the script is attached to.

                                if (harrietActive == true) {
                                    //StartCoroutine(GoToEnd());
                                    //Debug.Log("Win state, Harriet Active, click on the keyhole");
                                    keyhole.GetComponent<AudioScript>().PlaySound();
                                    StartCoroutine(GoToEnd());
                                }

                            }
                        }
                    }
                }
            }
        } else if (treeStairsReady == false) {
            keyhole.SetActive(false);
        }
    }

    IEnumerator playSkylightWinSound() {
        while (skylightPuzzleSolved == false) {
            yield return new WaitForSeconds(1f);
            levelCompleteSound.GetComponent<AudioScript>().PlaySound();
            yield return new WaitForSeconds(0.5f);
        }
    }

    IEnumerator playStairsWinSound()
    {
        while (stairsPuzzleSolved == false)
        {
            levelCompleteSound.GetComponent<AudioScript>().PlaySound();
            yield return new WaitForSeconds(0.5f);
        }
    }

    IEnumerator GoToEnd() {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(7);
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
}
