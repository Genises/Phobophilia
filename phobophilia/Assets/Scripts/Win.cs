using UnityEngine;
using System.Collections;
// Author: Zach Shron

public class Win : MonoBehaviour
{
    //Script that operates win condition and room exit
    
    private bool opened = false;
    private GameObject chain;
    void Start()
    {
        //find trigger that moved the statue
        chain = GameObject.FindGameObjectWithTag("Correct");
    }
    

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("test");
        //If the collider is the key and the statue is no longer covering the exit
        if ((other.tag == "Key") && (chain.GetComponentInChildren<SuccessChain>().statMoved == true))
        {

            //If the door is closed
            if (opened == false)
            {
                //trigger openening animation
                this.GetComponentInParent<Animator>().SetTrigger("Win");
                opened = true;
            }


        }
    }
}
