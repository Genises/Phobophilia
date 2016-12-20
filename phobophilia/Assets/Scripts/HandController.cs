using UnityEngine;
using System.Collections;
using System.Collections.Generic;

// Handles all player input while in-game
public class HandController : MonoBehaviour
{
	private Valve.VR.EVRButtonId triggerButton = Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger; // ID of VIVE controller's trigger button
	private Valve.VR.EVRButtonId touchPad = Valve.VR.EVRButtonId.k_EButton_SteamVR_Touchpad; // ID of VIVE controller's touchpad
	private Valve.VR.EVRButtonId gripButton = Valve.VR.EVRButtonId.k_EButton_Grip; // ID of VIVE controller's grip buttons
	private SteamVR_Controller.Device controller { get { return SteamVR_Controller.Input((int)trackedObj.index); } } // VR controller
	private SteamVR_TrackedObject trackedObj; // Used to get reference to VR controller
	private InteractableObject closestObject; // Closest object hand is overlapping with
	private InteractableObject interactingObject; // Object being held
	HashSet<InteractableObject> objectsHoveringOver = new HashSet<InteractableObject>(); // Set of all objects which can be picked up by the hands and which the hands currently are overlapping
	public GameObject player; // The player character (for crouching)
	public CameraController cam; // The VR rig representing the player
	public Camera head; // The player's head
	public GameButton restart; // The restart button (appears upon player death)

	void Start ()
	{
		trackedObj = GetComponent<SteamVR_TrackedObject>();
        Data.crouched = Data.UNCROUCHED; // Player is initially uncrouched
	}


	void Update ()
	{
		if (controller == null) // Debug message for if controller doesn't exist
		{
			Debug.Log("Controller not initialized");
			return;
		}

		// If touch pad is touched, move player in appropriate direction
		if (controller.GetTouch (touchPad))
		{
            
			Vector2 dir = controller.GetAxis (); // Get touch coordinates
			float rotation = -head.GetComponent<Transform> ().rotation.eulerAngles.y; // Rotate touch coordinates by player's y-axis rotation to ensure movement is relative to this rotation
			float sin = Mathf.Sin (rotation * Mathf.Deg2Rad);
			float cos = Mathf.Cos (rotation * Mathf.Deg2Rad);
			float tx = dir.x;
			float ty = dir.y;

			dir.x = (cos * tx) - (sin * ty);
			dir.y = (sin * tx) + (cos * ty);

			if (dir.x < -0.2)
			{
				if (dir.y < -0.2)
					cam.Move ("Backward and Left");
				else if (dir.y > 0.2)
					cam.Move ("Forward and Left");
				else
					cam.Move ("Left");

			}
			else if (dir.x > 0.2)
			{
				if (dir.y < -0.2)
					cam.Move ("Backward and Right");
				else if (dir.y > 0.2)
					cam.Move ("Forward and Right");
				else
					cam.Move ("Right");

			}
			else
			{
				if (dir.y < -0.2)
					cam.Move ("Backward");
				else if (dir.y > 0.2)
					cam.Move ("Forward");

			}

		}

		// If trigger button is pressed, pick up object
		if (controller.GetPressDown(triggerButton))
		{
			float minDistance = float.MaxValue;	
			float distance;

			// Find the nearest object the hands are currently overlapping
			foreach (InteractableObject item in objectsHoveringOver)
			{
				distance = (item.transform.position - transform.position).sqrMagnitude;

				if (distance < minDistance)
				{
					minDistance = distance;
					closestObject = item;
				}

			}

			interactingObject = closestObject; // Set this nearest object as the one being picked up by the hands
			closestObject = null; // Null out reference to closest object

			if (interactingObject)
			{
				// If nearest object is already held by opposite hand when trigger button is pressed, drop it from that hand before attaching it to this hand
                if (interactingObject.IsInteracting())
                    interactingObject.EndInteraction(this);
				
                interactingObject.BeginInteraction(this);
			}

			// If the trigger button is pressed while the Restart button is enabled, reset the scene
            if (restart.enabled == true)
                restart.Press();

		}

		// If trigger button is unpressed while hand is holding an object, drop object
		if(controller.GetPressUp(triggerButton) && interactingObject != null)
			interactingObject.EndInteraction(this);

		// If grip button is pressed while player is not crouched, move player to crouching position
        if (controller.GetPressDown(gripButton) && (Data.crouched == Data.UNCROUCHED))
        {
            Vector3 temp = player.GetComponent<Transform>().position;

            temp.y = (temp.y - 50) * Time.deltaTime;

            player.GetComponent<Transform>().position =  temp;
            Data.crouched = Data.CROUCHED;
        }

		// If grip button is released while player is crouched, move player out of crouching position
        if (controller.GetPressUp(gripButton) && (Data.crouched == Data.CROUCHED))
        {
            Vector3 temp = player.GetComponent<Transform>().position;

            temp.y = (temp.y + 50) * Time.deltaTime;

            player.GetComponent<Transform>().position = temp;
            Data.crouched = Data.UNCROUCHED;
        }

    }

	// When hand collides with interactable object, add this object to the set of all interactable objects
	private void OnTriggerEnter(Collider collider)
	{
        
        InteractableObject collidedObject = collider.GetComponent<InteractableObject>();

		// If hand collides with object which is not interactable (i.e. collidedObject = null), do nothing
        if (collidedObject)
			objectsHoveringOver.Add(collidedObject);

		
	}

	// When hand stops colliding with interactable object, remove this object from the set of all interactable objects
	private void OnTriggerExit(Collider collider)
	{
		InteractableObject collidedObject = collider.GetComponent<InteractableObject>();

		// If hand collides with object which is not interactable (i.e. collidedObject = null), do nothing
		if (collidedObject)
			objectsHoveringOver.Remove(collidedObject);

	}

}
