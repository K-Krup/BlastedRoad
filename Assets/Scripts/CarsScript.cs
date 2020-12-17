using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarsScript : MonoBehaviour
{
	Rigidbody rb;
	private Vector3 targetPosition;
	
	public WeaponScript ws;

	bool positionSet = false;
	bool isSelectred = false;

	float speed;

	void Start()
	{
		rb = GetComponent<Rigidbody>();
		speed = GetComponent<Vehichle>().speed;
		if (transform.childCount == 0)
		{
			ws = null;
		}
		else
		{
			ws = transform.GetChild(0).GetComponent<WeaponScript>();
		}
	}
    void Update()
    {
		if (Input.GetMouseButtonDown(1)&&isSelectred)
		{
			SetTargetPosition();
		}
        
    }

	public void Select()
	{

		isSelectred = true;
		if (ws != null)
		{
			ws.radius.GetComponent<MeshRenderer>().enabled = true;
		}
	}

	public void DeSelect()
	{
		isSelectred = false;
		if (ws != null)
		{
			ws.radius.GetComponent<MeshRenderer>().enabled = false;
		}
	}

	void FixedUpdate()
	{
		//Debug.Log("VELOCITY " + rb.velocity+"Position Set"+ positionSet);

		if (positionSet)
		{
			//SinchronizeWithMother();
			Move();
		}
		else
		{
			rb.velocity = Vector3.zero;
		}
	}

	void SetTargetPosition()
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

		if (Physics.Raycast(ray, out RaycastHit hit, 1000))
		{
			targetPosition = hit.point;
			targetPosition.y = 3.37f;
			positionSet = true;
			Debug.Log(targetPosition);
		}
	}

	void Move()
	{
		Vector3 direction = (targetPosition - transform.position).normalized*speed;
		rb.velocity = direction;

		if (Vector3.Distance(targetPosition, transform.position)<1) 
		{
			positionSet = false;
		}
	}


}
