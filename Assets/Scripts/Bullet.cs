using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
	public float bulletSpeed=200;
	public float damage;
	private Rigidbody rb;

	void Start()
	{
		rb = GetComponent<Rigidbody>();
	}

	void Update()
	{
		rb.velocity = transform.forward * bulletSpeed * Time.deltaTime;
	}

	private void OnBecameInvisible()
	{
		Destroy(gameObject);
	}
}
