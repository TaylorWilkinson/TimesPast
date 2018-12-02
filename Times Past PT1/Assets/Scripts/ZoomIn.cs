using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomIn : MonoBehaviour
{
    GameObject mainCamera, zoomedCamera;

    private GameObject englishEngraving;
    MonoBehaviour hoverJS;

    // Use this for initialization
    void Start()
    {
        mainCamera = GameObject.Find("CameraTarget");

        zoomedCamera = GameObject.Find("InscriptionCamera");

        mainCamera.GetComponent<Camera>().enabled = true;
        zoomedCamera.GetComponent<Camera>().enabled = false;

        englishEngraving = GameObject.Find("garden-inscription-english");
        hoverJS = englishEngraving.GetComponent("HoverTextGUI") as MonoBehaviour;
        hoverJS.enabled = true;
    }

    // Update is called once per frame
    void Update() {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            //turn screenpoint into ray, from the camera into mouse position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                if (hit.transform != null) {
                    //print("hit: " + hit.transform.gameObject + ", this: " + this.transform.gameObject);

                    //mirror room inscription
                    if ((hit.transform.gameObject.name == "inscription-english") && (this.gameObject.name == "inscription-english")) {
                        if (mainCamera.GetComponent<Camera>().enabled)
                        {
                            //Enable the second Camera
                            zoomedCamera.GetComponent<Camera>().enabled = true;

                            //The Main first Camera is disabled
                            mainCamera.GetComponent<Camera>().enabled = false;

                            //disable Hover text
                            hoverJS.enabled = false;
                        }
                        //Otherwise, if the Main Camera is not enabled, switch back to the Main Camera on a key press
                        else if (!mainCamera.GetComponent<Camera>().enabled)
                        {
                            //Disable the second camera
                            zoomedCamera.GetComponent<Camera>().enabled = false;

                            //Enable the Main Camera
                            mainCamera.GetComponent<Camera>().enabled = true;

                            //Re-enable Hover text
                            hoverJS.enabled = true;
                        }
                    }
                    //garden room inscription
                    else if ( (hit.transform.gameObject == englishEngraving) && (this.gameObject.name == "Bushes")) {
                        if (mainCamera.GetComponent<Camera>().enabled)
                        {
                            //Enable the second Camera
                            zoomedCamera.GetComponent<Camera>().enabled = true;

                            //The Main first Camera is disabled
                            mainCamera.GetComponent<Camera>().enabled = false;

                            //disable Hover text
                            hoverJS.enabled = false;
                        }
                        //Otherwise, if the Main Camera is not enabled, switch back to the Main Camera on a key press
                        else if (!mainCamera.GetComponent<Camera>().enabled)
                        {
                            //Disable the second camera
                            zoomedCamera.GetComponent<Camera>().enabled = false;

                            //Enable the Main Camera
                            mainCamera.GetComponent<Camera>().enabled = true;

                            //Re-enable Hover text
                            hoverJS.enabled = true;
                        }
                    }
                }
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            mainCamera.GetComponent<Camera>().enabled = true;
            zoomedCamera.GetComponent<Camera>().enabled = false;
        } //end MouseButtonDown/Up check
    }
}
