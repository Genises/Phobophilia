using UnityEngine;
using System.Collections;

public class TargetBehaviour : MonoBehaviour
{
    public float exitSeconds = 1f;
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }
    void KillTarget()
    {
        Destroy(gameObject);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.Equals("Bullet")) { 
            if (GetComponent<Animator>() != null)
                this.GetComponent<Animator>().SetTrigger("Exit");

            Invoke("KillTarget", exitSeconds);
        }
    }
}
