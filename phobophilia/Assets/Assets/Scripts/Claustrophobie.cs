using UnityEngine;
using System.Collections;

public class Claustrophobie : MonoBehaviour {
    //gets difficulty of the game
    private float difficulty = Data.difficulty;
    //sets the speed, how fast the walls get closer.
    private float mc = 0f;
    public bool backWall = false;

	// Use this for initialization, walls get closer faster with higher difficulty
	void Start () {
        if (difficulty == 1) {
            mc = 0.2f;
        } else if (difficulty == 2)
        {
            mc = 0.7f;
        }

    }
	
	// Update is called once per frame
	void Update () {
	
	}
    
    public void moveTowards()
    {
        //important to use the with movetowards instead of changing the position of an object. otherwise the collider will not be detected
        Vector3 vec = transform.position + transform.right;
        transform.position = Vector3.MoveTowards(transform.position,vec,0.2f +mc);

        if (backWall == true)
        {
            GetComponent<GetTogether>().getClose();
        }
    }
}
