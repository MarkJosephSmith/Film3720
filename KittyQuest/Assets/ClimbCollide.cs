using UnityEngine;
using System.Collections;

public class ClimbCollide : MonoBehaviour {

    bool isClimbing = false;  //is the character currently climbing
    bool canClimb = false;  //is the character touching a climbable object
    int grip = 100;  //how strong is your grip
    bool onTop = false; //has the character reached the top of a climable object
    bool touchedGround = false;  //has the character touched the ground since they started climbing



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    /*LateUpdate is used to turn off climbing.  This is done so
     * that the character only keeps climbing if they collide with the
     * climbable object again in the next frame.
     */
    void LateUpdate()
    {
        canClimb = false;
    }


	/*collision climb tests
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



            //check to see if we are at a correct 

            //check if we are currently climbing and call the appropriate function

            //Climbing();

        }
    }

    /*Function that does the needed checks and sets all the 
     * needed variables so that the update function can begin climbing
     * 
     */
    void Climbing()
    {
        
    }

    /*Function that sets all the needed variables so that the update function stops climbing
     * 
     */
    void Climbing()
    {

    }
}
