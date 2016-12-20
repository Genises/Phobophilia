using UnityEngine;
using System.Collections;
//Author: Zach Shron

public class DamageScript : MonoBehaviour {

    public float damage = 1f;
    private int counter = 0;
    private bool damDelt = false;
	//Script defines how damage is dealt
	
	
	void FixedUpdate () {
        // Control for how often damage can be dealt
        counter++;
        if (counter % 5 == 0)
        {
            damDelt = false;
        }

    }

    void OnTriggerEnter(Collider other)
    {

        //Detect player colliding with spiders
        if (other.tag == "Spider")
        {

            //if dealing damage is approved
            if (damDelt == false)
            {
                //Deal Damage, reset counter and damage approval
                this.gameObject.GetComponent<HealthScript>().TakeDamage(damage);
                damDelt = true;
                counter = 1;
                //Debug.Log("Hit");
            }
        }
        
    }
}
