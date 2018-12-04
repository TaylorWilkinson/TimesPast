using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PuzzleSolved : MonoBehaviour {
    Scene scene;

    GameObject winController;

	// Use this for initialization
	void Start () {
        scene = SceneManager.GetActiveScene();

        winController = GameObject.Find("Win State Controller");
	}

    // Update is called once per frame
    void Update() {
        if (scene.name == "TutorialLevel") {
            if (winController.GetComponent<WinStateTutorial>().puzzleSolved == true) {
                StartCoroutine(PlayWinSound());
            }
        }

        if (scene.name == "Level1") {
            if (winController.GetComponent<WinStateLevel1>().mirrorPuzzleSolved == true) {
                StartCoroutine(PlayWinSound());
            }

            if (winController.GetComponent<WinStateLevel1>().platesPuzzleSolved == true) {
                StartCoroutine(PlayWinSound());
            }
        }

        if (scene.name == "GardenLevel") {
            if (winController.GetComponent<WinStateLevel2>().skylightPuzzleSolved == true) {
                StartCoroutine(PlayWinSound());
            }
            if (winController.GetComponent<WinStateLevel2>().stairsPuzzleSolved == true)
            {
                StartCoroutine(PlayWinSound());
            }
        }
    }

    IEnumerator PlayWinSound() {
        this.GetComponent<AudioScript>().PlaySound();
        yield return new WaitForSeconds(0f);
    }
}
