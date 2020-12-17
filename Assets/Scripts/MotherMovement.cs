using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MotherMovement : MonoBehaviour
{
	Rigidbody rb;
	public float speed;
	float xDisplacement;
    void Start()
    {
        rb= GetComponent<Rigidbody>();
    }

   
    void FixedUpdate()
    {
		xDisplacement = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
		rb.velocity = new Vector3(xDisplacement, rb.velocity.y, rb.velocity.z);
	}
}
