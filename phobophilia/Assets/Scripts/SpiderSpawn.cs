using UnityEngine;
using System.Collections;
//Author: Zach Shron

public class SpiderSpawn : MonoBehaviour {


    // Class controling over time spider spawning,
    // Also responsible for difficulty multiplication.
    public GameObject prefab;
    public static int numberOfObjects = 0;
    public int maxObjects = 1000;
    private GameObject[] spawns;
    private Vector3[] pos;
    private float rand;
    private Object spider;
    private int counter = 0;
    private int interval = 120;
    private int difficulty = 0;
    private float mInt;

    void Start()
    {
        //find all spawn points
        if (spawns == null)
        {
            spawns = GameObject.FindGameObjectsWithTag("Respawn");
        }

        difficulty = Data.difficulty;

    }

    void Update()
    {
        /* The rate spiders constantly enter the room is defined by a predeterined interval
         * (currently 60 frames). This interval is then divided by the deifficulty setting
         * resulting in 60 frames between spawns on easy, 30 on normal and 20 on hard.
         * 
         */
        mInt = Mathf.Round(interval / (difficulty + 1));
        
        if ((counter % mInt) == 0)
        {
            //define a random spawn point
            rand = Mathf.Round(Random.value * 3);
            // control overpopulation (can result in massive framerate drop)
            if (numberOfObjects < maxObjects)
            {
                //control the number of spiders with audio (too many leads to audio bugs)
                prefab.GetComponent<AudioSource>().enabled = false;
                if ((numberOfObjects % 10) == 0)
                    prefab.GetComponent<AudioSource>().enabled = true;
                // instantiate objects and increment counter
                Instantiate(prefab, spawns[(int)rand].transform.position, Quaternion.identity);
                numberOfObjects++;
            }

            
            

            
        }
        //increment frame tracking
        
        counter++;
    }
}
