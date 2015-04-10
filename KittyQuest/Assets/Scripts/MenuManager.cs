using UnityEngine;
using System.Collections;

public class MenuManager : MonoBehaviour {
	public Camera MainCam;
	public Camera ChooseCam;
	public Camera ControlsCam;

	// Use this for initialization
	void Start () {
		MainCam.enabled = true;
		ChooseCam.enabled = false;
		ControlsCam.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void LoadDay1(){
		Debug.Log ("Day1Loaded");
		Application.LoadLevel (1);
	}
	public void LoadDay2(){
		Debug.Log ("Day2Loaded");
		Application.LoadLevel (2);
	}
	public void LoadDay3(){
		Debug.Log ("Day3Loaded");
		Application.LoadLevel (3);
	}
	public void LoadDay4(){
		Debug.Log ("Day4Loaded");
		Application.LoadLevel (4);
	}
	public void LoadDay5(){
		Debug.Log ("Day5Loaded");
		Application.LoadLevel (5);
	}
	public void Return(){
		Debug.Log ("BackToMainMenu");
		CameraSwitchBack(ChooseCam, ControlsCam, MainCam);
	}
	public void LoadChooseDay(){
		Debug.Log ("ChooseDayLoaded");
		CameraSwitch(MainCam, ChooseCam);
	}
	public void LoadControls(){
		Debug.Log ("ControlsLoaded");
		CameraSwitch(MainCam, ControlsCam);
	}
	public void LoadCredits(){
		Debug.Log ("CreditsLoaded");
	}
	public void Exitgame(){
		Debug.Log ("GameExited");
		Application.Quit();
	}
	public void CameraSwitch(Camera Cam1, Camera Cam2){
		Cam1.enabled = false;
		Cam2.enabled = true;
	}
	public void CameraSwitchBack(Camera Cam1, Camera Cam2, Camera Cam3){
		Cam1.enabled = false;
		Cam2.enabled = false;
		Cam3.enabled = true;
	}
}
