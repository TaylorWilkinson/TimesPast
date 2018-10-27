using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickableObject : MonoBehaviour {

    public string objectName;
    public string objectNameInOtherTime;

    GameObject otherObject, middleLight, rightLight;
    //GameObject basil;

    int characterSelect;
    bool harrietActive;
    bool basilActive;

    Vector3 targetPosition;
    Vector3 lookAtTarget;
    Vector3 offsetCharacter;
    Quaternion playerRot;

    float rotSpeed = 5;
    float speed = 5;

    Vector3 mirrorRotation;
    Vector3 middleMirrorWinPos;
    Vector3 rightMirrorWinPos;

    // Use this for initialization
    void Start () {

        otherObject = GameObject.Find(objectNameInOtherTime);

        middleLight = GameObject.Find("Point Light Middle");
        rightLight = GameObject.Find("Point Light Right");

        //basil = GameObject.Find("Basil");

        offsetCharacter = new Vector3(-20, 10, 0);

        mirrorRotation = new Vector3(0, -90, 0);

        characterSelect = 0;

        middleMirrorWinPos = new Vector3 (0, -159, 0);
        rightMirrorWinPos = new Vector3(0, -152, 0);
    }

    // Update is called once per frame
    void Update () {

        //determine past or present status on spacebar press
        if (Input.GetKeyDown("space")) {
            //update characterSelect value
            if (characterSelect == 0) {
                characterSelect = 1;
            }
            else if (characterSelect == 1) {
                characterSelect = 0;
            }
        }
        //set active status based on characterSelect
        if (characterSelect == 0) {
            harrietActive = true;
            basilActive = false;
        }
        else if (characterSelect == 1) {
            harrietActive = false;
            basilActive = true;
        }

        //interactions on mouse click
        if (Input.GetMouseButtonDown(0)) {

            RaycastHit hit;
            //turn screenpoint into ray, from the camera into mouse position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            //RaycastHit hitBasil;
            //Ray rayBasil = Camera.main.ScreenPointToRay(Input.mousePosition);


            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                if (hit.transform != null) {
                    //PrintName(hit.transform.gameObject);

                    //SetTargetPosition();

                    CapsuleCollider cc;
                    if (cc = hit.transform.GetComponent<CapsuleCollider>()) {
                        /*
                        if (gameObject.name == "Sprout")
                        {
                            Destroy(gameObject);
                            DestroyOtherObject(gameObject);
                        }
                        */
                    }

                    BoxCollider bc;
                    if (bc = hit.transform.GetComponent<BoxCollider>()) {
                        //print(bc.name);

                        //Basil: Remove the tapestries
                        if (bc.name == "Tapestry_Kah") {
                            //print(bc.gameObject);
                            Destroy(bc.gameObject);
                        } else if (bc.name == "Tapestry_Time") {
                            //print(bc.gameObject);
                            Destroy(bc.gameObject);
                        }



                        //Click mirrors to rotate them 90 degrees
                        if (harrietActive == true) {
                            //Harriet can't move the mirrors, so this will prompt dialogue
                            if (bc.name == "MirrorMiddle") {
                                //print("I cant move this!");
                            }
                            else if (bc.name == "MirrorRight") {
                                //print("I cant move this!");
                            }
                        } else if (basilActive == true) {
                            if (bc.name == "MirrorMiddle")
                            {
                                //print(bc.gameObject);
                                bc.transform.Rotate(mirrorRotation);

                                //test updated rotation
                                //print("Middle Mirror eulerAngle Y: " + bc.transform.eulerAngles.y);
                            }
                            else if (bc.name == "MirrorRight")
                            {
                                //print(bc.gameObject);
                                bc.transform.Rotate(mirrorRotation);
                            }
                        }

                    }
                }

            }
        }
	}

    private void SetTargetPosition() {
        /*
        RaycastHit hitBasil;
        Ray rayBasil = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(rayBasil, out hitBasil, 1000))
        {
            targetPosition = hitBasil.point - offsetCharacter;

            lookAtTarget = new Vector3(targetPosition.x - transform.position.x, transform.position.y, targetPosition.z - transform.position.z);
            playerRot = Quaternion.LookRotation(lookAtTarget);
        }
        */
    }

    private void Move(){
        /*
        basil.transform.rotation = Quaternion.Slerp(transform.rotation, playerRot, rotSpeed * Time.deltaTime);
        basil.transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        */
    }

    private void DestroyOtherObject(GameObject go) {
        if (objectNameInOtherTime != "") {
            Destroy(otherObject.gameObject);
            //otherObject.transform.position = new Vector3(41, -6, 28);
        }
    }

    private void PrintName(GameObject go) {
        print(go.name);
    }
}
