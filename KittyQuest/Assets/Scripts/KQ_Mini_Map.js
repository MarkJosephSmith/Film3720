#pragma strict
import System.IO;

public var player: GameObject;
public var floor: GameObject;

function Update () 
{
	var mask: int;
	var cullingMask: int = gameObject.GetComponent.<Camera>().cullingMask;

    // Debug.Log("Mask = " + cullingMask.ToString());
	if (player.transform.position.y > floor.transform.position.y)
	{
		mask = 1 << 8;
		mask = ~mask;
		cullingMask = cullingMask & mask;
		mask = 1 << 9;
		cullingMask = cullingMask | mask;
	}
	else
	{
		mask = 1 << 8;
		cullingMask = cullingMask | mask;
		mask = 1 << 9;
		mask = ~mask;
		cullingMask = cullingMask & mask;
	}
	//mm_camera

	gameObject.GetComponent.<Camera>().cullingMask = cullingMask;
}