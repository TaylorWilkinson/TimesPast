//code referenced from:
//http://unity3dmgames.blogspot.com/2015/04/unity3d-tutorial-1824-gui-text-appear.html

/* GUI STYLE */

var titleText = "PUT TEXT HERE";
private var descText = "DESC TEXT HERE";
var actionText = "ACTION TEXT HERE";

//var activeCharacter = "";

var harrietActionText = "Harriet's Action Text";
var basilActionText = "Basil's Action Text";
var basilAlternateText = "Basil's Text After A Prompt";

private var currentToolTipText = "";
private var secondToolTipText = "";
private var thirdToolTipText = "";

private var harrietToolTipText = "";
private var basilToolTipText = "";

private var guiStyleFore : GUIStyle;
private var guiStyleBack : GUIStyle;

private var guiStyleSecondFore : GUIStyle;
private var guiStyleSecondBack : GUIStyle;

private var guiStyleThirdFore : GUIStyle;
private var guiStyleThirdBack : GUIStyle;


private var guiStyleHarrietFore : GUIStyle;
private var guiStyleHarrietBack : GUIStyle;

private var guiStyleBasilFore : GUIStyle;
private var guiStyleBasilBack : GUIStyle;

//var customGUIStyle : GUIStyle;


var characterSwitchControl;
var harrietActive = false;
var basilActive = false;

var interactionChecker;

 function Start() {
     //title text info
     guiStyleFore = new GUIStyle();
     guiStyleFore.fontSize = 15;
     guiStyleFore.normal.textColor = Color.white;
     guiStyleFore.alignment = TextAnchor.UpperCenter ;
     guiStyleFore.wordWrap = true;

     guiStyleBack = new GUIStyle();
     guiStyleBack.fontSize = 15;
     guiStyleBack.normal.textColor = Color.black;
     guiStyleBack.alignment = TextAnchor.UpperCenter ;
     guiStyleBack.wordWrap = true;

     //desc text info
     guiStyleSecondFore = new GUIStyle();
     guiStyleSecondFore.fontSize = 13;
     guiStyleSecondFore.normal.textColor = Color.white;
     guiStyleSecondFore.alignment = TextAnchor.UpperCenter ;
     guiStyleSecondFore.wordWrap = true;

     guiStyleSecondBack = new GUIStyle();
     guiStyleSecondBack.fontSize = 13;
     guiStyleSecondBack.normal.textColor = Color.black;
     guiStyleSecondBack.alignment = TextAnchor.UpperCenter ;
     guiStyleSecondBack.wordWrap = true;

     //action text info
     guiStyleThirdFore = new GUIStyle();
     guiStyleThirdFore.fontSize = 13;
     guiStyleThirdFore.normal.textColor = Color.white;
     guiStyleThirdFore.alignment = TextAnchor.UpperCenter ;
     guiStyleThirdFore.wordWrap = true;

     guiStyleThirdBack = new GUIStyle();
     guiStyleThirdBack.fontSize = 13;
     guiStyleThirdBack.normal.textColor = Color.black;
     guiStyleThirdBack.alignment = TextAnchor.UpperCenter ;
     guiStyleThirdBack.wordWrap = true;

    //harriet text info
     guiStyleHarrietFore = new GUIStyle();
     guiStyleHarrietFore.fontSize = 13;
     guiStyleHarrietFore.normal.textColor = Color.white;
     guiStyleHarrietFore.alignment = TextAnchor.UpperCenter ;
     guiStyleHarrietFore.wordWrap = true;

     guiStyleHarrietBack = new GUIStyle();
     guiStyleHarrietBack.fontSize = 13;
     guiStyleHarrietBack.normal.textColor = Color.black;
     guiStyleHarrietBack.alignment = TextAnchor.UpperCenter ;
     guiStyleHarrietBack.wordWrap = true;

    //basil text info
     guiStyleBasilFore = new GUIStyle();
     guiStyleBasilFore.fontSize = 13;
     guiStyleBasilFore.normal.textColor = Color.white;
     guiStyleBasilFore.alignment = TextAnchor.UpperCenter ;
     guiStyleBasilFore.wordWrap = true;

     guiStyleBasilBack = new GUIStyle();
     guiStyleBasilBack.fontSize = 13;
     guiStyleBasilBack.normal.textColor = Color.black;
     guiStyleBasilBack.alignment = TextAnchor.UpperCenter ;
     guiStyleBasilBack.wordWrap = true;
 }

 function Update() {
    //character check
    var characterSwitchControl : GameObject = GameObject.Find("CharacterSwitchControl");
    //print(characterSwitchControl.GetComponent("SwitchCharacter").characterSelect);

    if ((characterSwitchControl.GetComponent("SwitchCharacter").characterSelect) == 0){
        //print("harriet active");
        actionText = harrietActionText;
    } else if ((characterSwitchControl.GetComponent("SwitchCharacter").characterSelect) == 1) {
        //print("basil active");
        //actionText = basilActionText;

        //check if Basil's action text must change
        var interactionChecker : GameObject = GameObject.Find("Win State Controller");

        if (interactionChecker.GetComponent("InteractionTrigger").basilDialogueChange == false) {
            //print("basil action text");
            actionText = basilActionText;
        } else {
            //print("basil alt text");
            actionText = basilAlternateText;
        }
    }
 }

 function OnMouseEnter ()
 {
     currentToolTipText = titleText;
     secondToolTipText = descText;
     thirdToolTipText = actionText;
 }

 function OnMouseExit () {
     currentToolTipText = "";
     secondToolTipText = "";
     thirdToolTipText = "";
 }

 function OnGUI()
 {
     if (currentToolTipText != "") {
         var x = Event.current.mousePosition.x;
         var y = Event.current.mousePosition.y;

         //title text
         GUI.Label (Rect (x-148,y+40,300,60), currentToolTipText, guiStyleBack);
         GUI.Label (Rect (x-150,y+40,300,60), currentToolTipText, guiStyleFore);

         //desc text
         //GUI.Label (Rect (x-148,y+60,300,60), secondToolTipText, guiStyleSecondBack);
         //GUI.Label (Rect (x-150,y+60,300,60), secondToolTipText, guiStyleSecondFore);

         //action text
         //GUI.Label (Rect (x-148,y+90,300,60), thirdToolTipText, guiStyleThirdBack);
         //GUI.Label (Rect (x-150,y+90,300,60), thirdToolTipText, guiStyleThirdFore);
         GUI.Label (Rect (x-148,y+60,300,60), thirdToolTipText, guiStyleThirdBack);
         GUI.Label (Rect (x-150,y+60,300,60), thirdToolTipText, guiStyleThirdFore);


        //GUI.Label (Rect (x-148,y+60,300,60), harrietToolTipText, guiStyleHarrietBack);
        //GUI.Label (Rect (x-150,y+60,300,60), harrietToolTipText, guiStyleHarrietFore);

        //GUI.Label (Rect (x-148,y+60,300,60), basilToolTipText, guiStyleBasilBack);
        //GUI.Label (Rect (x-150,y+60,300,60), basilToolTipText, guiStyleBasilFore);

     }
 }
