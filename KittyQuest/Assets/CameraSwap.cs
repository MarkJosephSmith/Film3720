using UnityEngine;
using System.Collections;

public class CameraSwap : MonoBehaviour {
	
	public Camera firstPerson; //first person camera, tied to Main Camera
	public Camera thirdPerson; //third person camera, tied to Camera Third Person
	public Camera oculusLeft;  //left eye oculus camera
	public Camera oculusRight; //right eye oculus camera
	public GameObject oculusManager; //camera manager for the oculus

	//tracks what camera is being used, 0 = first person, 1 = third person, 2 = Oculus
	public int whatCam = 0; 
	
	// Use this for initialization
	void Start () {

		oculusManager = GameObject.FindGameObjectWithTag("OVRCamera");  

		//initialize to first person camera
		firstPerson.enabled = true;
		thirdPerson.enabled = false;
		oculusManager.SetActive(false); //modeled from https://forums.oculus.com/viewtopic.php?t=3308 
		oculusLeft.enabled = false;
		oculusRight.enabled = false;

		
	}
	
	// Update is called once per frame
	void Update () {

		//the v key changes the camera
		if (Input.GetKeyDown ("v")) 
		{
			//if we are on 1 when the swap is called loop around
			if (whatCam >= 2) 
			{
					whatCam = 0;
			} 
			//otherwise increment
			else 
			{
					whatCam++;
			}

			//call that camswap
			Debug.Log("passing in " + whatCam);
			CamSwap(whatCam);
		}
		
	}

	//takes an int from 0 to 2 and sets the camera according to 0 = first person, 1 = third person, 2 = Oculus
	void CamSwap(int tempCam)
	{
		Debug.Log("got " + whatCam);
		//set camera to 1st person
		if (tempCam == 0) 
		{
			firstPerson.enabled = true;
			thirdPerson.enabled = false;
			oculusManager.SetActive(false);
			oculusLeft.enabled = false;
			oculusRight.enabled = false;


		} 
		//set camera to 3rd person
		else if (tempCam == 1) 
		{
			firstPerson.enabled = false;
			thirdPerson.enabled = true;
			oculusManager.SetActive(false);
			oculusLeft.enabled = false;
			oculusRight.enabled = false;

		}
		//set camera to oculus
		else if (tempCam == 2) 
		{
			firstPerson.enabled = false;
			thirdPerson.enabled = false;
			oculusManager.SetActive(true);
			oculusLeft.enabled = true;
			oculusRight.enabled = true;

		} 
		//something has gone wrong, print an error and reset the camera to first person
		else 
		{
			Debug.Log("CameraSwap script busted, went over max number of cameras");
			CamSwap(0);
		}

	

	}
}