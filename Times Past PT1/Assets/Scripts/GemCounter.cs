using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GemCounter : MonoBehaviour {
    public int score = 0;
    public TextMeshProUGUI scoreText;
 
	// Use this for initialization
	void Start () {

    }

    void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }

    // Update is called once per frame
    void Update () {
        scoreText.SetText(score.ToString());
    }
}
