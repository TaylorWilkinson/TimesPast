//code referenced from:
//http://unity3dmgames.blogspot.com/2015/04/unity3d-tutorial-1824-gui-text-appear.html

/* GUI STYLE */

var titleText = "PUT TEXT HERE";
var actionText = "ACTION TEXT HERE";

private var currentToolTipText = "";
private var secondToolTipText = "";

private var guiStyleFore : GUIStyle;
private var guiStyleBack : GUIStyle;

private var guiStyleSecondFore : GUIStyle;
private var guiStyleSecondBack : GUIStyle;

//var customGUIStyle : GUIStyle;

 function Start()
 {
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


     guiStyleSecondFore = new GUIStyle();
     guiStyleSecondFore.fontSize = 10;
     guiStyleSecondFore.normal.textColor = Color.white;
     guiStyleSecondFore.alignment = TextAnchor.UpperCenter ;
     guiStyleSecondFore.wordWrap = true;

     guiStyleSecondBack = new GUIStyle();
     guiStyleSecondBack.fontSize = 10;
     guiStyleSecondBack.normal.textColor = Color.black;
     guiStyleSecondBack.alignment = TextAnchor.UpperCenter ;
     guiStyleSecondBack.wordWrap = true;
 }

 function OnMouseEnter ()
 {
     currentToolTipText = titleText;
     secondToolTipText = actionText;
 }

 function OnMouseExit () {
     currentToolTipText = "";
     secondToolTipText = "";
 }

 function OnGUI()
 {
     if (currentToolTipText != "")
     {
         var x = Event.current.mousePosition.x;
         var y = Event.current.mousePosition.y;

         //title text
         GUI.Label (Rect (x-148,y+40,300,60), currentToolTipText, guiStyleBack);
         GUI.Label (Rect (x-150,y+40,300,60), currentToolTipText, guiStyleFore);

         //action text
         GUI.Label (Rect (x-148,y+60,300,60), secondToolTipText, guiStyleSecondBack);
         GUI.Label (Rect (x-150,y+60,300,60), secondToolTipText, guiStyleSecondFore);
     }
 }
