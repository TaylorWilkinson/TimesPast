using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InterpersonalTalkLvl2 : MonoBehaviour {
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
        hoverOnH.enabled = true;

        basil = GameObject.Find("Basil");
        hoverOnB = basil.GetComponent("HoverTextGUI") as MonoBehaviour;
        hoverOnB.enabled = true;
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

        //click on character
        if (harrietActive == true) {
            hoverOnH.enabled = false;
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                //turn screenpoint into ray, from the camera into mouse position
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit, 100.0f))
                {
                    if (hit.transform != null)
                    {
                        print("hit: " + hit.transform.gameObject + ", this: " + this.transform.gameObject);

                        CapsuleCollider cc;
                        if (cc = hit.transform.GetComponent<CapsuleCollider>())
                        {
                            if (hit.transform.gameObject == this.transform.gameObject)
                            {
                                if (harrietActive == true)
                                {
                                    //load dialogue with Basil
                                    SceneManager.LoadScene(7, LoadSceneMode.Additive);
                                }
                            }
                        }
                    }
                }
            }
        } else if (basilActive == true)
        {
            hoverOnB.enabled = false;
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                //turn screenpoint into ray, from the camera into mouse position
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit, 100.0f))
                {
                    if (hit.transform != null)
                    {
                        print("hit: " + hit.transform.gameObject + ", this: " + this.transform.gameObject);

                        CapsuleCollider cc;
                        if (cc = hit.transform.GetComponent<CapsuleCollider>())
                        {
                            if (hit.transform.gameObject == this.transform.gameObject)
                            {
                                if (harrietActive == true)
                                {
                                    //load dialogue with Harriet
                                    SceneManager.LoadScene(8);
                                }
                            }
                        }
                    }
                }
            }
        }        
    }
}
