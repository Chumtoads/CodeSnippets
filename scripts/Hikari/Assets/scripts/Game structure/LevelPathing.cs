using UnityEngine;
using System.Collections;

public class LevelPathing : MonoBehaviour {
	
	public string newLevel;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	

	}



	void OnTriggerEnter (Collider col)
	{
		Debug.Log ("Levelchange");

		
		if (col.gameObject.tag == "Player") 
		{
			
			Debug.Log ("I'll go next to " + newLevel);

			Application.LoadLevel("prototype2");
		}
	}
}
