using UnityEngine;
using System.Collections;

// Represents objects which can be picked up and interacted with
public class InteractableObject : MonoBehaviour
{
	public float velocityFactor; // Used for calculating linear velocity of object; set to public because exact factor necessary varies from object to object
	public float rotationFactor; // Used for calculating angular velocity of object; set to public because exact factor necessary varies from object to object
	public bool currentlyInteracting;
	protected new Rigidbody rigidbody; // Object's rigidbody
	private HandController attachedHand; // Reference to hand holding the object
	private Transform interactionPoint; // Transform representing point of connection between object and hand
	private Vector3 posDelta; // Difference between hand position and object position
	private Quaternion rotationDelta; // Difference between hand rotation and object rotation
	private float angle; // Value of rotationDelta as an angle about a specific axis; used to clamp rotationDeltas which exceed 180
	private Vector3 axis; // Axis for rotation for above angle

	protected void Start ()
	{
		rigidbody = GetComponent<Rigidbody>();
		interactionPoint = new GameObject().transform; // Set default interaction point
		velocityFactor /= rigidbody.mass; // Divide velocity factor by object's mass
	}
		
	protected void Update ()
	{
		if (attachedHand && currentlyInteracting)
		{
			posDelta = attachedHand.transform.position - interactionPoint.position;
			this.rigidbody.velocity = posDelta * velocityFactor * Time.fixedDeltaTime; // Velocity increases the further the object is from the interaction point and always points toward interaction point

			rotationDelta = attachedHand.transform.rotation * Quaternion.Inverse(interactionPoint.rotation);
			rotationDelta.ToAngleAxis(out angle, out axis);

			if (angle > 180) // Clamp rotation difference angle such that it is never above 180
				angle -= 360;

			// Rotation increases the greater the object's rotation is (relative to the interaction point) and always rotates toward interaction point
			this.rigidbody.angularVelocity = (Time.fixedDeltaTime * angle * axis) * rotationFactor;
		}
	}

	public void BeginInteraction(HandController hand)
	{
		attachedHand = hand;
		interactionPoint.position = hand.transform.position;
		interactionPoint.rotation = hand.transform.rotation;
		interactionPoint.SetParent(transform, true); // Set interaction point as a child of this object
		currentlyInteracting = true; // Indicate that object is being held
	}

	public void EndInteraction(HandController hand)
	{
		if (hand == attachedHand)
		{
			attachedHand = null;  // De-attach hand by nulling out reference
			currentlyInteracting = false; // Indicate that object is no longer being held
		}

	}

	public bool IsInteracting()
	{
		return currentlyInteracting;
	}

}
