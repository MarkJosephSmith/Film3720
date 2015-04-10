using UnityEngine;
using System.Collections;

public class MenuManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	 	if(Input.GetAxis("Vertical") > 0.01f){
			Debug.Log("kjgfjhgf");
		}
	}

	public void LoadDay(){
		Debug.Log ("Day1Loaded");
	}
}
