using UnityEngine;
using System.Collections;

public class IngameMenu : MonoBehaviour 
{
	public Canvas Menu;
	private bool _showIngameMenu = false;
	// Use this for initialization
	void Start () 
	{
		Cursor.visible = false;
		Cursor.lockState = CursorLockMode.Locked;
		Menu.enabled = false;
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
}
