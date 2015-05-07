using UnityEngine;
using System.Collections;

public class Found : MonoBehaviour {

	bool isFound = false;
	//bool isPunched = false;

	// Use this for initialization
	void Start () {
	


	}
	
	// Update is called once per frame
	void Update () {

	
	}

	//if the player enters the trigger box, turn off the particles and mark it as found
	void OnTriggerEnter(Collider col)
	{
		//when the player enters the trigger
		if (col.tag == "Player") 
		{
			//check to see if it's the first time
			if (isFound == false)
			{


				//if so shut off the particles
				this.gameObject.transform.GetComponentInChildren<ParticleSystem>().enableEmission = false;

				//set it to true
				isFound = true;



				//incriment the objective count
				GameObject play = col.gameObject;
				KQ_HUD_03 theHUD = play.GetComponent<KQ_HUD_03>();
				theHUD.numFound +=1;

				//trigger a check on the count of found objects
				//trigger a check on the count of found objects
				theHUD.ObjectiveEntered("FOUNDONE");
			
			} 

		}

		return;
	}
}
