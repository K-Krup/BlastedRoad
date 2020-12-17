using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraScript : MonoBehaviour
{
	public float speed;
	float zDisplacement;
	void Start()
	{

	}


	void FixedUpdate()
	{
		zDisplacement= 0; 

		 if (transform.localPosition.z <= 100 && Input.GetAxis("Vertical") > 0)
		{
			zDisplacement = Input.GetAxis("Vertical") * speed * Time.deltaTime;
		}
		else if (transform.localPosition.z >= 100 && Input.GetAxis("Vertical") < 0)
		{
			zDisplacement = Input.GetAxis("Vertical") * speed * Time.deltaTime;
		}
		else if(Mathf.Abs(transform.localPosition.z)<=100)
		{
			zDisplacement = Input.GetAxis("Vertical") * speed * Time.deltaTime;
		}

		transform.position += new Vector3(0, 0, zDisplacement);
	}
}
