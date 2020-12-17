using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponScript : MonoBehaviour
{
	Transform target;

	public Radius radius;
	public float rotationSpeed = 7f;

	void Awake()
	{
		radius = transform.GetChild(0).GetComponent<Radius>();
	}
	
	public Transform GetTarget()
	{
		return target;
		
	}

	void Update()
	{
		target = radius.GetDetected();
		//Debug.Log("target to " + target);
		if (target != null)
		{
			// Determine which direction to rotate towards
			Vector3 targetDirection = target.position - transform.position;
			targetDirection.y = 0;
			// The step size is equal to speed times frame time.
			float singleStep = rotationSpeed * Time.deltaTime;

			// Rotate the forward vector towards the target direction by one step
			Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, singleStep, 0.0f);

			// Draw a ray pointing at our target in
			//Debug.DrawRay(transform.position, newDirection, Color.red);

			// Calculate a rotation a step closer to the target and applies rotation to this object
			transform.rotation = Quaternion.LookRotation(newDirection);



		}
		
	}

}
