using UnityEngine;
using System.Collections;

public class FireAnimation : MonoBehaviour {

	//modeled after https://www.youtube.com/watch?v=s7EIp-OqVyk

	Animator currentAnimation;  //our current animator

	// Use this for initialization
	void Start () {
	
		currentAnimation = GetComponent<Animator> ();

	}
	
	// Update is called once per frame
	void Update () {
	
		float move = Input.GetAxis("Vertical");
		currentAnimation.SetFloat ("Speed", move);

	}
}
