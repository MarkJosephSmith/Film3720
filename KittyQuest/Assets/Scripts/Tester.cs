using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Tester : MonoBehaviour {

	public bool isQuit;	
	public bool isPlay;
	public bool isControl;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		OnMouseUpAsButton ();
	}

	void OnMouseEnter (){

	}

	void OnMouseUpAsButton(){
		if (isQuit) {
			Application.Quit();
		}
		else if(isPlay){
			Application.LoadLevel(1);
		}
		else if(isControl){

		}

	}
	void OnMouseOver(){

	}

}
