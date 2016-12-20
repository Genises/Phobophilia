using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

    public GameObject[] objects;
    public GameObject[] spawnedObjects;
    public Canvas mainCanvas;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.M))
        {
            mainCanvas.enabled = !mainCanvas.enabled;
        }
    }
    
    public void setGravity(float gravity) { 
        Physics.gravity = new Vector3(0, gravity, 0);
    }

    public void spawnObject()
    {
        for (int i = 0; i <= 6; i++)
        {
            GameObject newObj = Instantiate(objects[0], new Vector3(Random.Range(-40f, 40f), Random.Range(5f, 30f), Random.Range(-40f, 40f))
                , Random.rotation) as GameObject;
            newObj.transform.localScale = new Vector3(Random.Range(0.1f, 3f), Random.Range(0.1f, 3f), Random.Range(0.1f, 3f));
            newObj.GetComponent<Rigidbody>().mass = Random.Range(1f,8f);
        }
    }

    public void enableGravity()
    {
        spawnedObjects = GameObject.FindGameObjectsWithTag("RandomObject");
        foreach(GameObject obj in spawnedObjects){
            obj.GetComponent<Rigidbody>().useGravity = true;
        }
    }
}
