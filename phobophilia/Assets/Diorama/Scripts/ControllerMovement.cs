using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ControllerMovement : MonoBehaviour
{
    public Text textSpeed;

    public float power = 1.2f;
    GameObject[] spawnedObjects;
    bool state = false;
    float speed = 10.0f;
    public float jumpForce = 100.0f;
    private Animator animChild_;
    private Animator anim_;
    private Rigidbody rigid_;

    // float rotation = 0;

    // Use this for initialization
    void Start()
    {
        anim_ = GetComponent<Animator>();
        animChild_ = GetComponentsInChildren<Animator>()[3];
        rigid_ = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            state = true;
        }
        else if (Input.GetKeyDown(KeyCode.R))
        {
            state = false;
        }

        if (Input.GetKey(KeyCode.W))
        {

            transform.Translate(new Vector3(0, 0, 1) * speed * Time.deltaTime);

        }
        if (Input.GetKey(KeyCode.A))
        {
            if (state)
            {
                transform.Translate(new Vector3(-1, 0, 0) * speed * Time.deltaTime);
            }
            else
            {
                transform.Rotate(Vector3.down * speed * 10 * Time.deltaTime);
            }
            anim_.SetBool("left", true);
        }
        else
        {
            anim_.SetBool("left", false);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(new Vector3(0, 0, -1) * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            if (state)
            {
                transform.Translate(new Vector3(1, 0, 0) * speed * Time.deltaTime);
            }
            else
            {
                transform.Rotate(Vector3.up * speed * 10 * Time.deltaTime);
            }
            anim_.SetBool("right", true);
        }
        else
        {
            anim_.SetBool("right", false);
        }
        if (Input.GetKey(KeyCode.J))
        {
            animChild_.SetTrigger("jump");
            rigid_.AddForce(transform.up * jumpForce);
        }
    }
    public void useTheForce()
    {
        spawnedObjects = GameObject.FindGameObjectsWithTag("RandomObject");
        foreach (GameObject obj in spawnedObjects)
        {
            obj.GetComponent<Rigidbody>().AddForce((obj.transform.position - transform.position) * power, ForceMode.VelocityChange);
        }
    }

    public void changeSpeed(float newSpeed)
    {
        speed = newSpeed;
        textSpeed.text = "Speed: " + newSpeed;
    }

    public void resetPlayer()
    {
        changeSpeed(10f);
    }
}
