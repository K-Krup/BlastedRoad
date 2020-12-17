using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Vehichle : MonoBehaviour
{
	public float startHealth;
	float currentHealth;
	public float speed;

	float expirience;
	int level;

	public VType type;


	public Image healthBar;

	public enum VType
	{
		Ally,
		Hostile
	}

	void Start()
	{
		currentHealth = startHealth;
	}
	public void TakeDamage(float damage)
	{
		
		currentHealth -= damage;
		healthBar.fillAmount = currentHealth/startHealth;
	}

	private void OnTriggerEnter(Collider col)
	{
		Rocket rocket = col.GetComponent<Rocket>();
		if (rocket != null)
		{
			if(rocket.type!=type)
			{
				TakeDamage(rocket.damage);
			}
		}
	}

		void Update()
    {
		if (currentHealth < 0)
		{
			Die();
		}
    }

	void Die()
	{
		if (type == VType.Hostile)
		{
			Squad.GetInstance().tires += (int)((startHealth/3)+Random.Range(0, 5)*10);
			FieldGameManager.GetInstance().enemyCount--;
		}

		if (GetComponent<MotherMovement>() != null)
		{
			FieldGameManager.GetInstance().GameOver();
		}
		Destroy(gameObject);
	}
}
