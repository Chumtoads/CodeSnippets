using UnityEngine;
using System.Collections;

public class SpriteAttack : MonoBehaviour {

	public Rigidbody2D wardprefab;
	public float wardtimer = 1f;
	public GameObject ward;

	void Update () {


		if (Input.GetMouseButtonDown(0)) 
		{
			spriteAttack();
		}
	}


	void spriteAttack()
	{
		ward = Instantiate (wardprefab, transform.position, Quaternion.identity) as GameObject;
	}

}