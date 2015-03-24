using UnityEngine;
using System.Collections;

public class Moveable : MonoBehaviour 
{
	
	public GameObject playerChar;
	public float pushPower = 2.0F;

	void Start () 
	{
		playerChar = GameObject.FindGameObjectWithTag ("Player");
	}

	void OnControllerColliderHit(ControllerColliderHit hit) 
	{

		if (hit.gameObject.tag == "moveable")
		{
			Debug.Log ("Collision with moveable object.");
		}

		Rigidbody body = hit.collider.attachedRigidbody;
		if (body == null || body.isKinematic)
			return;
		
		if (hit.moveDirection.y < -0.3F)
			return;
		
		Vector3 pushDir = new Vector3(hit.moveDirection.x, 0, hit.moveDirection.z);
		body.velocity = pushDir * pushPower;
	}

}