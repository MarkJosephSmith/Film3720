using UnityEngine;
using System.Collections;

/*
 *
 * This function can get buggy if the scale of the level is changed.  working to fix that.  Try adding player height X1.5 to top of object.
 */


public class ClimbCollide : MonoBehaviour {

    bool isClimbing = false;  //is the character currently climbing
    bool wasClimbing = false;  //is the character touching a climbable object
    int grip = 100;  //how strong is your grip
    float topOfClimbable = 100000; //stores the top of a climable object



	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (isClimbing)
        {
            //first call 
            //Debug.Log("first call" + isClimbing);

            //adjust movement, gravity and velocity
            StartClimbing();


            //check to see if we are on the ground or not and set button input appropriatly
            // "w" moves you up and resets your grip
            if (Input.GetAxis("Vertical") > 0.01f)
            {
                System.Console.WriteLine(isClimbing);
                grip = 100;
                //this.gameObject.transform.Translate(0.0f,0.2f,0.0f,Space.World);
                this.gameObject.GetComponent<CharacterController>().Move(new Vector3(0.0f, 0.2f, 0.0f));


            }

            // "s" moves you down if you're not grounded and resets your grip
            if (this.GetComponent<CharacterController>().isGrounded)
            {
                //if so nothing changes
            }
            //if we aren't grounded change the s key to climb down.
			else if (Input.GetAxis("Vertical") < -0.01f) 
            {
                grip = 100;
                //this.gameObject.transform.Translate(0.0f, -0.2f, 0.0f, Space.World);
                this.gameObject.GetComponent<CharacterController>().Move(new Vector3(0.0f, -0.2f, 0.0f));


            }

        }

	
	}

    /*LateUpdate is used to turn off climbing.  This is done so
     * that the character only keeps climbing if they collide with the
     * climbable object again in the next frame.
     * 
     * If they were and no longer are this will trigger a return to standard movement
     */
    void LateUpdate()
    {
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
    }

    /*Function that does the needed checks and sets all the 
     * needed variables so that the update function can begin climbing
     * 
     */
    void StartClimbing()
    {
        //disable current movement and gravity
        //stop any current motion, just setting velocity wasn't stoping the character, this is quick and dirty fix.
        this.gameObject.GetComponent<CharacterMotor>().movement.maxForwardSpeed = 0.0f;
        this.gameObject.GetComponent<CharacterMotor>().movement.maxBackwardsSpeed = 0.0f;
        this.gameObject.GetComponent<CharacterMotor>().movement.maxSidewaysSpeed = 0.0f;
        this.gameObject.GetComponent<CharacterMotor>().movement.gravity = 0.0f;
        this.gameObject.GetComponent<CharacterMotor>().movement.velocity = Vector3.zero;
        this.gameObject.GetComponent<CharacterMotor>().movement.frameVelocity = Vector3.zero;
        
    }

    /*Function that sets all the needed variables so that the update function stops climbing
     * 
     */
    void StopClimbing()
    {
        isClimbing = false;

        //restore all the the max variables to their original
        this.gameObject.GetComponent<CharacterMotor>().movement.maxForwardSpeed = 10.0f;
        this.gameObject.GetComponent<CharacterMotor>().movement.maxBackwardsSpeed = 10.0f;
        this.gameObject.GetComponent<CharacterMotor>().movement.maxSidewaysSpeed = 10.0f;
        this.gameObject.GetComponent<CharacterMotor>().movement.gravity = 10.0f;
    }
}
