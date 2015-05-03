using UnityEngine;
using System.Collections;

public class MenuManager : MonoBehaviour {
	public Camera MainCam;
	public Camera ChooseCam;
	public Camera ControlsCam;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	}

	public void LoadDay1(){
		Debug.Log ("Day1Loaded");
		Application.LoadLevel (3);
	}
	public void LoadDay2(){
		Debug.Log ("Day2Loaded");
		Application.LoadLevel (4);
	}
	public void LoadDay3(){
		Debug.Log ("Day3Loaded");
		Application.LoadLevel (5);
	}
	public void LoadDay4(){
		Debug.Log ("Day4Loaded");
		Application.LoadLevel (6);
	}
	public void LoadDay5(){
		Debug.Log ("Day5Loaded");
		Application.LoadLevel (7);
	}
	public void Return(){
		Debug.Log ("BackToMainMenu");
		Application.LoadLevel (0);
	}
	public void LoadChooseDay(){
		Debug.Log ("ChooseDayLoaded");
		Application.LoadLevel (1);
	}
	public void LoadControls(){
		Debug.Log ("ControlsLoaded");
		Application.LoadLevel (2);
	}
	public void LoadCredits(){
		Debug.Log ("CreditsLoaded");
	}
	public void Exitgame(){
		Debug.Log ("GameExited");
		Application.Quit();
	}
}
