using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionTrigger2 : MonoBehaviour
{

    GameObject mirror1, mirror2, mirror3, tapestry;
    public bool basilDialogueChange;

    // Use this for initialization
    void Start()
    {
        mirror1 = GameObject.Find("BackMirrorLight");
        mirror2 = GameObject.Find("MiddleMirrorLight");
        mirror3 = GameObject.Find("FarMirrorLight");
        tapestry = GameObject.Find("Tapestry Kah");
    }

    // Update is called once per frame
    void Update()
    {

        //Change Tapestry Dialogue for Basil
        if (tapestry.GetComponent<DialogueOnClick>().harrietHasClicked == true)
        {
            basilDialogueChange = true;

            if (tapestry.GetComponent<Clickable>() == null) {
                tapestry.AddComponent<Clickable>();
                tapestry.AddComponent<DestroyOnClick>();
                tapestry.GetComponent<DestroyOnClick>().requiredCharacter = GameObject.Find("Basil");
            }
        }
    }
}
