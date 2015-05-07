#pragma strict
// DAY 03 KITTY QUEST, find and knock over all the bottles
// For Displaying and Counting Lives
import System.IO;

public var Lives: int = 9;
public var kitty: Texture;
private var lifeCounter: GUIText;
public var numFound: int = 0;  //number of bottles found
public var numHit: int = 0;  //number of bottles knocked over
private var timer: float = 120.0;  //the timer will start at 3 minutes  Timer code modeled after https://www.youtube.com/watch?v=w33cOjMT0fE
private var timeCounting : boolean = false;  //timer only counts down if this is true

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
 	
 	GUI.Label(Rect(Screen.width/4, (Screen.height * 0.8)-20.0, (Screen.width/2), 50), "" + timer.ToString("0"));  //display remaining time
 	
  	var centeredStyle = GUI.skin.GetStyle("Label");
    centeredStyle.alignment = TextAnchor.UpperCenter;	

 	switch (indexObjective)
 	{
 	case 0: // Find the bottles
		 GUI.Label(Rect(Screen.width/4, Screen.height * 0.8, Screen.width/2, 50),"Find all the portable puddles.  They are a hazard.  " + numFound + "/6", centeredStyle);
 	break;
 	case 1: // Hit a bottle
 	 	 	 GUI.Label(Rect(Screen.width/4, Screen.height * 0.8, Screen.width/2, 50),"Knock one over, but know that it will wake the humans.", centeredStyle);

 	break;
 	case 2: // Hit all bottles
 	 	 	 GUI.Label(Rect(Screen.width/4, Screen.height * 0.8, Screen.width/2, 50),"Knock over all 6 before time runs out.  "+ numHit + "/6", centeredStyle);
 	break;
 	case 3: // Hide behind boxes under stairs
 	 	 GUI.Label(Rect(Screen.width/4, Screen.height * 0.8, Screen.width/2, 50),"Hide behind the boxes under the stairs.  The humans will forget by morning.", centeredStyle);
 	
 	break;
 	default:
 		Debug.Log("DEFAULT SWITCH CASE");
 	}
 }

	function ObjectiveEntered(objective: String) {
		//Debug.Log("Objective Completed in " + timelapsed + " seconds!");
		//Debug.Log(objective);
		
		//if we hit our first bottle, switch to that case and start the timer
		if (numHit == 1)
		{
			indexObjective = 2;
			
			timeCounting = true;	
		}
			
		 switch (indexObjective)
 		{
 		case 0: // Found a bottle
			 if("FOUNDONE".Equals(objective))
			 {
			 	if (numFound >= 6)
			 		indexObjective++;
			 }
 		break;
 		case 1: // found all bottles
			if("ALLFOUND".Equals(objective))
			 	indexObjective++;
 		break;
 		case 2: // hit a bottle
 			if("HITONE".Equals(objective))
 			{
 			Debug.Log(numHit);
			 	if (numHit >= 6)
			 		indexObjective++;

			}
 		break;
 		case 3: // hide
 	 		if("STAIRS".Equals(objective))
			 	indexObjective++;
 		break;
 		default: 
 		Debug.Log("DEFAULT SWITCH CASE");
 		}
	}
	
	//if the timer is activated start counting down.  If it gets to 0 restart the scene
	function Update()
	{
		//countdown
		if (timeCounting)
		{
			timer -= Time.deltaTime;
		}
		
		//if we get to 0 restart the level
		if (timer <= -0.9f)
		{
			Application.LoadLevel("Day_3");
		}
	}