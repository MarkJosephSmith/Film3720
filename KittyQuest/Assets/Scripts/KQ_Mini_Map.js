#pragma strict
import System.IO;

public var player: GameObject;
public var floor: GameObject;

function Start()
{
	InvokeRepeating("CheckFloor",0.0,1.0);
}

function CheckFloor() 
{
	var mask: int;
	var cullingMask: int = gameObject.GetComponent.<Camera>().cullingMask;

	// FLOOR 1 is LAYER 8
	// FLOOR 2 is LAYER 9

    // Debug.Log("Mask = " + cullingMask.ToString());
	if (player.transform.position.y > floor.transform.position.y)
	{
		//Debug.Log("Player at: " + player.transform.position.y + " Floor at: " + floor.transform.position.y);
		mask = 1 << 8;
		mask = ~mask;
		cullingMask = cullingMask & mask;
		mask = 1 << 9;
		cullingMask = cullingMask | mask;
	}
	else
	{
		mask = 1 << 9;
		mask = ~mask;
		cullingMask = cullingMask & mask;
		mask = 1 << 8;
		cullingMask = cullingMask | mask;
	}
	gameObject.GetComponent.<Camera>().cullingMask = cullingMask;
}