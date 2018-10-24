using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class EnvironmentSwitch : MonoBehaviour
{
    /*
    GameObject sprout, tree, rocks;
    int pastObject;
    */
    GameObject[] pastObjectArray;
    GameObject[] presentObjectArray;

    int objectStatus;

    // Use this for initialization
    void Start() {
        pastObjectArray = GameObject.FindGameObjectsWithTag("Past");
        presentObjectArray = GameObject.FindGameObjectsWithTag("Present");

        objectStatus = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space")) {
            //update the status of whether pastObject is active
            if (objectStatus == 0)
            {
                objectStatus = 1;
            }
            else if (objectStatus == 1)
            {
                objectStatus = 0;
            }
        }

        if (objectStatus == 0) {
            //past objects are inactive
            foreach (GameObject pastObj in pastObjectArray) {
                if (pastObj != null) {
                    pastObj.SetActive(false);
                }
            }

            //present objects are active
            foreach (GameObject presentObj in presentObjectArray) {
                if (presentObj != null) {
                    presentObj.SetActive(true);
                }
            }
        }
        else if (objectStatus == 1) {
            //past objects are active
            foreach (GameObject pastObj in pastObjectArray) {
                if (pastObj != null) {
                    pastObj.SetActive(true);
                }
            }

            //present objects are inactive
            foreach (GameObject presentObj in presentObjectArray) {
                if (presentObj != null) {
                    presentObj.SetActive(false);
                }
            }
        }
    }
}