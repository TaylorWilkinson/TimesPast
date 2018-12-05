using UnityEngine;
using System.Collections;

public class HoverTextUI : MonoBehaviour {

    //code referenced from:
    //http://unity3dmgames.blogspot.com/2015/04/unity3d-tutorial-1824-gui-text-appear.html

    /* GUI STYLE */

    public string titleText = "PUT TEXT HERE";
    private string descText = "DESC TEXT HERE";
    public string actionText = "ACTION TEXT HERE";

    //FIXME_VAR_TYPE activeCharacter= "";

    public string harrietActionText = "Harriet's Action Text";
    public string harrietAlternateText = "";

    public string basilActionText = "Basil's Action Text";
    public string basilAlternateText = "Basil's Text After A Prompt";

    private string currentToolTipText = "";
    private string secondToolTipText = "";
    private string thirdToolTipText = "";

    private string harrietToolTipText = "";
    private string basilToolTipText = "";

    private GUIStyle guiStyleFore;
    private GUIStyle guiStyleBack;

    private GUIStyle guiStyleSecondFore;
    private GUIStyle guiStyleSecondBack;

    private GUIStyle guiStyleThirdFore;
    private GUIStyle guiStyleThirdBack;


    private GUIStyle guiStyleHarrietFore;
    private GUIStyle guiStyleHarrietBack;

    private GUIStyle guiStyleBasilFore;
    private GUIStyle guiStyleBasilBack;

    public Font hoverFont;

    //GUIStyle customGUIStyle;


    GameObject characterSwitchControl;
    public bool harrietActive = false;
    public bool basilActive = false;

    GameObject interactionCheckerH;
    GameObject interactionCheckerB;

    void Start()
    {
        //title text info
        guiStyleFore = new GUIStyle();
        guiStyleFore.font = hoverFont;
        guiStyleFore.fontSize = 25;
        guiStyleFore.normal.textColor = Color.white;
        guiStyleFore.alignment = TextAnchor.UpperCenter;
        guiStyleFore.wordWrap = true;

        guiStyleBack = new GUIStyle();
        guiStyleBack.font = hoverFont;
        guiStyleBack.fontSize = 25;
        guiStyleBack.normal.textColor = Color.black;
        guiStyleBack.alignment = TextAnchor.UpperCenter;
        guiStyleBack.wordWrap = true;

        //desc text info
        guiStyleSecondFore = new GUIStyle();
        guiStyleSecondFore.font = hoverFont;
        guiStyleSecondFore.fontSize = 20;
        guiStyleSecondFore.normal.textColor = Color.white;
        guiStyleSecondFore.alignment = TextAnchor.UpperCenter;
        guiStyleSecondFore.wordWrap = true;

        guiStyleSecondBack = new GUIStyle();
        guiStyleSecondBack.font = hoverFont;
        guiStyleSecondBack.fontSize = 20;
        guiStyleSecondBack.normal.textColor = Color.black;
        guiStyleSecondBack.alignment = TextAnchor.UpperCenter;
        guiStyleSecondBack.wordWrap = true;

        //action text info
        guiStyleThirdFore = new GUIStyle();
        guiStyleThirdFore.font = hoverFont;
        guiStyleThirdFore.fontSize = 20;
        guiStyleThirdFore.normal.textColor = Color.white;
        guiStyleThirdFore.alignment = TextAnchor.UpperCenter;
        guiStyleThirdFore.wordWrap = true;

        guiStyleThirdBack = new GUIStyle();
        guiStyleThirdBack.font = hoverFont;
        guiStyleThirdBack.fontSize = 20;
        guiStyleThirdBack.normal.textColor = Color.black;
        guiStyleThirdBack.alignment = TextAnchor.UpperCenter;
        guiStyleThirdBack.wordWrap = true;

        //harriet text info
        guiStyleHarrietFore = new GUIStyle();
        guiStyleHarrietFore.font = hoverFont;
        guiStyleHarrietFore.fontSize = 20;
        guiStyleHarrietFore.normal.textColor = Color.white;
        guiStyleHarrietFore.alignment = TextAnchor.UpperCenter;
        guiStyleHarrietFore.wordWrap = true;

        guiStyleHarrietBack = new GUIStyle();
        guiStyleHarrietBack.font = hoverFont;
        guiStyleHarrietBack.fontSize = 20;
        guiStyleHarrietBack.normal.textColor = Color.black;
        guiStyleHarrietBack.alignment = TextAnchor.UpperCenter;
        guiStyleHarrietBack.wordWrap = true;

        //basil text info
        guiStyleBasilFore = new GUIStyle();
        guiStyleBasilFore.font = hoverFont;
        guiStyleBasilFore.fontSize = 20;
        guiStyleBasilFore.normal.textColor = Color.white;
        guiStyleBasilFore.alignment = TextAnchor.UpperCenter;
        guiStyleBasilFore.wordWrap = true;

        guiStyleBasilBack = new GUIStyle();
        guiStyleBasilBack.font = hoverFont;
        guiStyleBasilBack.fontSize = 20;
        guiStyleBasilBack.normal.textColor = Color.black;
        guiStyleBasilBack.alignment = TextAnchor.UpperCenter;
        guiStyleBasilBack.wordWrap = true;
    }

