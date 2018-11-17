using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractionTrigger : MonoBehaviour {

    Scene scene;

    GameObject sprout, tree;

    GameObject tapestry, languageEngraving, mirror1, mirror2, mirror3, vinePillar1, vinePillar2;

    public bool basilDialogueChange;

    // Use this for initialization
    void Start () {
        scene = SceneManager.GetActiveScene();
        sprout = GameObject.Find("Grass_g_01");
        tree = GameObject.Find("DeadTree");

        tapestry = GameObject.Find("Tapestry Kah");
        languageEngraving = GameObject.Find("inscription-language");
        mirror1 = GameObject.Find("BackMirrorLight");
        mirror2 = GameObject.Find("MiddleMirrorLight");
        mirror3 = GameObject.Find("FarMirrorLight");
        vinePillar1 = GameObject.Find("NewPillarHall1");
        vinePillar2 = GameObject.Find("NewPillarHall3");
    }

    // Update is called once per frame
    void Update() {
        if (scene.name == "TutorialLevel") {
            //Change Sprout Dialogue for Basil
            if (tree != null) {
                if (tree.GetComponent<DialogueOnClick>().harrietHasClicked == true) {
                    basilDialogueChange = true;

                    if (sprout != null) {
                        if (sprout.GetComponent<Clickable>() == null) {
                            sprout.AddComponent<Clickable>();
                            sprout.AddComponent<DestroyOnClick>();
                            sprout.GetComponent<DestroyOnClick>().objectInOtherTime = GameObject.Find("DeadTree");
                            sprout.GetComponent<DestroyOnClick>().requiredCharacter = GameObject.Find("Basil");
                        }
                    }
                }
            }
        }

        if (scene.name == "Level1") {
            //Change Tapestry Dialogue for Basil
            if (languageEngraving.GetComponent<DialogueOnClick>().harrietHasClicked == true) {
                basilDialogueChange = true;

                if (tapestry != null) {
                    if (tapestry.GetComponent<Clickable>() == null) {
                        tapestry.AddComponent<Clickable>();
                        tapestry.AddComponent<DestroyOnClick>();
                        tapestry.GetComponent<DestroyOnClick>().requiredCharacter = GameObject.Find("Basil");
                    }
                }
            }


            //Change Mirror Dialogue for Basil
            if ((vinePillar1.GetComponent<DialogueOnClick>().harrietHasClicked == true) || (vinePillar2.GetComponent<DialogueOnClick>().harrietHasClicked == true)) {
                basilDialogueChange = true;
                //print("vinePillar1: " + vinePillar1.GetComponent<DialogueOnClick>().harrietHasClicked + ", vinePillar2: " + vinePillar2.GetComponent<DialogueOnClick>().harrietHasClicked);
                if (mirror1.GetComponent<Clickable>() == null) {

                    mirror1.AddComponent<Clickable>();
                    mirror1.AddComponent<RotateOnClick>();
                    mirror1.GetComponent<RotateOnClick>().totalRotate = 4;
                    mirror1.GetComponent<RotateOnClick>().rotateCount = 0;
                    mirror1.GetComponent<RotateOnClick>().winningFaceCount = 1;
                    mirror1.GetComponent<RotateOnClick>().mirrorLight = GameObject.Find("Point Light Back").GetComponent<Light>();
                    mirror1.GetComponent<RotateOnClick>().reflectiveValues = new int[] {0, 1};
                    mirror1.GetComponent<RotateOnClick>().requiredCharacter = GameObject.Find("Basil");

                    mirror2.AddComponent<Clickable>();
                    mirror2.AddComponent<RotateOnClick>();
                    mirror2.GetComponent<RotateOnClick>().totalRotate = 4;
                    mirror2.GetComponent<RotateOnClick>().rotateCount = 0;
                    mirror2.GetComponent<RotateOnClick>().winningFaceCount = 2;
                    mirror2.GetComponent<RotateOnClick>().mirrorLight = GameObject.Find("Point Light Middle").GetComponent<Light>();
                    mirror2.GetComponent<RotateOnClick>().reflectiveValues = new int[0];
                    mirror2.GetComponent<RotateOnClick>().requiredCharacter = GameObject.Find("Basil");

                    mirror3.AddComponent<Clickable>();
                    mirror3.AddComponent<RotateOnClick>();
                    mirror3.GetComponent<RotateOnClick>().totalRotate = 4;
                    mirror3.GetComponent<RotateOnClick>().rotateCount = 0;
                    mirror3.GetComponent<RotateOnClick>().winningFaceCount = 3;
                    mirror3.GetComponent<RotateOnClick>().mirrorLight = GameObject.Find("Point Light Far").GetComponent<Light>();
                    mirror3.GetComponent<RotateOnClick>().reflectiveValues = new int[] {0, 3};
                    mirror3.GetComponent<RotateOnClick>().requiredCharacter = GameObject.Find("Basil");
                }
            }
        }
    }
}
