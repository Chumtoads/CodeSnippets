using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

	public int playerSpeed = 10;
	public int playerAirDamp = 5;

	private int originalSpeed;
	private bool facingRight = false;

	public int playerJumpPower = 11;
	private float moveX;

	public bool isGrounded;
	
	// Update is called once per frame
	void Start (){
		originalSpeed = playerSpeed;
	}

	void Update () {
		PlayerMove ();
	}

	//Controls
	void PlayerMove (){
		moveX = Input.GetAxis ("Horizontal");
		if (Input.GetButtonDown ("Jump") && isGrounded == true) {
			Jump ();
		}

		if (isGrounded == false) {
			playerSpeed = playerAirDamp;
		} else if (isGrounded == true) {
			playerSpeed = originalSpeed;
		}
	
	//Animation
		//Player Direction
		if (moveX < 0.0f && facingRight == false) {
			FlipPlayer ();
		} else if (moveX > 0.0f && facingRight == true) {
			FlipPlayer ();
		}

		//Physics
		gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2 (moveX * playerSpeed, gameObject.GetComponent<Rigidbody2D>().velocity.y);
	}

	//Jumping Function
	void Jump(){
		GetComponent<Rigidbody2D> ().AddForce (Vector2.up * playerJumpPower);
		isGrounded = false;
	}

	//Flip Function
	void FlipPlayer(){
		facingRight = !facingRight;
		Vector2 localScale = gameObject.transform.localScale;
		localScale.x *= -1;
		transform.localScale = localScale;
	}

	void OnCollisionEnter2D(Collision2D col) {
		//Debug.Log ("Player is touching " + col.collider.name);
		if (col.gameObject.tag == "Ground") {
			isGrounded = true;
		}
	}
}