    void Update() {
        //character check
        characterSwitchControl = GameObject.Find("CharacterSwitchControl");
        //print(characterSwitchControl.GetComponent<"SwitchCharacter">().characterSelect);

        if ((characterSwitchControl.GetComponent<SwitchCharacter>().characterSelect) == 0)
        {
            //print("harriet active");
            //actionText = harrietActionText;

            //check if Harriet's action text must change
            interactionCheckerH = GameObject.Find("Win State Controller");

            if (interactionCheckerH.GetComponent<InteractionTrigger>().harrietDialogueChange == false)
            {
                actionText = harrietActionText;
            }
            else
            {
                actionText = harrietAlternateText;
            }


        }
        else if ((characterSwitchControl.GetComponent<SwitchCharacter>().characterSelect) == 1)
        {
            //print("basil active");
            //actionText = basilActionText;

            //check if Basil's action text must change
            interactionCheckerB = GameObject.Find("Win State Controller");

            if (interactionCheckerB.GetComponent<InteractionTrigger>().basilDialogueChange == false)
            {
                //print("basil action text");
                actionText = basilActionText;
            }
            else
            {
                //print("basil alt text");
                actionText = basilAlternateText;
            }
        }
    }

    void OnMouseEnter()
    {
        currentToolTipText = titleText;
        secondToolTipText = descText;
        thirdToolTipText = actionText;
    }

    void OnMouseExit()
    {
        currentToolTipText = "";
        secondToolTipText = "";
        thirdToolTipText = "";
    }

    void OnGUI()
    {
        if (currentToolTipText != "")
        {
            float x = Event.current.mousePosition.x;
            float y = Event.current.mousePosition.y;

            //title text
            GUI.Label(new Rect(x - 148, y + 30, 300, 60), currentToolTipText, guiStyleBack);
            GUI.Label(new Rect(x - 150, y + 30, 300, 60), currentToolTipText, guiStyleFore);

            //desc text
            //GUI.Label ( new Rect(x-148,y+60,300,60), secondToolTipText, guiStyleSecondBack);
            //GUI.Label ( new Rect(x-150,y+60,300,60), secondToolTipText, guiStyleSecondFore);

            //action text
            //GUI.Label ( new Rect(x-148,y+90,300,60), thirdToolTipText, guiStyleThirdBack);
            //GUI.Label ( new Rect(x-150,y+90,300,60), thirdToolTipText, guiStyleThirdFore);
            GUI.Label(new Rect(x - 148, y + 60, 300, 60), thirdToolTipText, guiStyleThirdBack);
            GUI.Label(new Rect(x - 150, y + 60, 300, 60), thirdToolTipText, guiStyleThirdFore);


            //GUI.Label ( new Rect(x-148,y+60,300,60), harrietToolTipText, guiStyleHarrietBack);
            //GUI.Label ( new Rect(x-150,y+60,300,60), harrietToolTipText, guiStyleHarrietFore);

            //GUI.Label ( new Rect(x-148,y+60,300,60), basilToolTipText, guiStyleBasilBack);
            //GUI.Label ( new Rect(x-150,y+60,300,60), basilToolTipText, guiStyleBasilFore);

        }
    }
}
