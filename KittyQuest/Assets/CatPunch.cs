using UnityEngine;
using System.Collections;

//code modeled from https://www.youtube.com/watch?v=B88kIJxK7fc

public class CatPunch : MonoBehaviour {

    public Rigidbody punchBody;
    float punchSpeed = 30;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () 
    {

        if (Input.GetButtonDown("Fire1"))
        {
            ThrowPunch();
        }
	
	}


    //creates a punch object at the front of our fist and shoots is forward
    void ThrowPunch()
    {
        //create a punch
        Rigidbody tempPunch = Instantiate(punchBody, transform.position, transform.rotation) as Rigidbody;

        //fire it forward
        tempPunch.velocity = transform.TransformDirection( new Vector3(0, 0, punchSpeed));
    }
}
