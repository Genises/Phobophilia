using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Movement: MonoBehaviour
{
    //Only used for testing purposes
    float speed = 5.0f;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {       
                transform.Translate(new Vector3(0, 0, 1) * speed * Time.deltaTime);  
        }
        if (Input.GetKey(KeyCode.A))
        {
                transform.Rotate(Vector3.down * speed*20 * Time.deltaTime);
            }
        if (Input.GetKey(KeyCode.S))
        {
                transform.Translate(new Vector3(0, 0, -1) * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
                transform.Rotate(Vector3.up * speed*20 * Time.deltaTime);
        }
    }
}
