using UnityEngine;
using System.Collections;

public class ClimbSensor : MonoBehaviour {

	//public bool isClimbing;

	// Use this for initialization
	void Start () {
		//isClimbing = false;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	

	}


	void OnTriggerEnter(Collider col)
	{
		Debug.Log ("test");
		Rigidbody body = col.GetComponent<Collider>().attachedRigidbody;
		
		if (body == null || body.isKinematic) 
		{
			return;
		}

		if (body.gameObject.CompareTag ("Climbable")) 
		{
			Debug.Log ("start colliding");
			this.transform.parent.gameObject.GetComponent<ClimbCollide>().isClimbing = true;

		}
	}


	void OnTriggerExit(Collider col)
	{
		Rigidbody body = col.GetComponent<Collider>().attachedRigidbody;
		
		//if (body == null || body.isKinematic) 
		//{
		//	return;
		//}
		
		if (body.gameObject.CompareTag ("Climbable")) 
		{
			Debug.Log ("stopped colliding");
			
			this.transform.parent.gameObject.GetComponent<ClimbCollide>().isClimbing = false;
		}
	}
}
