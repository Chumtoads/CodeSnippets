using UnityEngine;
using System.Collections;

public class Carrying : MonoBehaviour {

	Animator anim2;

	public float endurance = 100f;					//Endurance will float between 0 and 100. If value reaches 50, play "tiredcarry" - animation. If 0, cease function carrying.

	public GameObject player;
	public GameObject sprite;
	
	private bool carryChecker = false;

	void Start () {
		anim2 = GetComponent<Animator> ();
	}

	void Update () {

		if (Vector3.Distance (player.transform.position, sprite.transform.position) < 4) {
			carryChecker = true;
		} else if (Vector3.Distance (player.transform.position, sprite.transform.position) > 4) {
			carryChecker = false;
		}

		if (Input.GetMouseButton (1) && carryChecker == true) {
			Endurance();
			anim2.Play("spritecarry");
			player.GetComponent<PlayerMovement>().picked = true;
			player.GetComponent<Rigidbody2D>().isKinematic = true;	
		} else {
			player.GetComponent<PlayerMovement>().picked = false;
			player.GetComponent<Rigidbody2D>().isKinematic = false;
			anim2.Play("spritefloat");
		}
	}

	void Endurance (){

		if (endurance <= 0f) {
			carryChecker = true;
		}

		if (endurance == 0f) {
			carryChecker = false;
		}

		if (carryChecker == true) {
			endurance -= Time.deltaTime;
		} 
	}
}
