using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushDownOnClick : MonoBehaviour {
    //character switch control
    GameObject characterSwitchControl;
    bool harrietActive;
    bool basilActive;

    void Start() {
        characterSwitchControl = GameObject.Find("CharacterSwitchControl");
        harrietActive = true;
        basilActive = false;
    }

    void Update() {
        //determine active character
        if ((characterSwitchControl.GetComponent<SwitchCharacter>().characterSelect) == 0) {
            harrietActive = true;
            basilActive = false;
        } else if ((characterSwitchControl.GetComponent<SwitchCharacter>().characterSelect) == 1) {
            basilActive = true;
            harrietActive = false;
        }

        PressObjectDown();

    }

    void PressObjectDown() {
        if (Input.GetMouseButtonDown(0)) {
            RaycastHit hit;
            //turn screenpoint into ray, from the camera into mouse position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out hit, 100.0f))
            {
                if (hit.transform != null)
                {
                    //print("hit: " + hit.transform.gameObject + ", this: " + this.transform.gameObject);
                    /*
                    CapsuleCollider cc;
                    if (cc = hit.transform.GetComponent<CapsuleCollider>())
                    {
                        if (hit.transform.gameObject == this.transform.gameObject)
                        {
                            if (basilActive == true)
                            {
                                this.transform.position = new Vector3(0, -7f, 0);
                            }
                        }
                    }
                    */
                    BoxCollider bc;
                    if (bc = hit.transform.GetComponent<BoxCollider>())
                    {
                        if (hit.transform.gameObject == this.transform.gameObject)
                        {
                            if (basilActive == true)
                            {
                                this.transform.position = new Vector3(0, -7f, 0);
                                //play sound
                                this.GetComponent<AudioScript>().PlaySound();
                            }
                        }
                    }
                }
            }
        } else if (Input.GetMouseButtonUp(0)) {
            this.transform.position = new Vector3(0, 0, 0);
        }
    }

}
