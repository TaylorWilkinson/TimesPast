using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Fungus;


public class InterpersonalTalkLvl2 : MonoBehaviour {
    //character switch control
    GameObject characterSwitchControl;
    bool harrietActive;
    bool basilActive;
    GameObject harriet, basil;
    MonoBehaviour hoverOnH, hoverOnB;
    GameObject mainCamera, basilCamera, harrietCamera;
    public GameObject basilDialogueObject, harrietDialogueObject;
    //public GameObject basilFlow

    public Flowchart flowchartBasil;
    public Flowchart flowchartHariet;

    // Use this for initialization
    void Start()
    {
        characterSwitchControl = GameObject.Find("CharacterSwitchControl");
        harrietActive = true;
        basilActive = false;
        harriet = GameObject.Find("Harriet");
        //hoverOnH = harriet.GetComponent("HoverTextGUI") as MonoBehaviour;
        hoverOnH = harriet.GetComponent("HoverTextUI") as MonoBehaviour;
        hoverOnH.enabled = true;
        basil = GameObject.Find("Basil");
        //hoverOnB = basil.GetComponent("HoverTextGUI") as MonoBehaviour;
        hoverOnB = basil.GetComponent("HoverTextUI") as MonoBehaviour;
        hoverOnB.enabled = true;

        mainCamera = GameObject.Find("CameraTarget");
        basilCamera = GameObject.Find("BasilCamera");
        harrietCamera = GameObject.Find("HarrietCamera");
        //        basilDialogueObject = GameObject.Find("BasilTutorialDialogue");
        //        basilDialogueObject.SetActive(false);
        //
        //        harrietDialogueObject = GameObject.Find("HarrietTutorialDialogue");
        //        harrietDialogueObject.SetActive(false);
        mainCamera.GetComponent<Camera>().enabled = true;
        basilCamera.GetComponent<Camera>().enabled = false;
        harrietCamera.GetComponent<Camera>().enabled = false;
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
        if (harrietActive)
        {
            hoverOnH.enabled = false;
            hoverOnB.enabled = true;
        }
        else if (basilActive)
        {
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
                                //SceneManager.LoadScene(7);
                                //The Main Camera and Harriet's dialogue are both disabled
                                mainCamera.GetComponent<Camera>().enabled = false;
                                //harrietCamera.GetComponent<Camera>().enabled = false;
                                //harrietDialogueObject.SetActive(false);
                                //Enable the Basil's dialogue
                                basilDialogueObject.SetActive(true);
                                flowchartBasil.gameObject.SetActive(true);
                                //flowchartBasil.ExecuteBlock("Options");
                                flowchartBasil.SendFungusMessage("Basil");
                                basilCamera.GetComponent<Camera>().enabled = true;
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
                                //SceneManager.LoadScene(8);
                                //The Main Camera and Basil's dialogue are both disabled
                                mainCamera.GetComponent<Camera>().enabled = false;
                                //basilCamera.GetComponent<Camera>().enabled = false;
                                //basilDialogueObject.SetActive(false);
                                //Enable the basil's dialogue camera
                                harrietDialogueObject.SetActive(true);
                                //flowchartHariet.gameObject.SetActive(true);
                                flowchartHariet.SendFungusMessage("Harriet");
                                harrietCamera.GetComponent<Camera>().enabled = true;
                            }
                        }
                    }
                }
            }
        }
    }
    public void ResetMainCamera()
    {
        mainCamera.GetComponent<Camera>().enabled = true;
        basilCamera.GetComponent<Camera>().enabled = false;
        harrietCamera.GetComponent<Camera>().enabled = false;
        //flowchartBasil.StopAllBlocks();
        //flowchartHariet.StopAllBlocks();
        basilDialogueObject.SetActive(false);
        harrietDialogueObject.SetActive(false);
    }





    /*
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

        if (harrietActive)
        {
            hoverOnH.enabled = false;
            hoverOnB.enabled = true;
        }
        else if (basilActive)
        {
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
                                SceneManager.LoadScene(9);
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
                                SceneManager.LoadScene(10);
                            }
                        }
                    }
                }
            }
        }
    }
    */
}
