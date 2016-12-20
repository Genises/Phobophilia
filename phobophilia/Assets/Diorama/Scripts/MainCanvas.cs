using UnityEngine;
using System.Collections;

public class MainCanvas : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        
    }
    void OnMouseOver()
    {
        GetComponentInChildren<Canvas>().enabled = true;
    }
    void OnMouseExit()
    {
        Invoke("disableCanvas", 5f);
    }

    void disableCanvas()
    {
        GetComponentInChildren<Canvas>().enabled = false;

    }
}
