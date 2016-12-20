using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {
    public GameObject[] objects;
    public float power = 30.0f;

    private float standpower;
    private int i = 0;
    

	// Use this for initialization
	void Start () {
        standpower = power;
	}

    // Update is called once per frame
    void Update() {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            GameObject newBall = Instantiate(objects[i], transform.position + transform.forward*5, transform.rotation) as GameObject;
            if (!newBall.GetComponent<Rigidbody>())
            {
                newBall.AddComponent<Rigidbody>();
            }
            newBall.GetComponent<Rigidbody>().AddForce(transform.forward * power, ForceMode.VelocityChange);
            power = standpower;
        }

        if (Input.GetKey(KeyCode.Space))
        {
            power = power + 0.5f;
        }

            //print(transform.position + "" + transform.forward);

            if (Input.GetKeyDown(KeyCode.E))
        {
            i++;
            i = i % 2;
        } 
   }
}
