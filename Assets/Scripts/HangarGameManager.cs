using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HangarGameManager : MonoBehaviour
{
	public GameObject[] planes;
	public GameObject squad;
	
	public DragDropScript dds;

	public FieldGameManager fgm;

	void Start()
    {

		SpawnSquad();

	}

	void SpawnSquad()
	{
		Instantiate(squad,  new Vector3(0,4.5f,0), Quaternion.identity);
		if (squad.GetComponent<Squad>().v1 != null)
		{
			Instantiate(squad.GetComponent<Squad>().v1, new Vector3(-22, 3.2f, 15), Quaternion.identity);
			planes[0].GetComponent<Plane>().v = squad.GetComponent<Squad>().v1;
		}

		if (squad.GetComponent<Squad>().v2 != null)
		{
			Instantiate(squad.GetComponent<Squad>().v2, new Vector3(22, 3.2f, 15), Quaternion.identity);
			planes[1].GetComponent<Plane>().v = squad.GetComponent<Squad>().v2;
		}

		if (squad.GetComponent<Squad>().v3 != null)
		{
			Instantiate(squad.GetComponent<Squad>().v3, new Vector3(-22, 3.2f, -15), Quaternion.identity);
			planes[2].GetComponent<Plane>().v = squad.GetComponent<Squad>().v3;
		}

		if (squad.GetComponent<Squad>().v4 != null)
		{
			Instantiate(squad.GetComponent<Squad>().v4, new Vector3(22, 3.2f, -15), Quaternion.identity);
			planes[3].GetComponent<Plane>().v = squad.GetComponent<Squad>().v4;
		}
	}

    public void Pack()
	{

		if (planes[0].GetComponent<Plane>().v!= null) squad.GetComponent<Squad>().v1 = planes[0].GetComponent<Plane>().v;
		else squad.GetComponent<Squad>().v1 = null;

		if (planes[1].GetComponent<Plane>().v != null) squad.GetComponent<Squad>().v2 = planes[1].GetComponent<Plane>().v;
		else squad.GetComponent<Squad>().v2 = null;

		if (planes[2].GetComponent<Plane>().v != null) squad.GetComponent<Squad>().v3 = planes[2].GetComponent<Plane>().v;
		else squad.GetComponent<Squad>().v3 = null;

		if (planes[3].GetComponent<Plane>().v != null) squad.GetComponent<Squad>().v4 = planes[3].GetComponent<Plane>().v;
		else squad.GetComponent<Squad>().v4 = null;
	}

    void Update()
    {
		if (Input.GetKeyDown("space"))
		{
			Pack();
			SceneManager.LoadScene("FieldScene");
		}
		if (Input.GetKey("escape"))
		{
			Application.Quit();
		}
	}
}
