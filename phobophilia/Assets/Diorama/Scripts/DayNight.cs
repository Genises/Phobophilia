using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DayNight : MonoBehaviour {

    public float speed = 30.0f;

    Light light_;
	// Use this for initialization
	void Start () {
        light_ = GetComponent<Light>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.L))
        {
            transform.Rotate(Vector3.left * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.R))
        {
            transform.Rotate(Vector3.right * speed * Time.deltaTime);
        }
        if (Input.GetKeyUp(KeyCode.G))
        {
            GetComponent<Animator>().SetTrigger("flash");
        }
    }

    public void setLight(Slider yvalue)
    {
        light_.color = new Color(1, 1,yvalue.value/255, 1);
    }
}
