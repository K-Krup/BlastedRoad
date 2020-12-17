using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleSelector : MonoBehaviour
{
	GameObject previous;
	public GameObject squad;


	void Start()
	{
	}

	void Update()
	{

		if (Input.GetMouseButtonDown(0))
		{
			MouseSelection();
		}

		if (Input.anyKey)
		{
			
			switch (Input.inputString)
			{
				case "1":
					SelectVehichle(squad.GetComponent<Squad>().v1);
					break;
				case "2":
					SelectVehichle(squad.GetComponent<Squad>().v2);
					break;
				case "3":
					SelectVehichle(squad.GetComponent<Squad>().v3);
					break;
				case "4":
					SelectVehichle(squad.GetComponent<Squad>().v4);
					break;
			}
		}
	}

	void MouseSelection()
	{
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		RaycastHit hit;

		if (Physics.Raycast(ray, out hit, 300))
		{

			GameObject go = hit.collider.gameObject;

			//Debug.Log("Ray hit " + go.gameObject.tag);

			if (go.tag == "Vehichle")
			{
				CarsScript cs = go.GetComponent<CarsScript>();
				if (cs != null)
				{
					SelectVehichle(go);
				}
				else
				{
					Clear();
				}
			}
			else
			{
				Clear();
			}

		}
	}

	void SelectVehichle(GameObject go)
	{
		if (go == null) return;

		if (previous != null)
		{
			previous.GetComponent<CarsScript>().DeSelect();
		}
		go.GetComponent<CarsScript>().Select();
		previous = go;
	}

	void Clear()
	{
		if (previous != null)
		{
			previous.GetComponent<CarsScript>().DeSelect();
		}
		previous = null;
	}
}
