using UnityEngine;
using System.Collections;

//Heart of room2
public class ClaustrophobiaGM : MonoBehaviour {

    //include all Traps in the scene
    GameObject[] traps;
    public GameObject key;
    public GameObject shield;
    public GameObject celling;
    //should player get killed(celling drops down)
    public bool die=false;
    public float speed;
    private Vector3 nullV = new Vector3(0f, 0f, 0f);
    public Claustrophobie_aktivator ca_;
    //amount of buttons that need to be pushed to trigger next event
    public float buttonToBePushed = 3;
    //counter
    private float buttonPushed = 0;
    //Object that is used for an event
    public GameObject buttonBehindShield;

    // Use this for initialization
    void Start () {
        traps = GameObject.FindGameObjectsWithTag("Trap");
        key = GameObject.FindGameObjectWithTag("Key");
        if(celling == null)
        {
            Debug.Log(" Celling missing");
        }
        if (shield == null)
        {
            Debug.Log("Shield Missing");
        }
	}
	
	// Update is called once per frame
	void Update () {
        if (die)
        {
            celling.transform.position = Vector3.MoveTowards(celling.transform.position, nullV, 0.001f);
        }
	}

    public void pulledTorch(bool right)
    {
        if (right)
        {
            dropShield();
           //Debug.Log("Trigger clock");
        } else
        {
            activateTraps("trap");
        }
    }

    public void pushedButton()
    {
        //as soon as the first button gets pushed, the celling starts to move down
        Debug.Log("Pushed Button");
        if (buttonPushed == 0)
        {
            dropCellingWithoutSpikes();
        }
        buttonPushed++;
        //if all buttons pushed, key falls down and appearce in the scene
        if (buttonToBePushed == buttonPushed)
        {
            key.GetComponent<Rigidbody>().useGravity = true;
            key.GetComponent<AudioSource>().Play(22050);
        }
    }

    //gameObject shield gets dropped and movable in the scene
    public void dropShield()
    {
        shield.GetComponent<Rigidbody>().useGravity = true;
        shield.GetComponent<Rigidbody>().isKinematic = false;
        buttonBehindShield.GetComponent<Collider>().enabled = true;
    }

    //no traps activated
    public void dropCellingWithoutSpikes()
    {
        celling.GetComponent<Collider>().enabled =true;
        die = true;
        celling.GetComponent<AudioSource>().Play();

}

    public void dropCelling()
    {
        celling.GetComponent<Collider>().enabled = true;
        die = true;
        activateTraps("final");
        ca_.enabled = false;
        celling.GetComponent<AudioSource>().Play();

    }

    //activate all traps that were given in the variable(Traps work with collider and animator)
    public void activateTraps(string type)
    {
        Debug.Log("Activate Traps");
        foreach (GameObject trap in traps)
        {
            trap.GetComponent<Animator>().SetTrigger(type);
            trap.GetComponent<AudioSource>().Play();
        }
    }
}
