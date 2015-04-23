using UnityEngine;
using System.Collections;

public class PunchCleanup : MonoBehaviour {

    bool punchDestroy = false;
    int framesTraveled = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        framesTraveled += 1;
        if (framesTraveled > 10)
        {
            punchDestroy = true;
        }
	}

    void LateUpdate ()
    {
        if (punchDestroy)
        {
            Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter(Collision col)
    {
        punchDestroy = true;
    }
}
