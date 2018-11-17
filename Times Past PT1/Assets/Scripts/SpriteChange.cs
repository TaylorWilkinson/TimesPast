using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteChange : MonoBehaviour {

    GameObject hFront;
    GameObject hBack;
    GameObject hLeft;
    GameObject hRight;

    GameObject bFront;
    GameObject bBack;
    GameObject bLeft;
    GameObject bRight;

    Animator animHFront, animHBack, animHLeft, animHRight, animBFront, animBBack, animBLeft, animBRight;

    bool isWalking;

    private Vector3 movement;

    int characterSelect;
    bool harrietActive;
    bool basilActive;

    // Use this for initialization
    void Start () {
        //find the Sprite objects
        hFront = GameObject.Find("Harriet_Front");
        hBack = GameObject.Find("Harriet_Back");
        hLeft = GameObject.Find("Harriet_Left");
        hRight = GameObject.Find("Harriet_Right");

        bFront = GameObject.Find("Basil_Front");
        bBack = GameObject.Find("Basil_Back");
        bLeft = GameObject.Find("Basil_Left");
        bRight = GameObject.Find("Basil_Right");

        //enable only the back-facing sprites
        hFront.GetComponent<SpriteRenderer>().enabled = false;
        hBack.GetComponent<SpriteRenderer>().enabled = true;
        hLeft.GetComponent<SpriteRenderer>().enabled = false;
        hRight.GetComponent<SpriteRenderer>().enabled = false;

        bFront.GetComponent<SpriteRenderer>().enabled = false;
        bBack.GetComponent<SpriteRenderer>().enabled = true;
        bLeft.GetComponent<SpriteRenderer>().enabled = false;
        bRight.GetComponent<SpriteRenderer>().enabled = false;

        characterSelect = 0;

        animHFront = hFront.GetComponent<Animator>();
        animHBack = hBack.GetComponent<Animator>();
        animHLeft = hLeft.GetComponent<Animator>();
        animHRight = hRight.GetComponent<Animator>();
        animBFront = bFront.GetComponent<Animator>();
        animBBack = bBack.GetComponent<Animator>();
        animBLeft = bLeft.GetComponent<Animator>();
        animBRight = bRight.GetComponent<Animator>();

        isWalking = false;
    }
	
	// Update is called once per frame
	void Update () {
        float inputX = Input.GetAxisRaw("Horizontal");
        float inputY = Input.GetAxisRaw("Vertical");

        movement = new Vector3(inputX, 0, inputY);

        if (Input.GetKeyDown("space"))
        {
            //update characterSelect value
            if (characterSelect == 0)
            {
                characterSelect = 1;
            }
            else if (characterSelect == 1)
            {
                characterSelect = 0;
            }
        }


        if (characterSelect == 0) {
            harrietActive = true;
            basilActive = false;
        } else if (characterSelect == 1) {
            harrietActive = false;
            basilActive = true;
        }

        //left/right/up/down movement
        if (movement.z == 1) {
            //up
            if (harrietActive == true) {
                hBack.GetComponent<SpriteRenderer>().enabled = true;
                hFront.GetComponent<SpriteRenderer>().enabled = false;
                hLeft.GetComponent<SpriteRenderer>().enabled = false;
                hRight.GetComponent<SpriteRenderer>().enabled = false;
            } else if (basilActive == true) {
                bBack.GetComponent<SpriteRenderer>().enabled = true;
                bFront.GetComponent<SpriteRenderer>().enabled = false;
                bLeft.GetComponent<SpriteRenderer>().enabled = false;
                bRight.GetComponent<SpriteRenderer>().enabled = false;
            }
        }
        if (movement.z == -1) {
            //down
            if (harrietActive == true) {
                hFront.GetComponent<SpriteRenderer>().enabled = true;
                hBack.GetComponent<SpriteRenderer>().enabled = false;
                hLeft.GetComponent<SpriteRenderer>().enabled = false;
                hRight.GetComponent<SpriteRenderer>().enabled = false;
            } else if (basilActive == true) {
                bFront.GetComponent<SpriteRenderer>().enabled = true;
                bBack.GetComponent<SpriteRenderer>().enabled = false;
                bLeft.GetComponent<SpriteRenderer>().enabled = false;
                bRight.GetComponent<SpriteRenderer>().enabled = false;
            }
        }
        if (movement.x == -1) {
            //left
            if (harrietActive == true) {
                hLeft.GetComponent<SpriteRenderer>().enabled = true;
                hFront.GetComponent<SpriteRenderer>().enabled = false;
                hBack.GetComponent<SpriteRenderer>().enabled = false;
                hRight.GetComponent<SpriteRenderer>().enabled = false;
            }
            else if (basilActive == true) {
                bLeft.GetComponent<SpriteRenderer>().enabled = true;
                bBack.GetComponent<SpriteRenderer>().enabled = false;
                bFront.GetComponent<SpriteRenderer>().enabled = false;
                bRight.GetComponent<SpriteRenderer>().enabled = false;
            }
        }
        if (movement.x == 1) {
            //right
            if (harrietActive == true) {
                hRight.GetComponent<SpriteRenderer>().enabled = true;
                hFront.GetComponent<SpriteRenderer>().enabled = false;
                hBack.GetComponent<SpriteRenderer>().enabled = false;
                hLeft.GetComponent<SpriteRenderer>().enabled = false;
            }
            else if (basilActive == true) {
                bRight.GetComponent<SpriteRenderer>().enabled = true;
                bBack.GetComponent<SpriteRenderer>().enabled = false;
                bFront.GetComponent<SpriteRenderer>().enabled = false;
                bLeft.GetComponent<SpriteRenderer>().enabled = false;
            }
        }

        //update Animator
        //up
        if (Input.GetKeyDown("w") || Input.GetKeyDown("up")) {
            if(harrietActive == true) {
                animHBack.SetBool("isWalking", true);
            } else if (basilActive == true) {
                animBBack.SetBool("isWalking", true);
            }
        }
        if (Input.GetKeyUp("w") || Input.GetKeyUp("up")) {
            if(harrietActive == true) {
                animHBack.SetBool("isWalking", false);
            } else if (basilActive == true) {
                animBBack.SetBool("isWalking", false);
            }
        }

        //down
        if (Input.GetKeyDown("s") || Input.GetKeyDown("down")) {
            if (harrietActive == true)
            {
                animHFront.SetBool("isWalking", true); 
            }
            else if (basilActive == true)
            {
                animBFront.SetBool("isWalking", true);
            }
        }
        if (Input.GetKeyUp("s") || Input.GetKeyUp("down")){
            if (harrietActive == true)
            {
                animHFront.SetBool("isWalking", false);
            }
            else if (basilActive == true)
            {
                animBFront.SetBool("isWalking", false);
            }
        }
        //left
        if (Input.GetKeyDown("a") || Input.GetKeyDown("left"))
        {
            if (harrietActive == true)
            {
                animHLeft.SetBool("isWalking", true);
            }
            else if (basilActive == true)
            {
                animBLeft.SetBool("isWalking", true);
            }
        }
        if (Input.GetKeyUp("a") || Input.GetKeyUp("left"))
        {
            if (harrietActive == true)
            {
                animHLeft.SetBool("isWalking", false);
            }
            else if (basilActive == true)
            {
                animBLeft.SetBool("isWalking", false);
            }
        }
        //right
        if (Input.GetKeyDown("d") || Input.GetKeyDown("right"))
        {
            if (harrietActive == true)
            {
                animHRight.SetBool("isWalking", true);
            }
            else if (basilActive == true)
            {
                animBRight.SetBool("isWalking", true);
            }
        }
        if (Input.GetKeyUp("d") || Input.GetKeyUp("right"))
        {
            if (harrietActive == true)
            {
                animHRight.SetBool("isWalking", false);
            }
            else if (basilActive == true)
            {
                animBRight.SetBool("isWalking", false);
            }
        }

        /*
        if (isWalking == true) {
            animHFront.SetBool("isWalking", true);
        } else {
            animHFront.SetBool("isWalking", false);
        }
        */

        //print(animHFront.GetBool("isWalking"));

    }
}
