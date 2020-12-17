using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FieldGameManager : MonoBehaviour
{
	public int levelLength;
	public int difficilty;
	public float waveFreqence;
	public HangarGameManager hgm;

	public GameObject[] crew;
	public GameObject road, desert, enemy, squad , nonStaticWorld, turret, rocketlaunch;

	public float enemyCount;

	private static FieldGameManager instance;

	bool passed=false; 

	private void Awake()
	{
		if (instance == null)
			instance = gameObject.GetComponent<FieldGameManager>();
		else
			Destroy(gameObject);
	}

	public static FieldGameManager GetInstance()
	{
		return instance;
	}

	void Start()
    {
		SpawnSquad();


		BuildMap();
		GenerateEnemies();
    }

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			SceneManager.LoadScene("Hangar");
		}

	

		if (enemyCount == 0)
		{
			if (!passed)
			{
				Squad.GetInstance().resultScreen.text = "MISSION COMPLETE";
				Squad.GetInstance().tires += 500;
				passed = true;
				ReturnToHangar();
			}
		}
	}

	IEnumerator ReturnToHangar()
	{
		yield return new WaitForSeconds(3f);
		SceneManager.LoadScene("Hangar");
	}

	public void GameOver()
	{
		Squad.GetInstance().resultScreen.text = "GAME OVER";
		ReturnToHangar();
	}

	void SpawnSquad()
	{
		Instantiate(squad, new Vector3(0, 4.5f, 0), Quaternion.identity);
		if (squad.GetComponent<Squad>().v1 != null)
		{
			Instantiate(squad.GetComponent<Squad>().v1, new Vector3(-22, 3.2f, 15), Quaternion.identity);
		}

		if (squad.GetComponent<Squad>().v2 != null)
		{
			Instantiate(squad.GetComponent<Squad>().v2, new Vector3(22, 3.2f, 15), Quaternion.identity);
		}

		if (squad.GetComponent<Squad>().v3 != null)
		{
			Instantiate(squad.GetComponent<Squad>().v3, new Vector3(-22, 3.2f, -15), Quaternion.identity);
		}

		if (squad.GetComponent<Squad>().v4 != null)
		{
			Instantiate(squad.GetComponent<Squad>().v4, new Vector3(22, 3.2f, -15), Quaternion.identity);
		}
	}

	void BuildMap()
	{
		for(int i =0; i<levelLength; i++)
		{
			Instantiate(desert, new Vector3(-150, -1, i * 200), Quaternion.identity, nonStaticWorld.transform);
			Instantiate(road, new Vector3(0, 0, i * 200), Quaternion.identity, nonStaticWorld.transform);
			Instantiate(desert, new Vector3(150, -1, i * 200), Quaternion.identity, nonStaticWorld.transform);
		}
	}



	void GenerateEnemies()
	{
		enemyCount = 1;

		for (int j = 1; j <= 3; j++)
		{
			for (int i = 0; i < difficilty * 2; i++)
			{
				SpawnEnemyAtRange(300*j,100*j);
				if (Random.Range(0, 3) > 2) SpawnEnemyAtRange(300 * j, 100*j); 
			}

		}
		enemyCount--;
	}


    void SpawnEnemyAtRange(float maxRange, float minRange)
	{
		float x = Random.Range(-1 * maxRange, maxRange);

		if (x < 0 && x > -1*minRange)
		{
			x = Random.Range(-1 * maxRange, -1 * minRange);
		}
		if (x > 0 && x < minRange)
		{
			x = Random.Range(minRange, 0);
		}

		float z = Random.Range(-1 * maxRange, maxRange);

		if (z < 0 && z > -1*minRange)
		{
			z = Random.Range(-1 * maxRange, -1*minRange);
		}
		if (z > 0 && z < minRange)
		{
			z = Random.Range(minRange, maxRange);
		}

		GameObject e = Instantiate(enemy, new Vector3(x, 3.2f, z), Quaternion.identity);
		
		if (Random.value >= 0.5)
		{
			Instantiate(turret, new Vector3(x, 3f ,z), Quaternion.identity, e.transform);
		}
		else
		{
			Instantiate(rocketlaunch, new Vector3(x, 3.5f, z), Quaternion.identity, e.transform);
		}

		enemyCount++;
	}
}
