using UnityEngine;
using System.Collections;
//Author: Zach Shron

public class KeySpiders : MonoBehaviour {

    private bool doIt = false;
    private bool once = false;
	
	//Specific script to dictate spiders spawning on key
	void Update ()
    {
        //if key is picked up
        doIt = this.GetComponent<InteractableObject>().currentlyInteracting;
        if ((doIt == true) && (once == false))
        {
            //Call spawn script and ensure only one call is ever made
            this.GetComponent<SpiderSpawn2>().Spawn();
            once = true;
        }
	
	}
}
