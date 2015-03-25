/* Patrick Eccles - Kitty Quest - February 2015
	This script is meant to be attached to the player character.
	Using the InvokeRepeating method,
	it is intended to keep track of the position and rotation of 
	the player character over Time.

*/

private var moveableList : ArrayList;
private var destinationList : ArrayList;

private var currentObjective : String;

function Start()
{
	for each (gameObject in GameObject.FindGameObjectsWithTag("moveable"))
	{
		moveableList.Add(gameObject.name);
	}
	for each (gameObject in GameObject.FindGameObjectsWithTag("destination"))
	{
		destinationList.Add(gameObject.name);
	}
}

function GenerateObjective()
{
	var type = Random.Range(0,1);
	
	switch (type)
	{
	case 0:
	break;
	case 1:
	break;
	default:
	break;
	}
}