using UnityEngine;
using System.Collections;

public class ClimbCollide : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	/*back to collision climb tests
    * 
    **/ 
	void OnControllerColliderHit(ControllerColliderHit col)
    {
		Rigidbody body = col.collider.attachedRigidbody;

		if (body == null || body.isKinematic) 
		{
			return;
		}

        if (body.gameObject.CompareTag("Climbable"))
        {
            Debug.Log("Colliding");
            //check if we are currently climbing and call the appropriate function

            //Climbing();

        }
    }
	/*
    void OnCollisionExit(Collision col)
    {
        if (col.gameObject.CompareTag("Climbable"))
        {
            Debug.Log("Collided, climbing is " + isClimbing);
            //check if we are currently climbing and call the appropriate function
            //StopClimbing();

        }
    }*/
}
