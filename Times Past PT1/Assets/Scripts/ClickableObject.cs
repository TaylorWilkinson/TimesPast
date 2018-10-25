using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickableObject : MonoBehaviour {

    public string objectName;
    public string objectNameInOtherTime;

    GameObject otherObject, basil;

    Vector3 targetPosition;
    Vector3 lookAtTarget;
    Vector3 offsetCharacter;
    Quaternion playerRot;

    float rotSpeed = 5;
    float speed = 5;

	// Use this for initialization
	void Start () {

        otherObject = GameObject.Find(objectNameInOtherTime);

        basil = GameObject.Find("Basil");

        offsetCharacter = new Vector3 (-20, 10, 0);

    }

    // Update is called once per frame
    void Update () {
        if (Input.GetMouseButtonDown(0))
        {

            RaycastHit hit;
            //turn screenpoint into ray, from the camera into mouse position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            RaycastHit hitBasil;
            Ray rayBasil = Camera.main.ScreenPointToRay(Input.mousePosition);


            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                if (hit.transform != null) {
                    //PrintName(hit.transform.gameObject);

                    SetTargetPosition();

                    CapsuleCollider cc;
                    if (cc = hit.transform.GetComponent<CapsuleCollider>()) {
                        if (gameObject.name == "Sprout")
                        {
                            Destroy(gameObject);
                            DestroyOtherObject(gameObject);
                        }
                    }

                    BoxCollider bc;
                    if (bc = hit.transform.GetComponent<BoxCollider>()) {

                        //print(bc.name);

                        //Click mirrors to rotate them 45 degrees
                        /*if (bc.name == "MirrorLeft") {
                            //print("CLICK L MIRROR");
                            bc.transform.Rotate(new Vector3(0, 45, 0));
                        } else if (bc.name == "MirrorRight") {
                            //print("CLICK R MIRROR");
                            bc.transform.Rotate(new Vector3(0, 45, 0));
                        }*/
                    }
                }

            }
        }
	}

    private void SetTargetPosition() {
        RaycastHit hitBasil;
        Ray rayBasil = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(rayBasil, out hitBasil, 1000))
        {
            targetPosition = hitBasil.point - offsetCharacter;

            lookAtTarget = new Vector3(targetPosition.x - transform.position.x, transform.position.y, targetPosition.z - transform.position.z);
            playerRot = Quaternion.LookRotation(lookAtTarget);
        }
    }

    private void Move(){
        basil.transform.rotation = Quaternion.Slerp(transform.rotation, playerRot, rotSpeed * Time.deltaTime);
        basil.transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
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
