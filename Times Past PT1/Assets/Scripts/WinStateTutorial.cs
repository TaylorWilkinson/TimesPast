using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinStateTutorial : MonoBehaviour {

    /*
     * Tutorial Win State:
     * 1) Harriet interacts with the tree and notes how it exists for her
     * 2) After Harriet interacts with the tree, Basil can pluck the sprout on the ground
    */

    GameObject tree, sprout, keyhole, winSound;

    //character switch control
    GameObject characterSwitchControl;
    bool harrietActive;
    bool basilActive;

    //puzzle solved objects
    GameObject levelCompleteSound;
    public bool puzzleSolved;

    // Use this for initialization
    void Start() {
        characterSwitchControl = GameObject.Find("CharacterSwitchControl");
        harrietActive = true;
        basilActive = false;

        tree = GameObject.Find("DeadTree");
        sprout = GameObject.Find("Grass_g_01");
        keyhole = GameObject.Find("keyhole");
        winSound = GameObject.Find("LevelCompleteSound");

        keyhole.SetActive(false);

        levelCompleteSound = GameObject.Find("LevelCompleteSound");
        puzzleSolved = false;
    }

    // Update is called once per frame
    void Update() {
        //determine active character
        if ((characterSwitchControl.GetComponent<SwitchCharacter>().characterSelect) == 0) {
            harrietActive = true;
            basilActive = false;
        } else if ((characterSwitchControl.GetComponent<SwitchCharacter>().characterSelect) == 1) {
            basilActive = true;
            harrietActive = false;
        }

        if ((sprout == null) && (tree == null)) {
            //Debug.Log("done! open the door!");

            //The tree is now gone, let Harriet access the keyhole
            keyhole.SetActive(true);

            //Puzzle Solved: Play Sound!
            StartCoroutine(PlayWinSound());
            puzzleSolved = true;


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
                            if (hit.transform.gameObject == keyhole.transform.gameObject)
                            {
                                //check if object being clicked is equal to the "this" object the script is attached to.
                                if (harrietActive == true) {
                                    //play unlocking sound
                                    keyhole.GetComponent<AudioScript>().PlayAlternateSound();
                                    StartCoroutine(Lvl2Cutscene());
                                }
                            }
                        }
                    }
                }
            }
        }
    }

    IEnumerator PlayWinSound() {
        while (puzzleSolved == false) {
            levelCompleteSound.GetComponent<AudioScript>().PlaySound();
            //print("DOO DOO DOO DOO DOO DOO DOO!");
            yield return new WaitForSeconds(0.5f);
            //puzzleSolved = true;
        }
    }

    IEnumerator Lvl2Cutscene() {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(3);
    }
}