#pragma strict
// DAY 02 KITTY QUEST
// For Displaying and Counting Lives
import System.IO;

public var lives: int = 9;
public var myFont: Font;
private var lifeCounter: GUIText;
private var roomVisits: int = 0;
private var stairItems: int = 0;
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
		 GUI.Label(Rect(50, Screen.height * 0.9, Screen.width, 50),"The Red Living Room carpet is wet from steaming-get to the kitchen without touching it.", centeredStyle);
 	break;
 	case 1: // Find Ball
 		 GUI.Label(Rect(50, Screen.height * 0.9, Screen.width, 50),"There is an expensive laptop in the house. Knock it onto the ground.", centeredStyle);
 	break;
 	case 2: // ball to kitchen
 	 	 GUI.Label(Rect(50, Screen.height * 0.9, Screen.width, 50),"Get a drink from a sink.", centeredStyle);
 	break;
 	case 3: // ball to entryway
 	 	 GUI.Label(Rect(50, Screen.height * 0.9, Screen.width, 50),"Get back to your sunny armchair without touching the Red Carpet.", centeredStyle);
 	
 	break;
// 	case 4: // find a vantage point
// 	 	 GUI.Label(Rect(Screen.width/4, Screen.height * 0.8, Screen.width/2, 50),"Find a sunspot in the Living Room to nap in.", centeredStyle);
// 	break;
 	default:
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
			 if(objective.Equals("KITCHEN"))
			 	indexObjective++;
 		break;
 		case 1: // Find way downstairs
			if("FLOOR".Equals(objective))
			 	indexObjective++; 		
			break;
 		case 2: // ball to kitchen
 			if("SINK".Equals(objective))
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