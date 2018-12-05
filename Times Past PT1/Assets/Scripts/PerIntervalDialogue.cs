using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PerIntervalDialogue : MonoBehaviour {
    [SerializeField]
    GameObject harrietJokes;

    [SerializeField]
    GameObject basilJokes;

    public TextMeshProUGUI harrietJokeDisplay;
    public TextMeshProUGUI basilJokeDisplay;

    public string[] harrietSpokenJokes;
    public string[] basilSpokenJokes;

    int harrietJokeVal = 0;
    int basilJokeVal = 0;

    float talkingDelay = 5f; //talks every 10f
    float closeDelay = 2f; //closes dialogue after 3f
    float startDelay = 1f; //resets after 1f

    bool harrietTalking, basilTalking;

    //character switch control
    GameObject characterSwitchControl;
    bool harrietActive;
    bool basilActive;

    GameObject dialogueCameraH, dialogueCameraB;


    // Use this for initialization
    void Start () {
        harrietJokes.GetComponent<Canvas>().enabled = false;
        basilJokes.GetComponent<Canvas>().enabled = false;

        harrietJokeVal = 0;
        basilJokeVal = 0;

        harrietTalking = false;
        basilTalking = false;

        characterSwitchControl = GameObject.Find("CharacterSwitchControl");
        harrietActive = true;
        basilActive = false;

        dialogueCameraH = GameObject.Find("HarrietCamera");
        dialogueCameraB = GameObject.Find("BasilCamera");

        /* SHOW AND HIDE DIALOGUE FOR HARRIET AND BASIL, WHOEVER IS ACTIVE */
        StartCoroutine(HarrietRoutine());
        StartCoroutine(BasilRoutine());
    }

    // Update is called once per frame
    void Update()
    {
        //print("Harriet Timer: " + timerUntilMessageHarriet + ",  Basil Timer: " + timerUntilMessageBasil);

        //determine active character
        if ((characterSwitchControl.GetComponent<SwitchCharacter>().characterSelect) == 0)
        {
            harrietActive = true;
            basilActive = false;
        }
        else if ((characterSwitchControl.GetComponent<SwitchCharacter>().characterSelect) == 1)
        {
            basilActive = true;
            harrietActive = false;
        }
    }


    public WaitForEndOfFrame WaitFrame = new WaitForEndOfFrame();

    /*HARRIET'S COROUTINES*/
    float timerUntilMessageHarriet;

    //private IEnumerator HarrietRoutine() {
    IEnumerator HarrietRoutine()
    {
        //Debug.Log("Harriet Routine running");

        timerUntilMessageHarriet = 30.00f;
        while (true)
        {

            if (harrietActive) {

                // While harriet is selected, tick timer down.
                timerUntilMessageHarriet -= Time.deltaTime;
            }

            if (timerUntilMessageHarriet <= 0.0f) {
                //Debug.Log("H Talks");
                // Line begins.
                yield return StartCoroutine(SayLineHarriet());
                // Line finished.
                timerUntilMessageHarriet = 30.00f;
            }

            yield return WaitFrame;
        }
    }

    //private IEnumerator SayLineHarriet() {
    IEnumerator SayLineHarriet()
    {
        if (dialogueCameraB.GetComponent<Camera>().enabled == false) {
            // setactive true the canvas
            harrietJokes.GetComponent<Canvas>().enabled = true;
            // populate text
            harrietJokeDisplay.text = harrietSpokenJokes[harrietJokeVal];

            yield return new WaitForSeconds(3f);

            // whipe text to blank
            harrietJokeDisplay.text = "";
            // setactive false the canvas
            harrietJokes.GetComponent<Canvas>().enabled = false;
            // ++ line index
            yield return harrietJokeVal += 1;

            if (harrietJokeVal > harrietSpokenJokes.Length - 1)
            {
                harrietJokeVal = 0;
            }

            //yield return StartCoroutine(RestartTalking());

            yield break;

        } else if (dialogueCameraB.GetComponent<Camera>().enabled == true) {
            timerUntilMessageHarriet = 30.0f;
            yield break;
        }
    }

    /*BASIL'S COROUTINES*/
    float timerUntilMessageBasil;
    //private IEnumerator BasilRoutine()
    IEnumerator BasilRoutine()
    {
        //Debug.Log("Basil Routine running");

        timerUntilMessageBasil = 30.00f;
        while (true)
        {
           
            if (basilActive)
            {

                // While Basil is selected, tick timer down.
                timerUntilMessageBasil -= Time.deltaTime;
            }


            if (timerUntilMessageBasil <= 0.0f)
            {
                //Debug.Log("Basil Talks");
                // Line begins.
                yield return StartCoroutine(SayLineBasil());
                // Line finished.
                timerUntilMessageBasil = 30.00f;

            }

            yield return WaitFrame;
        }
    }

    //private IEnumerator SayLineBasil()
    IEnumerator SayLineBasil() {
        if (dialogueCameraH.GetComponent<Camera>().enabled == false) {
            // setactive true the canvas
            basilJokes.GetComponent<Canvas>().enabled = true;
            // populate text
            basilJokeDisplay.text = basilSpokenJokes[basilJokeVal];

            yield return new WaitForSeconds(3f);

            // whipe text to blank
            basilJokeDisplay.text = "";
            // setactive false the canvas
            basilJokes.GetComponent<Canvas>().enabled = false;
            // ++ line index
            yield return basilJokeVal += 1;

            if (basilJokeVal > basilSpokenJokes.Length - 1)
            {
                basilJokeVal = 0;
            }
            yield break;
        } else if (dialogueCameraH.GetComponent<Camera>().enabled == true) {
                timerUntilMessageBasil = 30.0f;
        }
    }
}
