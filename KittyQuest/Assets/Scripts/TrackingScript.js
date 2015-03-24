/* Patrick Eccles - Kitty Quest - February 2015
	This script is meant to be attached to the player character.
	Using the InvokeRepeating method,
	it is intended to keep track of the position and rotation of 
	the player character over Time.

*/

private var playerPath : ArrayList;
public var savePathFrequency = 0.25;

// at start of scene
function Start()
{
	// starting in 2 seconds, call SaveTransform every storeFrequency seconds
	InvokeRepeating("SaveTransform", 1, savePathFrequency);
	NewPath();
}

// save the player's tranform, including Rotation and Position and more
function SaveTransform() 
{
// add the position of the gameObject (Player) to the playerPath
	Debug.Log("Saving Position of Player.", gameObject);
	playerPath.Add(gameObject.transform.position);
}

// reset the path
function NewPath()
{
	playerPath = new ArrayList();
}

// return the path
function GetPath()
{
	return playerPath;
}