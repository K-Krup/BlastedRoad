using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KineticShooting : MonoBehaviour
{
	public Transform firePiont;
	Transform target;

	//public float range;
	
	public float damage;
	public float fireRate;
	float nextShot = 0;

	LineRenderer laserLineRenderer;

	void Start()
	{
		laserLineRenderer = GetComponent<LineRenderer>();
		laserLineRenderer.enabled = false;
	}

	// Update is called once per frame
	void Update()
    {
		target = GetComponent<WeaponScript>().GetTarget();
		if (Time.time >= nextShot && target!=null)
		{
			nextShot = Time.time + (5f / fireRate);
			Shoot();
		}
	}



	void Shoot()
	{
		float chanceDamage = damage + Random.Range(-2, 2);
		
		if (Physics.Raycast(firePiont.position, (target.position - firePiont.position), out RaycastHit hit, 300))
		{
			Vehichle v = hit.transform.GetComponent<Vehichle>();
			if (v == null) return;

			if (v.type != this.transform.parent.gameObject.GetComponent<Vehichle>().type)
			{
				v.TakeDamage(chanceDamage);

				laserLineRenderer.enabled = true;
				laserLineRenderer.SetPosition(0, firePiont.position);
				laserLineRenderer.SetPosition(1, target.position);

				StartCoroutine(TurnLaserOffCoroutine());
				

			}

		}
	}

	IEnumerator TurnLaserOffCoroutine()
	{
		yield return new WaitForSeconds(0.1f);
		laserLineRenderer.enabled = false;
	}


}
