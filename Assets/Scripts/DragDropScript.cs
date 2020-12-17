using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDropScript : MonoBehaviour
{
    //Initialize Variables
    GameObject getTarget;
	GameObject targetPlane;

	bool isMouseDragging;

	Vector3 offsetValue;
	Vector3 positionOfScreen;
	LayerMask layerMask;

	public HangarGameManager gm;

	// Use this for initialization
	void Start()
	{
		layerMask = LayerMask.GetMask("Vehichle");
	}

	void Update()
	{

		//Mouse Button Press Down
		if (Input.GetMouseButtonDown(0))
		{
			RaycastHit hitInfo;
			getTarget = ReturnClickedObject(out hitInfo);

			if (getTarget != null)
			{
				targetPlane = UponPlane();
				//planeRef = targetPlane
				isMouseDragging = true;
				
				//Converting world position to screen position.
				positionOfScreen = Camera.main.WorldToScreenPoint(getTarget.transform.position);
				offsetValue = getTarget.transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, positionOfScreen.z));
			}
		}

		//Mouse Button Up
		if (Input.GetMouseButtonUp(0))
		{
			isMouseDragging = false;
			GameObject plane = UponPlane();
			if (plane != null)
			{
				if (plane.GetComponent<Plane>().v!=null)
				{
					targetPlane.GetComponent<Plane>().v.transform.position = plane.transform.position + new Vector3(0, 3.2f, 0);
					plane.GetComponent<Plane>().v.transform.position = targetPlane.transform.position+new Vector3(0, 3.2f, 0);

					GameObject tmp = targetPlane.GetComponent<Plane>().v;


					targetPlane.GetComponent<Plane>().v = plane.GetComponent<Plane>().v;
					plane.GetComponent<Plane>().v = tmp; 

				}
				else
				{
					getTarget.transform.position = plane.transform.position + new Vector3(0, 3.2f, 0);
					plane.GetComponent<Plane>().v = targetPlane.GetComponent<Plane>().v;
					if (plane!=targetPlane) targetPlane.GetComponent<Plane>().v = null;
					//Debug.Log("name " + plane.gameObject.name);
				}
			}
			else
			{
				if(getTarget!=null)
					getTarget.transform.position = targetPlane.transform.position + new Vector3(0, 3.2f, 0);
			}
		}
		//Is mouse Moving
		if (isMouseDragging)
		{
			//tracking mouse position.
			Vector3 currentScreenSpace = new Vector3(Input.mousePosition.x, Input.mousePosition.y, positionOfScreen.z);

			//converting screen position to world position with offset changes.
			Vector3 currentPosition = Camera.main.ScreenToWorldPoint(currentScreenSpace) + offsetValue;

			//It will update target gameobject's current postion.
			getTarget.transform.position = currentPosition;
		}


	}

	//Method to Return Clicked Object
	GameObject ReturnClickedObject(out RaycastHit hit)
	{
		GameObject target = null;
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		if (Physics.Raycast(ray.origin, ray.direction * 10, out hit, 200))
		{
			target = hit.collider.gameObject;
			if (target.tag == "Vehichle") return target;
		}
		return null;
	}

	GameObject UponPlane()
	{
		if (getTarget == null) return null;

		foreach (GameObject g in gm.planes)
		{
			if (Mathf.Abs(getTarget.transform.position.x - g.transform.position.x) < 10
			&& Mathf.Abs(getTarget.transform.position.z - g.transform.position.z) < 10)
			{
				return g;
			}
				
		}
		return null;
	}

}

