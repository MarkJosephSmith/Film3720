#pragma strict
// DAY 02 KITTY QUEST
// For Displaying and Counting Lives
import System.IO;

public var lives: int = 9;
public var myFont: Font;
private var lifeCounter: GUIText;
private var roomVisits: int = 0;
private var floorCount: int = 0;
private var lifeText = ["N ","I ","N ","E ","L ","I ","V ","E ","S "];

// For Displaying and Creating Objectives
private var indexObjective: int = 0;

function OnGUI () 
{
  	var centeredStyle = GUI.skin.GetStyle("Label");
    centeredStyle.alignment = TextAnchor.MiddleLeft;	

 	switch (indexObjective)
 	{
 	case -1:
 		GUI.Label(Rect(50, Screen.height * 0.9, Screen.width, 50),"NO MORE KITTY QUESTING!", centeredStyle);
 	case 0: // EXPLORE THE HOUSE
		 GUI.Label(Rect(50, Screen.height * 0.9, Screen.width, 50),"Your humans have finished moving in. Explore the house.", centeredStyle);
 	break;
 	default:
 	 	GUI.Label(Rect(50, Screen.height * 0.9, Screen.width, 50),"Knock Everything On The Floor.", centeredStyle);
 	 	GUI.Label(Rect(50, Screen.height * 0.8, Screen.width, 50),"+" + floorCount, centeredStyle);
 	break;
 	}
 	
     var text: String = "";
     for (var i = 0; i < lives; i++)
		{
			text += lifeText[i];
			//GUI.DrawTexture(Rect(10 * i + 50 * i, 10, 50, 50), kitty, ScaleMode.ScaleToFit, false, 0);
		}
	GUI.skin.font = myFont; 
		
 	GUI.Label(Rect(50, 10, Screen.width/4, 50), text, centeredStyle);
 	
 }
 
 function LostLife()
 {
  	lives--;
  	if (lives <= 0)
  	 	indexObjective = -1;
 }

	function ObjectiveEntered(objective: String) {
		//Debug.Log("Objective Completed in " + timelapsed + " seconds!");
		if(objective.Contains("WET"))
 			LostLife();
		 switch (indexObjective)
 		{
 		case 0: // EXPLORE THE HOUSE
			 if(objective.Contains("ROOM"))
			 	roomVisits++;
			 if (roomVisits >= 6)
			 	indexObjective++;
 		break;
 		default: // nap in the sunspot
 			if(objective.Contains("FLOOR"))
 				floorCount++;
 		break;
 		}
	}