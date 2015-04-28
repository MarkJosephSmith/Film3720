using UnityEngine;
using System.Collections;

/*
 *
 * This function can get buggy if the scale of the level is changed.  working to fix that.  Try adding player height X1.5 to top of object.
 */


public class ClimbCollide : MonoBehaviour {

    //bool climbing = false;  //is the character currently climbing
    bool wasClimbing = false;  //is the character touching a climbable object
	public bool isClimbing = false;
    int grip = 100;  //how strong is your grip
    //float topOfClimbable = 100000; //stores the top of a climable object



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		//ClimbSensor tempSensor = this.transform.FindChild ("ClimbSensor");
		//bool touching = tempSensor.isClimbing;
		

		//if we weren't climbing before but are now, set the climbing variables
		if (isClimbing && !wasClimbing) 
		{

				//adjust movement, gravity and velocity
				StartClimbing ();
		}

		//if we were climbing before but aren't now, undo the climbing valiables
		//if we weren't climbing before but are now, set the climbing variables
		if (!(isClimbing) && wasClimbing) {
			
			//adjust movement, gravity and velocity
			StopClimbing ();
		} else if (wasClimbing && this.GetComponent<CharacterController> ().isGrounded) 
		{
			//
			StopClimbing();
		}

		//check to see if we are climbing and adjust the 
		if (isClimbing) 
		{
				//check to see if we are on the ground or not and set button input appropriatly
				// positive "vertical" moves you up and resets your grip
				if (Input.GetAxis ("Vertical") > 0.01f) {
						grip = 100;
						//this.gameObject.transform.Translate(0.0f,0.2f,0.0f,Space.World);
						this.gameObject.GetComponent<CharacterController> ().Move ((new Vector3 (0.0f, 0.2f, 0.0f)));

				}

				// negative "vertical" moves you down if you're not grounded and resets your grip
				if (this.GetComponent<CharacterController> ().isGrounded) {
						//if grounded nothing changes
				}
				//if we aren't grounded change to climb down.
				else if (Input.GetAxis ("Vertical") < -0.01f) {
						grip = 100;
						//this.gameObject.transform.Translate(0.0f, -0.2f, 0.0f, Space.World);
						this.gameObject.GetComponent<CharacterController> ().Move ((new Vector3 (0.0f, -0.2f, 0.0f)));


				}
		}

    }

	void StartClimbing()
	{
		//disable current movement and gravity
		//stop any current motion, just setting velocity wasn't stoping the character, this is quick and dirty fix.
		this.gameObject.GetComponent<CharacterMotor>().movement.maxForwardSpeed = 0.0f;
		this.gameObject.GetComponent<CharacterMotor>().movement.maxBackwardsSpeed = 0.0f;
		this.gameObject.GetComponent<CharacterMotor>().movement.maxSidewaysSpeed = 0.0f;
		this.gameObject.GetComponent<CharacterMotor>().movement.gravity = 0.0f;  //we will handle gravity in the update function because it's a pain in the ass.
		this.gameObject.GetComponent<CharacterMotor>().movement.velocity = Vector3.zero;
		this.gameObject.GetComponent<CharacterMotor>().movement.frameVelocity = Vector3.zero;
		
	}
	
	/*Function that sets all the needed variables so that the update function stops climbing
     * 
     */
	void StopClimbing()
	{
		//isClimbing = false;
		
		//restore all the the max variables to their original
		this.gameObject.GetComponent<CharacterMotor>().movement.maxForwardSpeed = 10.0f;
		this.gameObject.GetComponent<CharacterMotor>().movement.maxBackwardsSpeed = 10.0f;
		this.gameObject.GetComponent<CharacterMotor>().movement.maxSidewaysSpeed = 10.0f;
		this.gameObject.GetComponent<CharacterMotor>().movement.gravity = 10.0f; //we will handle gravity in the update function because it's a pain in the ass.
	}

	void LateUpdate()
	{
		wasClimbing = isClimbing;
	}

	
	////////////////////////////////////////////////////////////////////////////////////////////////////////////Old code I may need to reference.

    /*LateUpdate is used to turn off climbing.  This is done so
     * that the character only keeps climbing if they collide with the
     * climbable object again in the next frame.
     * 
     * If they were and no longer are this will trigger a return to standard movement
     */
    //void LateUpdate()
    //{
		/*
        //Debug.Log("feet at " + (this.gameObject.GetComponent<CharacterController>().center.y - (this.gameObject.GetComponent<CharacterController>().height / 2)) + "height at " + topOfClimbable);
        //Debug.Log("feet at " + (this.gameObject.GetComponent<CharacterController>().transform.position.y - (this.gameObject.GetComponent<CharacterController>().height / .5)) + "height at " + topOfClimbable);
        //Debug.Log("feet at " + (this.gameObject.GetComponent<CharacterController>().transform.position.y) + "height at " + topOfClimbable);

        //stop climbing if we touched the ground or reached the top
        if (this.gameObject.GetComponent<CharacterController>().isGrounded && isClimbing)
        {
            Debug.Log("hit ground");
            StopClimbing();
        }

        //if ((this.gameObject.GetComponent<CharacterController>().center.y - (this.gameObject.GetComponent<CharacterController>().height / 2)) > topOfClimbable)
        //if ((this.gameObject.GetComponent<CharacterController>().transform.position.y - (this.gameObject.GetComponent<CharacterController>().height / .5)) >= topOfClimbable)
        if ((this.gameObject.GetComponent<CharacterController>().transform.position.y) >= topOfClimbable)
        {
            Debug.Log("reached top");
            StopClimbing();
        }
        */

        
        
    //}


	/*collision climb tests
    * 
    *
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

            //this will to see if we are on top of the object and only trigger if we are not.  
            //The check finds the Y coord of the players feet and compairs it to the top of the object
            topOfClimbable = body.GetComponent<Renderer>().bounds.extents.y * 2.5f;
            
            //if ((this.gameObject.GetComponent<CharacterController>().center.y - (this.gameObject.GetComponent<CharacterController>().height / 2)) < topOfClimbable)
            //if ((this.gameObject.GetComponent<CharacterController>().transform.position.y - (this.gameObject.GetComponent<CharacterController>().height / .5)) <= topOfClimbable)
            if ((this.gameObject.GetComponent<CharacterController>().transform.position.y ) <= topOfClimbable)
            {
                isClimbing = true;
            }



        }
    }*/ 

    /*Function that does the needed checks and sets all the 
     * needed variables so that the update function can begin climbing
     * 
     */

}
