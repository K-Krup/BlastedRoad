using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldSpeed : MonoBehaviour
{
	public float speed;
	private Vector3 constantVelocity;
	void Start()
	{
		constantVelocity = new Vector3(0, 0, speed) * Time.deltaTime;
	}

	void LateUpdate()
	{
		transform.position += constantVelocity;
	}
}
