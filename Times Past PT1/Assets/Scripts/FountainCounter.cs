using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FountainCounter : MonoBehaviour {

    Scene scene;

    GameObject F1, F2, F3, F4;

    int fountainsClicked = 0;

    bool fountain1, fountain2, bothFountainsClicked;

    // Use this for initialization
    void Start () {
        scene = SceneManager.GetActiveScene();

        F1 = GameObject.Find("fountain");
        F2 = GameObject.Find("fountain (1)");
        F3 = GameObject.Find("Garden Fountain");
        F4 = GameObject.Find("Garden Fountain (1)");

        //print("fountain: " + this);
        fountain1 = false;
        fountain2 = false;
        bothFountainsClicked = false;
    }
	
	// Update is called once per frame
	void Update () {
        //print(fountainsClicked);

        if (fountain1 == false)
        {
            if ((F1.GetComponent<DialogueOnClick>().harrietHasClicked == true) || (F1.GetComponent<DialogueOnClick>().basilHasClicked == true))
            {
                //print("1st fountain clicked");
                StartCoroutine(AddToFountainTotal());
                fountain1 = true;
            }
        }
        if (fountain2 == false)
        {
            if ((F2.GetComponent<DialogueOnClick>().harrietHasClicked == true) || (F2.GetComponent<DialogueOnClick>().basilHasClicked == true))
            {
                //print("2nd fountain clicked");
                StartCoroutine(AddToFountainTotal());
                fountain2 = true;
            }
        }

        if (bothFountainsClicked == false) {
            if (fountainsClicked >= 2)
            {
                AchievementManager.instance.UnlockAchievement(Achievement.A4);
                bothFountainsClicked = true;
            }
        }
	}

    IEnumerator AddToFountainTotal() {
        yield return fountainsClicked += 1;
    }
}
