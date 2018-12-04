using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractionTrigger : MonoBehaviour {

    Scene scene;

    GameObject sprout, tree;
    GameObject tapestry, languageEngraving, englishEngraving, mirror1, mirror2, mirror3, vinePillar1, vinePillar2;
    GameObject bushes, gardenEngraving, gardenEngravingEnglish, shrub1, shrub2, shrub3, shrub4, gate1, gate2, gate3, gate4;

    public bool basilDialogueChange, basilDialogueChange2, harrietDialogueChange, treeStairsReady;

    WinStateLevel2 gardenWinStateCheck;

    // Use this for initialization
    void Start () {
        scene = SceneManager.GetActiveScene();

        sprout = GameObject.Find("Grass_g_01");
        tree = GameObject.Find("DeadTree");

        tapestry = GameObject.Find("Tapestry Kah");
        languageEngraving = GameObject.Find("inscription-language");
        englishEngraving = GameObject.Find("inscription-english");
        mirror1 = GameObject.Find("BackMirrorLight");
        mirror2 = GameObject.Find("MiddleMirrorLight");
        mirror3 = GameObject.Find("FarMirrorLight");
        vinePillar1 = GameObject.Find("NewPillarHall1");
        vinePillar2 = GameObject.Find("NewPillarHall3");

        bushes = GameObject.Find("Bushes");
        gardenEngraving = GameObject.Find("garden-inscription-language");
        gardenEngravingEnglish = GameObject.Find("garden-inscription-english");
        shrub4 = GameObject.Find("square-bush");
        shrub3 = GameObject.Find("square-bush (1)");
        shrub2 = GameObject.Find("square-bush (2)");
        shrub1 = GameObject.Find("square-bush (3)");
        gate1 = GameObject.Find("gate1");
        gate2 = GameObject.Find("gate2");
        gate3 = GameObject.Find("gate3");
        gate4 = GameObject.Find("gate4");

        /*
        basilDialogueChange = false;
        basilDialogueChange2 = false;
        harrietDialogueChange = false;
        treeStairsReady = false;
        */

        gardenWinStateCheck = GetComponent<WinStateLevel2>();
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
            //print("clicked engraving" + basilDialogueChange + ", clicked vines" + basilDialogueChange2);

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

                if (tapestry == null) {
                    //print("tapestry gone");
                    if (englishEngraving.GetComponent<ZoomIn>() == null) {
                        englishEngraving.AddComponent<ZoomIn>();
                    }
                }
            }


            //Change Mirror Dialogue for Basil
            if ((vinePillar1.GetComponent<DialogueOnClick>().harrietHasClicked == true) || (vinePillar2.GetComponent<DialogueOnClick>().harrietHasClicked == true)) {
                //basilDialogueChange = true;
                basilDialogueChange2 = true;
                //print("vinePillar1: " + vinePillar1.GetComponent<DialogueOnClick>().harrietHasClicked + ", vinePillar2: " + vinePillar2.GetComponent<DialogueOnClick>().harrietHasClicked);
                if (mirror1.GetComponent<Clickable>() == null) {

                    mirror1.AddComponent<Clickable>();
                    RotateOnClick var1 = mirror1.AddComponent<RotateOnClick>();
                    var1.totalRotate = 4;
                    var1.rotateCount = 0;
                    var1.winningFaceCount = 1;
                    var1.mirrorLight = GameObject.Find("Point Light Back").GetComponent<Light>();
                    var1.reflectiveValues = new int[] { 0, 1 };
                    var1.requiredCharacter = GameObject.Find("Basil");

                    mirror2.AddComponent<Clickable>();
                    RotateOnClick var2 = mirror2.AddComponent<RotateOnClick>();
                    var2.totalRotate = 4;
                    var2.rotateCount = 0;
                    var2.winningFaceCount = 2;
                    var2.mirrorLight = GameObject.Find("Point Light Middle").GetComponent<Light>();
                    var2.reflectiveValues = new int[0];
                    var2.requiredCharacter = GameObject.Find("Basil");

                    mirror3.AddComponent<Clickable>();
                    RotateOnClick var3 = mirror3.AddComponent<RotateOnClick>();
                    var3.totalRotate = 4;
                    var3.rotateCount = 0;
                    var3.winningFaceCount = 3;
                    var3.mirrorLight = GameObject.Find("Point Light Far").GetComponent<Light>();
                    var3.reflectiveValues = new int[] { 0, 3 };
                    var3.requiredCharacter = GameObject.Find("Basil");
                }
            }
        }

        if (scene.name == "GardenLevel") {
            //Have Basil look at the bushes
            if (gardenEngraving.GetComponent<DialogueOnClick>().harrietHasClicked == true)
            {
                basilDialogueChange = true;

                //push down the bushes

                if (bushes.GetComponent<Clickable>() == null)
                {
                    bushes.AddComponent<Clickable>();
                    bushes.AddComponent<PushDownOnClick>();
                    bushes.AddComponent<ZoomIn>();
                }
            }

            //print(gardenWinStateCheck);

            if (gardenWinStateCheck.treeStairsReady == true) {
                harrietDialogueChange = true;

                if (shrub1.GetComponent<Clickable>() == null){
                    shrub1.AddComponent<Clickable>();
                    shrub1.AddComponent<ClimbStairsOnClick>();
                }
                if (shrub2.GetComponent<Clickable>() == null){
                    shrub2.AddComponent<Clickable>();
                    shrub2.AddComponent<ClimbStairsOnClick>();
                }
                if (shrub3.GetComponent<Clickable>() == null)
                {
                    shrub3.AddComponent<Clickable>();
                    shrub3.AddComponent<ClimbStairsOnClick>();
                }
                if (shrub4.GetComponent<Clickable>() == null)
                {
                    shrub4.AddComponent<Clickable>();
                    shrub4.AddComponent<ClimbStairsOnClick>();
                }
            }
            else {
                harrietDialogueChange = false;
            }
        }
    }
}
