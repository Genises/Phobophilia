using UnityEngine;
using System.Collections;

public class Button : MonoBehaviour {

    private Animator anim_;
    private ClaustrophobiaGM gm_;
    private AudioSource as_;

    //set rightButton in Scene to trigger next event
    public bool rightButton = false;
    //used to activate one trap only once
    bool hasBeenTouched = false;


    // Use this for initialization
    void Start () {
        anim_ = GetComponent<Animator>();
        gm_ = GameObject.FindWithTag("GameController").GetComponent<ClaustrophobiaGM>();
        as_ = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update () {
	
	}

    //check if button was pushed by the player
    void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Player")

            {
            Debug.Log("Player touched button");
            if (!hasBeenTouched)
            {
                hasBeenTouched = true;
                    anim_.SetTrigger("push");
                    as_.Play();
                    gm_.pushedButton();
                }
            
        }
    }
}
