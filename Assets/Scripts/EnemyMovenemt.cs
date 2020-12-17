using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovenemt : MonoBehaviour
{
	public Squad squad;
	public WeaponScript ws;
	bool inPlace;

	float speed;

	GameObject moveOn;

	Vector3 destination;
	Rigidbody rb;


	void Start()
	{
		rb = GetComponent<Rigidbody>();
		speed = GetComponent<Vehichle>().speed;
		inPlace = true;
		if (transform.childCount < 2)
		{
			ws = null;
		}
		else
		{
			ws = transform.GetChild(1).GetComponent<WeaponScript>();
		}
	}

	void FixedUpdate()
	{
		
		Transform tg = ws.GetTarget();
		if (tg == null)
		{
			//Debug.Log("Nie ma Targetu");
			SetDestination(GetClosest());
		}
		else
		{
			SetDestination(tg.gameObject);
		}

		if (!inPlace)
		{
			Move();
		}
	}

	GameObject GetClosest()
	{
		GameObject closest = squad.v1;
		foreach (GameObject go in squad.GetSquad())
		{
			if (Vector3.Distance(go.transform.position, transform.position) <
				Vector3.Distance(closest.transform.position, transform.position))
			{
				closest = go;
			}
		}

		//Debug.Log(closest.gameObject.name + " is closest");

		return closest;
	}

	void SetDestination(GameObject target)
	{
		//Debug.Log("target " + target + " Vector " + (target.transform.localPosition - transform.position));
		inPlace = false;

		//destination = new Vector3(target.transform.localPosition.x, 2, target.transform.position.z);
		if (moveOn == null)
		{
			moveOn = target;
			RandomizeFor(moveOn);
		}
		else
		{
			if (moveOn != target)
			{
				moveOn = target;
				RandomizeFor(moveOn);
			}
		}

	}

	void OnDrawGizmos()
	{
		Gizmos.color = Color.yellow;
		Gizmos.DrawSphere(destination, 3);
	}

	void RandomizeFor(GameObject target)
	{
		
		//Debug.Log("Destination: " + (destination-transform.position));

		Vector3 targetDir = target.transform.position - transform.position;
		Vector3 forward = transform.forward;

		float angle = Vector3.SignedAngle(targetDir, forward, Vector3.up);

		//Debug.Log("agl btw this and " + target.gameObject.name + " : " + angle);
		//Debug.Log("QUATER " + FindQuater(angle));

		float randomAngle = 0;

		switch (FindQuater(angle))
		{
			case 1:  randomAngle = Random.Range(0, 90);
				break;
			case 2:
				randomAngle = Random.Range(90, 180);
				break;
			case 3:
				randomAngle = Random.Range(180, 270);
				break;
			case 4:
				randomAngle = Random.Range(270, 360);
				break;
		}

		randomAngle*=Mathf.Deg2Rad;
		float r = GetComponentInChildren<Radius>().value;
		r = r - Random.Range(0, r * 1 / 2);
		destination = new Vector3(target.transform.localPosition.x+Mathf.Cos(randomAngle)*r, 3.2f, target.transform.position.z+Mathf.Sin(randomAngle)*r);
	}

	int FindQuater(float angle)
	{
		if (angle > 90 && angle <= 180) return 1;
		else if (angle > -180 && angle <= -90) return 2;
		else if (angle > -90 && angle <= 0) return 3;
		else if (angle > 0 && angle <= 90) return 4;
		else return 0;
	}
	void Move()
	{

		Vector3 direction = (destination - transform.position).normalized * speed;
		rb.velocity = direction;


		if (Vector3.Distance(destination, transform.position) < 5)
		{
			inPlace = true;
			rb.velocity = Vector3.zero;
		}
	}
}
