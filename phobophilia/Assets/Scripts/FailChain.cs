using UnityEngine;
using System.Collections;
//Author: Zach Shron


public class FailChain : MonoBehaviour {

    //Script dictates behavior of incorrect chains

	
	void OnTriggerEnter(Collider other)
    {
        //If a hand enters the collision space
        if (other.tag == "Hand")
        {
            //trigger pulling animation and sound and spawn spiders
            this.GetComponentInParent<Animator>().SetTrigger("Pull");
            this.GetComponentInParent<AudioSource>().Play();
            this.GetComponent<SpiderSpawn2>().Spawn();
        }
	}
}
