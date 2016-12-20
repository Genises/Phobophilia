using UnityEngine;
using System.Collections;

public class HeadMovement : MonoBehaviour {

    private Animator anim_;
    public float speed = 30.0f;

	// Use this for initialization
	void Start () {
        anim_ = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Rotate(Vector3.left * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.DownArrow)) { 
            transform.Rotate(Vector3.right * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.down * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(Vector3.up * speed * Time.deltaTime);
        }
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            transform.rotation = transform.parent.rotation;
            
        }
    }

    public void smile()
    {
        anim_.SetTrigger("smile");
    }
}
