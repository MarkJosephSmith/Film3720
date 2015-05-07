#pragma strict

public var playerInteraction = false;
private var startTime: float = 0.0;
private var player: GameObject;

function Start() {
	player = GameObject.FindGameObjectWithTag("Player");
}

function OnTriggerEnter (other : Collider) {
	// Check if enabled and object is the player
	//Debug.Log("Objective Trigger Entered");
	if (playerInteraction && other.gameObject.tag != "Player" && other.gameObject.tag != "Punch") {
		return;
	}
	var timelapsed = Time.time - startTime;
	player.SendMessage("ObjectiveEntered", gameObject.name);
	this.enabled = false;
}

function OnCollisionEnter (other : Collision) {
	// Check if enabled and object is the player
	//Debug.Log("Objective Trigger Entered");

	if (playerInteraction && other.gameObject.tag != "Player" && other.gameObject.tag != "Punch") {
		return;
	}
	var timelapsed = Time.time - startTime;
	player.SendMessage("ObjectiveEntered", gameObject.name);
	this.enabled = false;
}