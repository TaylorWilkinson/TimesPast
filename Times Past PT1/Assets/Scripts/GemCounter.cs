using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using Fungus;

public class GemCounter : MonoBehaviour {
    public int score = 0;
    public TextMeshProUGUI scoreText;
    public Image gemImage;

    Scene scene;
    Flowchart flowchart;
    GameObject flowchartObject;

    void Awake() {
        DontDestroyOnLoad(transform.gameObject);
        gemImage.enabled = false;
        scoreText.enabled = false;
    }

    // Use this for initialization
    void Start () {
        scene = SceneManager.GetActiveScene();
        gemImage.enabled = false;
        scoreText.enabled = false;

        //for Final Cutscene testing vvvv
        //score = 20;
    }

    // Update is called once per frame
    void Update () {
        scoreText.SetText(score.ToString());
        //gemImage.enabled = true;
        //scoreText.enabled = true;

        //print(this);

        Fungus.Flowchart.BroadcastFungusMessage("YourMessage");

        if (scene.name == "FinalCutscene") {
            flowchartObject = GameObject.Find("Flowchart");
            Fungus.Flowchart.BroadcastFungusMessage("Start End Scene");
        }
    }

    public IEnumerator showGemScore() {
        gemImage.enabled = true;
        scoreText.enabled = true;
        yield return new WaitForSeconds(2f);
        gemImage.enabled = false;
        scoreText.enabled = false;
    }

    //public void FinalScore() {
    //    if (score < 10) {
    //        Debug.Log("Low Score");
    //        //send message to Low Score block
    //        flowchart.SendFungusMessage("Low Score");
    //    } else if (score >= 10) {
    //        Debug.Log("High Score");
    //        //send message to High Score block
    //        flowchart.SendFungusMessage("High Score");
    //    }
    //}
}
