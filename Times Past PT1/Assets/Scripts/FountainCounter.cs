using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FountainCounter : MonoBehaviour {

    Scene scene;

    GameObject F1, F2, F3, F4;

    int fountainsClicked;

    bool fountain1, fountain2, fountain3, fountain4;

    public void Awake() {
        DontDestroyOnLoad(gameObject);
        fountainsClicked = 0;
    }

    // Use this for initialization
    void Start () {
        scene = SceneManager.GetActiveScene();

        if (scene.name == "TutorialLevel") {
            F1 = GameObject.Find("fountain");
            F2 = GameObject.Find("fountain (1)");
        } else if (scene.name == "GardenLevel") {
            F3 = GameObject.Find("Garden Fountain");
            F4 = GameObject.Find("Garden Fountain (1)");
        }

        //print("fountain: " + this);
        fountain1 = false;
        fountain2 = false;
        fountain3 = false;
        fountain4 = false;
    }
	
	// Update is called once per frame
	void Update () {
        print(fountainsClicked);

        if (scene.name == "TutorialLevel") {
            if (fountain1 == false) {
                if ((F1.GetComponent<DialogueOnClick>().harrietHasClicked == true) || (F1.GetComponent<DialogueOnClick>().basilHasClicked == true)) {
                    print("1st fountain clicked");
                    StartCoroutine(AddToFountainTotal());
                    fountain1 = true;
                }
            }
            if (fountain2 == false)
            {
                if ((F2.GetComponent<DialogueOnClick>().harrietHasClicked == true) || (F2.GetComponent<DialogueOnClick>().basilHasClicked == true))
                {
                    print("2nd fountain clicked");
                    StartCoroutine(AddToFountainTotal());
                    fountain2 = true;
                }
            }
        }

        if (scene.name == "GardenLevel") {
            if (fountain3 == false)
            {
                if ((F3.GetComponent<DialogueOnClick>().harrietHasClicked == true) || (F3.GetComponent<DialogueOnClick>().basilHasClicked == true))
                {
                    print("1st garden fountain clicked");
                    StartCoroutine(AddToFountainTotal());
                    fountain3 = true;
                }
            }
            if (fountain4 == false)
            {
                if ((F4.GetComponent<DialogueOnClick>().harrietHasClicked == true) || (F4.GetComponent<DialogueOnClick>().basilHasClicked == true))
                {
                    print("2nd garden fountain clicked");
                    StartCoroutine(AddToFountainTotal());
                    fountain4 = true;
                }
            }
        }

        if ((fountain1 == true) && (fountain2 == true) && (fountain3 == true) && (fountain4 == true)){
            AchievementManager.instance.UnlockAchievement(Achievement.A5);
        }
	}

    IEnumerator AddToFountainTotal() {
        yield return fountainsClicked += 1;
    }
}
