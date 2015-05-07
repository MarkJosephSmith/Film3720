#pragma strict

private var startTime: float = 0.0;
private var player: GameObject;
public var object: GameObject;

function Start() {
	player = GameObject.FindGameObjectWithTag("Player");
}

function OnTriggerEnter (other : Collider) {
	// Check if enabled and object is the player
	if (!other.gameObject.name.Equals(object.name)) {
		return;
	}
	var timelapsed = Time.time - startTime;
	player.SendMessage("ObjectiveEntered", gameObject.name);
}