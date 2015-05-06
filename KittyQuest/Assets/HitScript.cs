using UnityEngine;
using System.Collections;

public class HitScript : MonoBehaviour {

	public bool isHit = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	//if a punch hits, mark it as hit and update the objectives
	void OnCollisionEnter(Collision col)
	{
		//when the player enters the trigger
		if (col.gameObject.tag == "Punch") 
		{
			//check to see if it's the first time
			if (isHit == false)
			{
				
				//set it to true
				isHit = true;

				//incriment the objective count
				GameObject play = GameObject.Find("First Person Controller");
				KQ_HUD_03 theHUD = play.GetComponent<KQ_HUD_03>();
				theHUD.numHit +=1;
				
			} 
			
		}
		
		return;
	}
}
