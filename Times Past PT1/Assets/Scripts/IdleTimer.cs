using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleTimer : MonoBehaviour {
    GameObject characterSwitchControl;
    bool harrietActive, basilActive;

    GameObject harriet, basil, dialogueCameraH, dialogueCameraB;

    Vector3 movement;
    Vector3 zeroMovement;
    bool achieved;

    float timerUntilHarrietIdle;
    float timerUntilBasilIdle;

    public void Awake() {
        DontDestroyOnLoad(gameObject);
    }

    // Use this for initialization
    void Start () {
        harriet = GameObject.Find("Harriet");
        basil = GameObject.Find("Basil");

        dialogueCameraH = GameObject.Find("HarrietCamera");
        dialogueCameraB = GameObject.Find("BasilCamera");

        zeroMovement = new Vector3(0, 0, 0);

        timerUntilHarrietIdle = 30.0f;
        timerUntilBasilIdle = 30.0f;

        achieved = false;
    }
	
	// Update is called once per frame
	void Update () {
        CheckCharacter();
        CheckMovement();

        //print("Achieved: " + achieved);

        //print("BasilCamera: " + dialogueCameraB.GetComponent<Camera>().enabled + ", HarrietCamera: " + dialogueCameraH.GetComponent<Camera>().enabled);

        if (harrietActive)
        {
            if (movement == zeroMovement)
            {
                if (dialogueCameraB.GetComponent<Camera>().enabled == false) {
                    if (achieved == false) {
                        StartCoroutine(TimerDelayedStart());
                        //print("HARRIET NOT MOVING");
                        StartCoroutine(HarrietIdleCounter());
                    }
                }
            }
        }

        if (basilActive) {
            if (movement == zeroMovement) {
                if (dialogueCameraH.GetComponent<Camera>().enabled == false) {
                    if (achieved == false) {
                        StartCoroutine(TimerDelayedStart());
                        //print("BASIL NOT MOVING");
                        StartCoroutine(BasilIdleCounter());
                    }
                }
            }
        }
    }

    void CheckMovement() {
        //updated movement code reference: https://forum.unity.com/threads/2d-8-directional-movement-and-animation.455217/
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");

        movement = new Vector3(inputX, 0, inputY);
    }

    void CheckCharacter() {
        //DETERMINE ACTIVE CHARACTER
        characterSwitchControl = GameObject.Find("CharacterSwitchControl");
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

    IEnumerator TimerDelayedStart() {
        yield return new WaitForSeconds(4);
    }


    IEnumerator HarrietIdleCounter() {
        timerUntilHarrietIdle -= Time.deltaTime;

        if (timerUntilHarrietIdle < 1.0f) {
            AchievementManager.instance.UnlockAchievement(Achievement.A2);
            achieved = true;
        }
        yield return WaitFrame;
    }

    
    IEnumerator BasilIdleCounter() {
        timerUntilBasilIdle -= Time.deltaTime;

        if (timerUntilBasilIdle < 1.0f) {
            AchievementManager.instance.UnlockAchievement(Achievement.A2);
            achieved = true;
        }
        yield return WaitFrame;
    }

}
