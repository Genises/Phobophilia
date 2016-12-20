using UnityEngine;
using System.Collections;

public class GetTogether : MonoBehaviour {
    //difficulty of game
    private float difficulty = Data.difficulty;
    //Objects on the wall have to be sorted. Objects furthest away form the not moving wall come first/Limited on 3 Objects per wall in this state
    public GameObject[] obj;
    //how far each object should be moved when the backwall gets closer (0.05 for first element and 0.15 for the element closest do the backwall)
    public float[] movement = {0.15f,0.1f,0.05f};
	// Use this for initialization
	void Start () {
        if (difficulty == 1)
        {
            movement = new float[] { 0.3f,0.2f,0.1f};
        }
        else if (difficulty == 2)
        {
            movement = new float[] { 0.65f,0.4f,0.2f};
        }
    }
	
	// Update is called once per frame
	void Update () {
    }

    public void getClose()
    {
        //move objevts together 
        int count = 0;
        for(int i = 0; i<obj.Length; i = i +2)
        {
            for (int j = 0; j < 2; j++)
            {
                Transform transform = obj[i + j].GetComponent<Transform>();
                if (j == 0)
                {
                    transform.position = transform.position + transform.forward * movement[count];
                }
                if (j == 1)
                {
                    transform.position = transform.position + -1*transform.forward * movement[count];
                }
            }
            count++;
        }
    }

}
