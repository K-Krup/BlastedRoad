using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Squad : MonoBehaviour
{
	public GameObject[] squad;
	public HangarGameManager hgm;
	public GameObject v1, v2, v3, v4;

	public int tires;
	public Text tiresShowing;
	public Text resultScreen;

	private static Squad instance;

	private void Awake()
	{
		if (instance == null)
			instance = gameObject.GetComponent<Squad>();
		else
			Destroy(gameObject);
	}

	public static Squad GetInstance()
	{
		return instance;
	}


	void Start()
    {
		int size = 0;
		if (v1 != null) size++;
		if (v2 != null) size++;
		if (v3 != null) size++;
		if (v4 != null) size++;

		squad = new GameObject[size];

		int position = 0;
		if (v1 != null)
		{
			squad[position]=v1;
			position++;
		}
		if (v2 != null)
		{
			squad[position] = v2;
			position++;
		}
		if (v3 != null)
		{
			squad[position] = v3;
			position++;
		}
		if (v4 != null)
		{
			squad[position] = v4;
			position++;
		}
	}
	
	void Update()
	{
		tiresShowing.text = "TIRES:" + tires;
		
	}
   
    public GameObject[] GetSquad()
	{
		return squad;
	}

}
