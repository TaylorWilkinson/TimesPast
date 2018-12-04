using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Fungus;

public class GemCounterFinalScore : MonoBehaviour {
    public Flowchart flowchart;

    int score;

    GameObject gemScoreCounter;

    public void Start() {
        gemScoreCounter = GameObject.Find("GemScore");
        score = gemScoreCounter.GetComponent<GemCounter>().score;

        flowchart.SetIntegerVariable("FinalScore", score);
    }

    public void FinalScore() {
        if (score < 10)
        {
            Debug.Log("Low Score");
            //send message to Low Score block
            flowchart.SendFungusMessage("Low Score");
        }
        else if (score >= 10)
        {
            Debug.Log("High Score");
            //send message to High Score block
            flowchart.SendFungusMessage("High Score");
        }
    }
}
