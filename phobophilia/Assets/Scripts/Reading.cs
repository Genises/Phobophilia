using UnityEngine;
using System.Collections;
//Author: Zach Shron
public class Reading : MonoBehaviour {

    private bool read = false;
    private GameObject page;
    //Script to enable the reading of the book
	
	void Start()
    {
        //find page canvas
        page = GameObject.FindGameObjectWithTag("Book");
    }
	void Update ()
    {
       
        //Discover whether the book is being selected
        read = this.GetComponent<InteractableObject>().currentlyInteracting;
        //Debug.Log(read);
        if (read)
        {
            //if so activate read canvas
            page.SetActive(true);
        }
        //if not deactivate
        else
            page.SetActive(false);

    }
}
