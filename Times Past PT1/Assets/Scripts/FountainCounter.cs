using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FountainCounter : MonoBehaviour {

    Scene scene;

    int fountainsClicked;

    bool fountain1, fountain2, fountain3, fountain4;

	// Use this for initialization
	void Start () {
        scene = SceneManager.GetActiveScene();

        print("fountain: " + this);

        fountainsClicked = 0;

        fountain1 = false;
        fountain2 = false;
        fountain3 = false;
        fountain4 = false;
    }
	
	// Update is called once per frame
	void Update () {
        if (scene.name == "TutorialLevel") {
            if (fountain1 == false) {

            }
            if (fountain2 == false)
            {

            }
        }

        if (scene.name == "GardenLevel") {
            if (fountain3 == false)
            {

            }
            if (fountain4 == false)
            {

            }
        }
	}

    IEnumerator AddToFountainTotal()
    {
        yield return fountainsClicked += 1;
    }
}
