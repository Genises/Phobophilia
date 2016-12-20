using UnityEngine;
using System.Collections;

// Controls camera movement
public class CameraController : MonoBehaviour
{
	public float fMult = 1; // Used to set the magnitude of the player's velocity (mainly exists for testing purposes)
    private Rigidbody rBody;
    private float yVel; // Used to keep y-velocity constant

    void Start ()
    {
        rBody = GetComponent<Rigidbody>();
    }

	// Move the camera in the appropriate direction, as specified by the string input
	public void Move (string direction)
	{
        yVel = rBody.velocity.y; // Store the initial y-velocity

        if (direction == "Forward")
            rBody.velocity =  new Vector3(0, 0, 1) * fMult;
        else if (direction == "Backward")
            rBody.velocity = new Vector3(0, 0, -1) * fMult;
        else if (direction == "Right")
            rBody.velocity = new Vector3(1, 0, 0) * fMult;
        else if (direction == "Left")
            rBody.velocity = new Vector3(-1, 0, 0) * fMult;
        else if (direction == "Forward and Right")
            rBody.velocity = new Vector3(1, 0, 1) * fMult;
        else if (direction == "Forward and Left")
            rBody.velocity = new Vector3(-1, 0, 1) * fMult;
        else if (direction == "Backward and Right")
            rBody.velocity = new Vector3(1, 0, -1) * fMult;
        else if (direction == "Backward and Left")
            rBody.velocity = new Vector3(-1, 0, -1) * fMult;

		// Set the camera's new velocity with the x and z values and the old y value
        rBody.velocity = new Vector3(rBody.velocity.x, yVel, rBody.velocity.z);
	}

}
