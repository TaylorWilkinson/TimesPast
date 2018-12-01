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

    GameObject tree, sprout, keyhole;

    bool harrietClickedTree;
    bool basilPulledSprout;

    //character switch control
    GameObject characterSwitchControl;
    bool harrietActive;
    bool basilActive;

    // Use this for initialization
    void Start() {
        characterSwitchControl = GameObject.Find("CharacterSwitchControl");
        harrietActive = true;
        basilActive = false;

        tree = GameObject.Find("DeadTree");
        sprout = GameObject.Find("Grass_g_01");
        keyhole = GameObject.Find("keyhole");

        keyhole.SetActive(false);
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

            if (Input.GetMouseButtonDown(0)) {
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
                                if (harrietActive == true) {
                                    StartCoroutine(Lvl2Cutscene());
                                }
                            }
                        }
                    }
                }
            }
        }
    }

    IEnumerator Lvl2Cutscene() {
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(4);
    }
}