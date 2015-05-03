using UnityEngine;
using System.Collections;

public class MenuManager : MonoBehaviour {

	public Canvas Menu;
	public Canvas SelectDay;
	private bool _showIngameMenu = false;
	// Use this for initialization
	void Start () 
	{
		Menu.enabled = false;
		SelectDay.enabled = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKeyDown(KeyCode.Escape))
		{
			if(Menu.enabled == false)
			{
				Debug.Log ("Ingame Menu On");
				Menu.enabled = true;
			}
			else
			{
				Debug.Log ("Ingame Menu Off");
				Menu.enabled = false;
			}
		}
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
	public void IGSelectDay(){
		Debug.Log ("Ingame Select a Day");
		Menu.enabled = false;
		SelectDay.enabled = true;
	}
	public void IGBack()
	{
		Debug.Log ("Ingame Back");
		Menu.enabled = true;
		SelectDay.enabled = false;
	}
}
