using UnityEngine;
using System.Collections;

public class Darkness : MonoBehaviour {

	public GameObject SpriteIs;
	public GameObject PlayerIs;

	public GameObject[] Wards; 
	public float SafeDistance;
	//public GameObject Safety;

	public GameObject monsterSpawn;
	public GameObject lurkerprefab;

	private float IsScared;
	private float NightmareSpawnRate;
	private float rngFrequency = 15f;

	
	void Start()
	{
		IsScared = 0f;
		NightmareSpawnRate = 0f;
	}

	void Update ()
	{
		Wards = GameObject.FindGameObjectsWithTag("Ward");
		if (Vector3.Distance(SpriteIs.transform.position, PlayerIs.transform.position) < SafeDistance)
		{
			Light();
		}
		else
		{
			Dark();
		}
		
		if (IsScared >= 100f)
		{
			PlayerIsScared();
		}
		foreach (GameObject ward in Wards) 
		{
			if(Vector3.Distance(ward.transform.position, PlayerIs.transform.position) < SafeDistance)
			{
				IsScared -=1f;
				NightmareSpawnRate = 0f;
			}
		}
	}

	void PlayerIsScared(){
		NightmareSpawnRate += Time.deltaTime;

		if (Mathf.Floor (NightmareSpawnRate) >= rngFrequency) {
			float possibility = Mathf.Floor(Random.Range(0,100));
			if(NightmareSpawnRate>possibility)
			{
				SpawnLurker();
			}
			print (possibility);
			rngFrequency +=5;
		}
	}

	void Light(){
		IsScared -= Time.deltaTime*10;
		if (IsScared == 0) 
		{
			IsScared = Mathf.Abs(0);
		}
		//print ("InLight");
	}

	void Dark(){
		IsScared += Time.deltaTime*10;
		//print ("InDark");
	}

	void SpawnLurker(){
		GameObject lurker = Instantiate (lurkerprefab, monsterSpawn.transform.position, Quaternion.identity) as GameObject;
		print ("Lurker has spawned");
	}

	/*void OnTriggerStay (Collision other){
		if (other.gameObject.name == "SafeDistance") {
			StartCoroutine()
			{
				Light();
			}
		}
	}*/
}
