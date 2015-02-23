using UnityEngine;
using System.Collections;

public class Climb : MonoBehaviour {
	
	private bool isClimbing = false; //simple bool to easily determine if the player is currently climbing
	private int grip = 100;
	
	//code modeled from:
	//https://www.youtube.com/watch?v=RWCaQg5q9PY
	//private FPSInputController FPSControl;
	
	// Use this for initialization
	void Start () 
	{
		//reference to the fps control for the player
		//FPSControl = GetComponent<FPSInputController>();
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		//reduce our grip
		if (grip > 0) 
		{
			grip -= grip;
		}
		
		//check if you are climbing
		if (isClimbing) 
		{
            //stop any current motion
            this.gameObject.GetComponent<CharacterMotor>().movement.velocity = Vector3.zero;
            this.gameObject.GetComponent<CharacterMotor>().movement.frameVelocity = Vector3.zero;

			// w moves you up and resets your grip
			if (Input.GetKey("w"))
			{
				System.Console.WriteLine(isClimbing);
				grip = 100;
				this.gameObject.transform.Translate(0.0f,0.2f,0.0f,Space.World);
				
			}
			
			// s moves you down and resets your grip
			if (Input.GetKey("s"))
			{
				grip = 100;
                this.gameObject.transform.Translate(0.0f, -0.2f, 0.0f, Space.World);
				
			}
		}
		
	}

	/*currently not colliding****************************************************************************************
	 * Try referencing these:	http://answers.unity3d.com/questions/52563/falling-through-ground-with-colliders.html     
	 * 							http://answers.unity3d.com/questions/35010/my-object-falls-through-terrain.html
	 * 
	/*Simple collision checker, checks to see if the object we collided with is climbable
     * 
     *
	void OnCollisionEnter(Collision col)
	{
		System.Console.WriteLine ("collided");
		if (col.gameObject.tag == "Climbable") 
		{
			Climbing();
		}
	}
	
	/*Simple collision checker, checks to see if the object we stopped colliding with was climbable
     * 
     *
	void OnCollisionExit(Collision col)
	{
		if (col.gameObject.tag == "Climbable") 
		{
			StopClimbing();
		}
	}
	
	/*Simple collision checker, checks to see if the object we stopped colliding with was climbable
     * 
     *
	void OnCollisionStay(Collision col)
	{
		if (col.gameObject.tag == "Climbable") 
		{
			Climbing();
		}
	}
	******************************************************************************************************************/



    /*Testing the climbinbg scripts with triggers instead of object collisions.  This is not an idea way to code this as it requires 
     * putting trigger objects at the top an bottom of each climbable object
     * */
     
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Climbable")
        {
            Debug.Log("Collided, climbing is " + isClimbing);
            //check if we are currently climbing and call the appropriate function
            if (!isClimbing)
            {
                Climbing();
            }
            else
            {
                StopClimbing();
            }
        }
    }
     
    

    /*back to collision climb tests
    * 
    
    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "Climbable")
        {
            Debug.Log("Collided, climbing is " + isClimbing);
            //check if we are currently climbing and call the appropriate function

            Climbing();

        }
    }

    void OnCollisionExit(Collision col)
    {
        if (col.gameObject.tag == "Climbable")
        {
            Debug.Log("Collided, climbing is " + isClimbing);
            //check if we are currently climbing and call the appropriate function
            StopClimbing();

        }
    }
     * */







    /*Function is called when the player collides with a climbable object.  The function will change the movement
     * controls such that the player climbs up the object when moving forward and down when moving backwards
     * 
     */
	void Climbing()
	{
		//set the bool
		isClimbing = true;
		
		//this.gameObject.
		//rigidbody.useGravity = false;
        
        this.gameObject.GetComponent<CharacterMotor>().movement.gravity = 0.0f;
		
		//disable the normal movement controls
		GetComponent<FPSInputController>().enabled = false;

        //stop any current motion
        this.gameObject.GetComponent<CharacterMotor>().movement.velocity = Vector3.zero;
        this.gameObject.GetComponent<CharacterMotor>().movement.frameVelocity = Vector3.zero;
		
		
		
		
		
		//call the slipping method
		Slipping (grip);
	}
	
	/*Function is called when the players is no longer colliding with a climbable object.  The function will change the 
     * movement controls from the 
     * 
     */
	void StopClimbing()
	{
		//set the bool
		isClimbing = false;
		
		//this.gameObject.
		//rigidbody.useGravity = true;
        this.gameObject.GetComponent<CharacterMotor>().movement.gravity = 10.0f;
		
		//enable the normal movement controls
		GetComponent<FPSInputController>().enabled = true;
		
		
	}
	
	/*Function is called if the player sits still while climbing.  They will slowly slide down the object.
     * 
     * 
     */
	void Slipping(int gr)
	{
		
		
	}
	
	
	
}
