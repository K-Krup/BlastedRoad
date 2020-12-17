using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Radius : MonoBehaviour
{
	Transform detected;
	public float value;

	void Start()
	{
		GetComponent<MeshRenderer>().enabled = false;
	}


	public Transform GetDetected()
	{
		return detected;
	}

	bool IsHostile(GameObject go)
	{
		Vehichle v = go.GetComponent<Vehichle>();
		if (v != null)
		{
			return (v.type != transform.parent.transform.parent.GetComponent<Vehichle>().type);
		}
		else return false;
	}

	private void OnTriggerEnter(Collider col)
	{
		if (IsHostile(col.gameObject))
		{
			if (detected==null)
			{
				detected = col.gameObject.transform;
			}
		}
	}
	private void OnTriggerStay(Collider col)
	{
		if (IsHostile(col.gameObject))
		{
			if (detected == null)
			{
				detected = col.gameObject.transform;
			}
			else
			{
				if (Vector3.Distance(col.gameObject.transform.position, transform.position) <
					Vector3.Distance(detected.transform.position, transform.position))
				{
					detected = col.gameObject.transform;

				}
			}
		}
	}
	private void OnTriggerExit(Collider col)
	{
		detected = null;
	}
}