using UnityEngine;
using System.Collections;
//Author: Zach Shron

public class SuccessChain : MonoBehaviour
{
    //Script for the correct chain
    private GameObject statue;
    public bool statMoved = false;
    private bool moveNow = false;
    private int i = 0;

    void Start()
    {
        //Aquire statue
        statue = GameObject.FindGameObjectWithTag("Statue");
    }

    void FixedUpdate()
    {

        
        if (moveNow && i <= 400)
        {
            statue.transform.position = new Vector3(statue.transform.position.x, statue.transform.position.y, (i / 100));
            i++;
        }
        
    }

    void OnTriggerEnter(Collider other)
    {
        //If a hand enters the collision area
        if (other.tag == "Hand")
        {
            //Animate the chain and play the appropriate sound
            this.GetComponentInParent<Animator>().SetTrigger("Pull");
            this.GetComponentInParent<AudioSource>().Play();
            //If the statue is still covering the exit
            if (statMoved == false)
            {
                
                //Trigger the statue animation and sound
                statue.GetComponent<AudioSource>().Play();
                moveNow = true;
               
                statMoved = true;
            }
           // statue.GetComponent<Animator>().ResetTrigger("StatTrig");


        }
    }
}
