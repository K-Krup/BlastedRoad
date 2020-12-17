using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
	public float speed;
	public float damage;
	public Vehichle.VType type;

	public float destroyDelay = 3.5f;

	void Start()
	{
		WaitAndDestroy();
	}

	void Update()
	{
		GetComponent<Rigidbody>().velocity =transform.forward*speed*Time.deltaTime;
		//Debug.Log("Speed " + speed);
	}

	IEnumerator WaitAndDestroy()
	{
		yield return new WaitForSeconds(destroyDelay);
		Destroy(gameObject);
	}

	private void OnTriggerEnter(Collider col)
	{
		Vehichle v = col.GetComponent<Vehichle>();

		if (v == null)
			return;

		if (v.type != type)
		{
			Destroy(gameObject);
		}
	}
}
