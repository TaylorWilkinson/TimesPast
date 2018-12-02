using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InterpersonalTalkLvl3: MonoBehaviour {
    //character switch control
    GameObject characterSwitchControl;
    bool harrietActive;
    bool basilActive;

    GameObject harriet, basil;
    MonoBehaviour hoverOnH, hoverOnB;

    // Use this for initialization
    void Start () {
        characterSwitchControl = GameObject.Find("CharacterSwitchControl");
        harrietActive = true;
        basilActive = false;

        harriet = GameObject.Find("Harriet");
        hoverOnH = harriet.GetComponent("HoverTextGUI") as MonoBehaviour;
        hoverOnH.enabled = false;

        basil = GameObject.Find("Basil");
        hoverOnB = basil.GetComponent("HoverTextGUI") as MonoBehaviour;
        hoverOnB.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
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

        if (harrietActive) {
            hoverOnH.enabled = false;
            hoverOnB.enabled = true;
        } else if (basilActive) {
            hoverOnH.enabled = true;
            hoverOnB.enabled = false;
        }

        //Click on Basil as Harriet
        if (harrietActive == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                //turn screenpoint into ray, from the camera into mouse position
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit, 100.0f))
                {
                    if (hit.transform != null)
                    {
                        //print("hit: " + hit.transform.gameObject + ", this: " + this.transform.gameObject);

                        CapsuleCollider cc;
                        if (cc = hit.transform.GetComponent<CapsuleCollider>())
                        {
                            if (hit.transform.gameObject.name == "Basil")
                            {
                                SceneManager.LoadScene(11);
                            }
                        }
                    }
                }
            }
        }
        //Click on Harriet as Basil
        else if (basilActive == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                //turn screenpoint into ray, from the camera into mouse position
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit, 100.0f))
                {
                    if (hit.transform != null)
                    {
                        //print("hit: " + hit.transform.gameObject + ", this: " + this.transform.gameObject);

                        CapsuleCollider cc;
                        if (cc = hit.transform.GetComponent<CapsuleCollider>())
                        {
                            if (hit.transform.gameObject.name == "Harriet")
                            {
                                SceneManager.LoadScene(12);
                            }
                        }
                    }
                }
            }
        }
    }
}
