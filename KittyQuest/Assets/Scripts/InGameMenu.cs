using UnityEngine;
using System.Collections;

public class InGameMenu : MonoBehaviour 
{
	public Canvas IngameMenu;
	// Use this for initialization
	void Start () 
	{
		Cursor.lockState = CursorLockMode.Locked;
		Cursor.visible = false;
		IngameMenu.enabled = false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetKey(KeyCode.Escape))
		{
			if(IngameMenu.enabled = false)
			{
				IngameMenu.enabled = true;
				Cursor.lockState = CursorLockMode.None;
				Cursor.visible = true;
			}
			if(IngameMenu.enabled = true)
			{
				IngameMenu.enabled = false;
				Cursor.lockState = CursorLockMode.Locked;
				Cursor.visible = false;
			}
		}
	}
}
