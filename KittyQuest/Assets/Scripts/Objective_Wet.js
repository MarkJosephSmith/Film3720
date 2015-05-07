#pragma strict

private var playerInteraction = true;
private var startTime: float = 0.0;
private var player: GameObject;
private var send = false;

function Start() {
	player = GameObject.FindGameObjectWithTag("Player");
	InvokeRepeating("AllowSend", 1, 1.0);
}

function AllowSend()
{
 	send = true;
}

function OnTriggerStay (other : Collider) {
	// Check if enabled and object is the player
	//Debug.Log("Objective Trigger Entered");
	if (send == false)
		return;
	if (playerInteraction && other.gameObject.tag != "Player") {
		return;
	}
	var timelapsed = Time.time - startTime;
	player.SendMessage("ObjectiveEntered", gameObject.name);
	send = false;
}
