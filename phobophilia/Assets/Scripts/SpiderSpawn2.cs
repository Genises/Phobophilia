using UnityEngine;
using System.Collections;
//Author: Zach Shron

public class SpiderSpawn2 : MonoBehaviour {

    public GameObject prefab;
    private Vector3 spawn;
    public float amount;
    //Script for spawning a cluster of spiders at target location
    void Start () {

        //position of object script is attached to
        spawn = this.transform.position;
        
        

    }

	public void Spawn ()
    {
        // Spawn an amount of spiders
        for (int i = 0; i<amount; i++)
        {
            Instantiate(prefab, spawn, Quaternion.identity);
            SpiderSpawn.numberOfObjects++;
        }
	
	}
}
