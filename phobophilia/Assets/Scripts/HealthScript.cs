using UnityEngine;
using System.Collections;
using UnityEngine.UI;
//Author: Zach Shron

public class HealthScript : MonoBehaviour {


    //script keeps track of player health and game over screen
    public RawImage health;
    public float maxHealth = 100f;
    public float curHealth = 0f;
    private bool alive = true;
    private GameObject gameOver;

	void Start ()
    {
        // innitialize alive state and max health and disable game over screen
        alive = true;
        curHealth = maxHealth;
        SetHealthBar();
        gameOver = GameObject.FindGameObjectWithTag("Finish");
        gameOver.SetActive(false);

	
	}

  

    // main damage method
    public void TakeDamage(float amount)
    {
      //  Debug.Log("Damage");
        // ensure damage to dead characters is not tracked
        if (!alive)
        {
            return;
        }
        curHealth -= amount;

        // cheack for death
        if (curHealth <= 0)
        {
            //kill player
            curHealth = 0;
            alive = false;
            // enable gameover
            gameOver.SetActive(true);
        }
        // deal damage
        SetHealthBar();
    }
	
    // set health and poison effect
	public void SetHealthBar()
    {
        Debug.Log("SetHealt");
        float myHealth = curHealth / maxHealth;
        //Debug.Log(myHealth);
        Color C = health.color;
        //use alpha to fade poison
        C.a = 1 - myHealth;
        health.color = C;
    }
}
