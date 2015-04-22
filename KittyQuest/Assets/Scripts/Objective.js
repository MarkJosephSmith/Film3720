#pragma strict

private var current = false;
private var startTime: float = 0.0;
private var player: GameObject;

function Start() {
	player = GameObject.FindGameObjectWithTag("Player");
}

function OnTriggerEnter (other : Collider) {
	// Check if enabled and object is the player
	//Debug.Log("Objective Trigger Entered");
	if (current && other.gameObject.tag == "Player") {
		var timelapsed = Time.time - startTime;
		player.SendMessage("ObjectiveEntered",timelapsed);
		current = false;
	}
}

function OnCollisionEnter (other : Collision) {
	// Check if enabled and object is the player
	//Debug.Log("Objective Trigger Entered");

	if (current) {
		var timelapsed = Time.time - startTime;
		player.SendMessage("ObjectiveEntered",timelapsed);
		current = false;
	}
}

function Enable() {
	current = true;
	startTime = Time.time;
}