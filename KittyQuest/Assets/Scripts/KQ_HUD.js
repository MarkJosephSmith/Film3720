#pragma strict

import System.IO;

// For Displaying and Counting Lives
public var Lives: int = 9;
public var kitty: Texture;
private var lifeCounter: GUIText;

// For Displaying and Creating Objectives
public var objectives : GameObject[] = new GameObject[5];
private var indexObj: int = 0;

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
 	if (indexObj >= objectives.Length)
 	{

 		GUI.Label(Rect(Screen.width/4, Screen.height * 0.8, Screen.width/2, 50),"Take a nap in a sunspot.", centeredStyle);
 	} 
 	else
 	{
 		var objective: GameObject = objectives[indexObj];
 		if (objective.transform.tag == "Moveable")
 		{
 			GUI.Label(Rect(Screen.width/4, Screen.height * 0.8, Screen.width/2, 50), ("Knock over the " + objective.transform.name), centeredStyle);
 		}
 		else if (objective.transform.tag == "Destination")
 		{
 			Debug.Log("HELLO!");
 			GUI.Label(Rect(Screen.width/4, Screen.height * 0.8, Screen.width/2, 50), ("Go to the " + objective.transform.name), centeredStyle);
 		}
 		else if (objective.transform.tag == "Climbable")
 		{
 		
 		}
 	}
}