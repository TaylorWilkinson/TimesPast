using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogClick : MonoBehaviour {

    //Clickable Dialogue Objects
    GameObject canvas1, nameText, dialogueText;
    //Dialogue TextMesh Displays
    public TextMeshProUGUI nameDisplay;
    public TextMeshProUGUI dialogDisplay;

    int characterSelect;
    bool harrietActive;
    bool basilActive;

    Vector3 mirrorRotation;

    // Use this for initialization
    void Start () {
        //Interactive Dialog
        canvas1 = GameObject.Find("Canvas1");
        //canvas1.SetActive(false);
        canvas1.GetComponent<Canvas>().enabled = false;

        characterSelect = 0;
        harrietActive = true;
        basilActive = false;
    }

    // Update is called once per frame
    void Update()
    {

        //determine past or present status on spacebar press
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

        //update active status based on characterSelect
        if (characterSelect == 0)
        {
            harrietActive = true;
            basilActive = false;
        }
        else if (characterSelect == 1)
        {
            harrietActive = false;
            basilActive = true;
        }

        //do the following if harriet is active
        if ((harrietActive == true) && (basilActive == false))
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit, 100.0f))
                {
                    if (hit.transform != null)
                    {
                        BoxCollider bc;
                        if (bc = hit.transform.GetComponent<BoxCollider>())
                        {
                            //mirrorRotation = new Vector3(0, 0, 0);
                            //print("Harriet clicking" + bc.name);
                        }//end box collider hit check
                    } //end hit.trasform check
                }//end physics.raycast check
            }
        }//end harriet check

    }//end Update
}
