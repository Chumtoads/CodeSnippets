using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySimple : MonoBehaviour {

	public int EnemySpeed = 3;
	public int xMoveDirection = 1;
	public bool isGrounded;
	public PlayerHealth playerHealthRef;

	private bool facingRight = false;

	public int EnemyHealth = 3;

	// Update is called once per frame
	void Update () {
		//Enemy Movement
		if(isGrounded == true){
			RaycastHit2D hit = Physics2D.Raycast (transform.position, new Vector2 (xMoveDirection, 0));
			gameObject.GetComponent<Rigidbody2D> ().velocity = new Vector2 (xMoveDirection, 0) * EnemySpeed;
			if (hit.distance < 0.7f) {
				Flip ();

				//Player gets hurt from touch
				if (hit.collider.tag == "Player") {
					playerHealthRef.GetComponent<PlayerHealth> ().TakeDamage ();
				}
			}
		}
			
		//Animation
		if (xMoveDirection < 0.0f && facingRight == false) {
			FlipEnemy ();
		} else if (xMoveDirection > 0.0f && facingRight == true) {
			FlipEnemy ();
		}

		//Dying
		if(EnemyHealth <= 0){
			Destroy (gameObject);
		}
	}

	void Flip (){
		//Enemy Switch Direction
		if (xMoveDirection > 0) {
			xMoveDirection = -1;
		} else {
			xMoveDirection = 1;
		}
	}

	void OnCollisionEnter2D (Collision2D col){
		//Enemy groundcheck
		//Debug.Log ("Enemy is on Ground");
		if (col.gameObject.tag == "Ground") {
			isGrounded = true;
		}
	}

	void FlipEnemy (){
		facingRight = !facingRight;
		Vector2 localScale = gameObject.transform.localScale;
		localScale.x *= -1;
		transform.localScale = localScale;
	}

	public void EnemyTakeDamage(int damage){
		EnemyHealth -= damage;
		Debug.Log ("Hit the enemy");
	}
}