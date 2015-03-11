/* Patrick Eccles - Kitty Quest - February 2015
	This script was made to test the transforms
	that were supposedly collected by the TrackingScript.js
*/

var tracer : GameObject;
private var path : Array;
private var pathIndex = 0;
public var replayFrequency = 0.25;

function OnTriggerEnter (other : Collider) 
{
    Debug.Log("Trigger Entered.");
    var parent: GameObject = other.gameObject;
    var otherScript = parent.GetComponent(TrackingScript); 
    path = otherScript.GetPath().ToArray();
    if (path == null)
    	Debug.Log("FAILED getting path. Probably Patrick's fault.");

	InvokeRepeating("Retrace", 1, replayFrequency);
//	otherScript.NewPath();
}

function Retrace ()
{
	if (pathIndex < path.Count)
	{
	    Debug.Log("Trying to update position.");
		var position : Vector3 = path[pathIndex++];
		//tracer.transform.rotation = path.IndexOf(pathIndex).transform.rotation;
		tracer.transform.position = position;
	}
	else
	{
		pathIndex = 0;
		CancelInvoke();
	}
}