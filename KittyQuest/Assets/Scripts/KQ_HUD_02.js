#pragma strict
// DAY 02 KITTY QUEST
// For Displaying and Counting Lives
import System.IO;

public var Lives: int = 9;
public var myFont: Font;
private var lifeCounter: GUIText;
private var roomVisits: int = 0;
private var stairItems: int = 0;
private var lifeText = ["N","I","N","E ","L","I","V","E","S"];

// For Displaying and Creating Objectives
private var indexObjective: int = 0;

function OnGUI () 
{
  	var centeredStyle = GUI.skin.GetStyle("Label");
    centeredStyle.alignment = TextAnchor.UpperCenter;	

 	switch (indexObjective)
 	{
 	case 0: // EXPLORE THE HOUSE
		 GUI.Label(Rect(Screen.width/4, Screen.height * 0.8, Screen.width/2, 50),"The 2nd Floor is accessible, go explore Upstairs.", centeredStyle);
 	break;
 	case 1: // Find Ball
 		 GUI.Label(Rect(Screen.width/4, Screen.height * 0.8, Screen.width/2, 50),"Knock boxes down the Stairs.", centeredStyle);
 	break;
 	case 2: // ball to kitchen
 	 	 GUI.Label(Rect(Screen.width/4, Screen.height * 0.8, Screen.width/2, 50),"Get back to the 1st Floor WITHOUT using the Stairs.", centeredStyle);
 	break;
 	case 3: // ball to entryway
 	 	 GUI.Label(Rect(Screen.width/4, Screen.height * 0.8, Screen.width/2, 50),"Take an inconspicuous nap in the Living Room Sunspot.", centeredStyle);
 	
 	break;
// 	case 4: // find a vantage point
// 	 	 GUI.Label(Rect(Screen.width/4, Screen.height * 0.8, Screen.width/2, 50),"Find a sunspot in the Living Room to nap in.", centeredStyle);
// 	break;
 	default:
 	break;
 	}
 	
     var text: String = "";
     for (var i = 0; i < Lives; i++)
		{
			text += lifeText[i];
			//GUI.DrawTexture(Rect(10 * i + 50 * i, 10, 50, 50), kitty, ScaleMode.ScaleToFit, false, 0);
		}
	if (myFont != null)
		GUI.skin.font = myFont; 
 	GUI.Label(Rect(10, 10, 200, 50), text, centeredStyle);
 	
 }

	function ObjectiveEntered(objective: String) {
		//Debug.Log("Objective Completed in " + timelapsed + " seconds!");
		 switch (indexObjective)
 		{
 		case 0: // EXPLORE THE HOUSE
			 if(objective.Contains("ROOM2"))
			 	roomVisits++;
			 if (roomVisits >= 3)
			 	indexObjective++;
 		break;
 		case 1: // Find way downstairs
			if("STAIRWAY".Equals(objective))
			 	stairItems++;
			 if (stairItems >= 3)
			 	indexObjective++; 		break;
 		case 2: // ball to kitchen
 			if("BALCONY".Equals(objective))
			 	indexObjective++;
 		break;
 		case 3: // ball to stairs
 	 		if("SUNSPOT".Equals(objective))
			 	indexObjective++;
 		break;
//		case 4:
//		 	 if("SUNSPOT".Equals(objective))
//			 	indexObjective++;
//		break;
 		default: // nap in the sunspot
 		break;
 		}
	}