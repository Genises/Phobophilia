using UnityEngine;
using System.Collections;
//Author: Zach Shron

public class Follow : MonoBehaviour {

    // Class defines follow behavior for spiders

    private Transform target;
    public float moveSpeed = 30;
    public float rotSpeed = 3;
    private Transform myTransform;
    private Rigidbody myBody;
    private int counter;
    private Vector3 tmp;
    private Vector3 distance;

	void Awake()
    {
        // retrieve transform/rigidbody from spider
        myTransform = transform;
        myBody = GetComponent<Rigidbody>();
    }
	void Start ()
    {
        // aquire target
        target = GameObject.FindGameObjectWithTag("Player").transform;
        
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        //Target fix to prevent spiders flying
        Vector3 noFloating;
        noFloating = target.position;
        noFloating.y = 0.5f;
        counter++;

        if (myBody.position.y < 6)
        {
            
            //distance to target
            distance = noFloating - myTransform.position;
            //rotate to face target
            myBody.rotation = Quaternion.Slerp(myTransform.rotation,
                Quaternion.LookRotation(distance), rotSpeed * Time.deltaTime);


            //Use a temporary matrix to store movement speed and direction,
            //maintain Y drection(gravity) acceleration
            //Assign new values to velocity

            tmp = (myTransform.forward * moveSpeed);
            tmp.y = myBody.velocity.y;
            myBody.velocity = tmp;
           
            
        }
    }
}
