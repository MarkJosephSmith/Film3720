#pragma strict
// DAY 03 KITTY QUEST, find and knock over all the bottles
// For Displaying and Counting Lives
import System.IO;

public var Lives: int = 9;
public var kitty: Texture;
private var lifeCounter: GUIText;
public var numFound: int = 0;  //number of bottles found
public var numHit: int = 0;  //number of bottles knocked over

// For Displaying and Creating Objectives
private var indexObjective: int = 0;

function OnGUI () 
{
	if (kitty != null)
	{
		for (var i = 0; i < Lives; i++)
		{
			GUI.DrawTexture(Rect(10 * i + 50 * i, 10, 50, 50), kitty, ScaleMode.ScaleToFit, false, 0);
		}
 	}
 	
  	var centeredStyle = GUI.skin.GetStyle("Label");
    centeredStyle.alignment = TextAnchor.UpperCenter;	

 	switch (indexObjective)
 	{
 	case 0: // Find the bottles
		 GUI.Label(Rect(Screen.width/4, Screen.height * 0.8, Screen.width/2, 50),"The find all the portable puddles. " + numFound + "/6" + " hit " + numHit, centeredStyle);
 	break;
 	case 1: // Find Ball
 	 	 	 GUI.Label(Rect(Screen.width/4, Screen.height * 0.8, Screen.width/2, 50),"Find the ball in the living room.", centeredStyle);

 	break;
 	case 2: // ball to dining room
 	 	 	 GUI.Label(Rect(Screen.width/4, Screen.height * 0.8, Screen.width/2, 50),"Click to bat the ball into the dining room.", centeredStyle);
 	break;
 	case 3: // ball to living room
 	 	 GUI.Label(Rect(Screen.width/4, Screen.height * 0.8, Screen.width/2, 50),"Bat the ball under the stairs.", centeredStyle);
 	
 	break;
 	case 4: // find a vantage point

 	 	 GUI.Label(Rect(Screen.width/4, Screen.height * 0.8, Screen.width/2, 50),"Take a nap in the living room sunspot.", centeredStyle);
 	break;
 	default:
 		Debug.Log("DEFAULT SWITCH CASE");
 	}
 }

	function ObjectiveEntered(objective: String) {
		//Debug.Log("Objective Completed in " + timelapsed + " seconds!");
		 switch (indexObjective)
 		{
 		case 0: // EXPLORE THE HOUSE
			 if("EXPLORE".Equals(objective))
			 	indexObjective++;
 		break;
 		case 1: // Find Ball
			if("BALL".Equals(objective))
			 	indexObjective++;
 		break;
 		case 2: // ball to dining room
 			if("DINING".Equals(objective))
			 	indexObjective++;
 		break;
 		case 3: // ball to stairs
 	 		if("STAIRS".Equals(objective))
			 	indexObjective++;
 		break;
		case 4:
		 	 if("SUNSPOT".Equals(objective))
			 	indexObjective++;
		break;
 		default: // nap in the sunspot
 		Debug.Log("DEFAULT SWITCH CASE");
 		}
	}