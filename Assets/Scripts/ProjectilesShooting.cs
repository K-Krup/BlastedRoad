using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectilesShooting : MonoBehaviour
{
	public GameObject projectile;
	public Transform firePiont;
	Transform target;

	public float damage;
	public float fireRate;
	public float projectileSpeed;
	float nextShot;

	void Start()
	{
		
		
	}

	void Update()
	{
		target = GetComponent<WeaponScript>().GetTarget();
	
		if (Time.time >= nextShot && target != null)
		{
			nextShot = Time.time + (5f / fireRate);
			Shoot();
		}
	}

	void AplySettings()
	{
		Vehichle v = GetComponent<WeaponScript>().transform.parent.GetComponent<Vehichle>();
		if (v != null)
		{
			Rocket rocket = projectile.GetComponent<Rocket>();
			if (rocket != null)
			{
				rocket.type = v.type;
				rocket.damage = damage;
				rocket.speed = projectileSpeed;
			}

		}
	}
	void Shoot()
	{
		AplySettings();
		Instantiate(projectile, firePiont.position, firePiont.rotation);
	}
}

