using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchCharacter : MonoBehaviour
{

    GameObject harriet, basil;

    public int characterSelect;

    public CameraController cameraController;

    GameObject hFront, hBack, hLeft, hRight, bFront, bBack, bLeft, bRight, kFront, kBack, kLeft, kRight;

    Material defaultMat;
    public Material glowMaterial;
    public Texture hBackTexture, hFrontTexture, hSideTexture, bBackTexture, bFrontTexture, bSideTexture;

    // Use this for initialization
    void Start()
    {
        characterSelect = 0;

        harriet = GameObject.Find("Harriet");
        basil = GameObject.Find("Basil");

        //toggle visibility by accessing the sprites' opacity
        hFront = GameObject.Find("Harriet_Front");
        hBack = GameObject.Find("Harriet_Back");
        hLeft = GameObject.Find("Harriet_Left");
        hRight = GameObject.Find("Harriet_Right");

        bFront = GameObject.Find("Basil_Front");
        bBack = GameObject.Find("Basil_Back");
        bLeft = GameObject.Find("Basil_Left");
        bRight = GameObject.Find("Basil_Right");

        kFront = GameObject.Find("Kah_Front");
        kBack = GameObject.Find("Kah_Back");
        kLeft = GameObject.Find("Kah_Left");
        kRight = GameObject.Find("Kah_Right");

        defaultMat = new Material(Shader.Find("Sprites/Default"));

        //set up material on load
        //Harriet Default:
        hFront.GetComponent<SpriteRenderer>().material = defaultMat;
        hBack.GetComponent<SpriteRenderer>().material = defaultMat;
        hLeft.GetComponent<SpriteRenderer>().material = defaultMat;
        hRight.GetComponent<SpriteRenderer>().material = defaultMat;
        //Basil Glow:
        bFront.GetComponent<SpriteRenderer>().material = glowMaterial;
        bBack.GetComponent<SpriteRenderer>().material = glowMaterial;
        bLeft.GetComponent<SpriteRenderer>().material = glowMaterial;
        bRight.GetComponent<SpriteRenderer>().material = glowMaterial;
        //Glow texture:
        bFront.GetComponent<SpriteRenderer>().material.SetTexture("_MainTex", bFrontTexture);
        bBack.GetComponent<SpriteRenderer>().material.SetTexture("_MainTex", bBackTexture);
        bLeft.GetComponent<SpriteRenderer>().material.SetTexture("_MainTex", bSideTexture);
        bRight.GetComponent<SpriteRenderer>().material.SetTexture("_MainTex", bSideTexture);
    }

    // Update is called once per frame
    void Update()
    {
        //change character when pressing space bar
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

        if (characterSelect == 0)
        {
            //Enable Harriet's Character Controller
            if (harriet.GetComponent<CharacterController>())
            {
                //enable movement
                harriet.GetComponent<MovementClass>().enabled = true;
                //move camera to Harriet
                cameraController.target = harriet.transform;

                //make Harriet active and visible
                //Harriet:
                hFront.GetComponent<SpriteRenderer>().material = defaultMat;
                hBack.GetComponent<SpriteRenderer>().material = defaultMat;
                hLeft.GetComponent<SpriteRenderer>().material = defaultMat;
                hRight.GetComponent<SpriteRenderer>().material = defaultMat;

                //make Kah active and visible
                kFront.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
                kBack.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
                kLeft.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
                kRight.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);
            }
            //Disable Basil's Character Controller
            if (basil.GetComponent<CharacterController>())
            {
                //basil.GetComponent<CharacterController>().enabled = false;
                basil.GetComponent<MovementClass>().enabled = false;

                //Basil Glow:
                bFront.GetComponent<SpriteRenderer>().material = glowMaterial;
                bFront.GetComponent<SpriteRenderer>().material.SetTexture("_MainTex", bFrontTexture);
                bBack.GetComponent<SpriteRenderer>().material = glowMaterial;
                bBack.GetComponent<SpriteRenderer>().material.SetTexture("_MainTex", bBackTexture);
                bLeft.GetComponent<SpriteRenderer>().material = glowMaterial;
                bLeft.GetComponent<SpriteRenderer>().material.SetTexture("_MainTex", bSideTexture);
                bRight.GetComponent<SpriteRenderer>().material = glowMaterial;
                bRight.GetComponent<SpriteRenderer>().material.SetTexture("_MainTex", bSideTexture);
            }
        }
        else if (characterSelect == 1)
        {
            //Disable Harriet's Character Controller
            if (harriet.GetComponent<CharacterController>())
            {
                //disable movement
                harriet.GetComponent<MovementClass>().enabled = false;

                //make Harriet inactive and transparent
                //set glow material
                hFront.GetComponent<SpriteRenderer>().material = glowMaterial;
                hBack.GetComponent<SpriteRenderer>().material = glowMaterial;
                hLeft.GetComponent<SpriteRenderer>().material = glowMaterial;
                hRight.GetComponent<SpriteRenderer>().material = glowMaterial;
                //set main texture
                hFront.GetComponent<SpriteRenderer>().material.SetTexture("_MainTex", hFrontTexture);
                hBack.GetComponent<SpriteRenderer>().material.SetTexture("_MainTex", hBackTexture);
                hLeft.GetComponent<SpriteRenderer>().material.SetTexture("_MainTex", hSideTexture);
                hRight.GetComponent<SpriteRenderer>().material.SetTexture("_MainTex", hSideTexture);

                //make Kah invisible
                /*
                kFront.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 0.20f);
                kBack.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 0.20f);
                kLeft.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 0.20f);
                kRight.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 0.20f);
                */
            }
            //Enable Basil's Character Controller
            if (basil.GetComponent<CharacterController>())
            {
                //enable movement
                basil.GetComponent<MovementClass>().enabled = true;
                //move camera to Basil
                cameraController.target = basil.transform;

                //make Basil active and visible
                //Harriet Default:
                bFront.GetComponent<SpriteRenderer>().material = defaultMat;
                bBack.GetComponent<SpriteRenderer>().material = defaultMat;
                bLeft.GetComponent<SpriteRenderer>().material = defaultMat;
                bRight.GetComponent<SpriteRenderer>().material = defaultMat;

                bFront.GetComponent<SpriteRenderer>().material.SetTexture("_MainTex", hFrontTexture);
                bBack.GetComponent<SpriteRenderer>().material.SetTexture("_MainTex", hBackTexture);
                bLeft.GetComponent<SpriteRenderer>().material.SetTexture("_MainTex", hSideTexture);
                hRight.GetComponent<SpriteRenderer>().material.SetTexture("_MainTex", hSideTexture);
            }
        }
    }
}