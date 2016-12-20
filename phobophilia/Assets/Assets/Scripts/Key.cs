using UnityEngine;
using System.Collections;

public class Key : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    //The door can be moved when kinematic is enable (Door uses hingeJoints)
    void OnCollisionEnter(Collision col)
    {
        if (col.collider.tag == "Door")
        {
            col.gameObject.GetComponent<Rigidbody>().isKinematic = false;
        }
    }
}
