using UnityEngine;

/// <summary>
/// Drag a Rigidbody2D by selecting one of its colliders by pressing the mouse down.
/// When the collider is selected, add a TargetJoint2D.
/// While the mouse is moving, continually set the target to the mouse position.
/// When the mouse is released, the TargetJoint2D is deleted.`
/// </summary>
public class TargetDragScript : MonoBehaviour
{
	
    
	public float damping = 1f;
    
	public float frequency = 5f;

	private TargetJoint2D targetJoint;

	void Update ()
	{
        var mousePos = Input.mousePosition;
        mousePos.z = 10;
        // Calculate the world position for the mouse.
        var worldPos = Camera.main.ScreenToWorldPoint (mousePos);

        if (Input.GetMouseButtonDown (0))
		{
            // Fetch the first collider.
            // NOTE: We could do this for multiple colliders.
            RaycastHit2D rayHit = Physics2D.GetRayIntersection(Camera.main.ScreenPointToRay(Input.mousePosition));
            Debug.Log(rayHit.collider);
            var collider = rayHit.collider;
            if (!collider)
				return;

			// Fetch the collider body.
			var body = collider.attachedRigidbody;
			if (!body)
				return;

            // Add a target joint to the Rigidbody2D GameObject.
            targetJoint = body.gameObject.AddComponent<TargetJoint2D> ();
            targetJoint.dampingRatio = damping;
            targetJoint.frequency = frequency;

            // Attach the anchor to the local-point where we clicked.
            targetJoint.anchor = targetJoint.transform.InverseTransformPoint (worldPos);		
		}
		else if (Input.GetMouseButtonUp (0))
		{
			Destroy (targetJoint);
            targetJoint = null;
			return;
		}

		// Update the joint target.
		if (targetJoint)
		{
            targetJoint.target = worldPos;
		}
	}
}
