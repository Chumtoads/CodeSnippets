using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlayer : MonoBehaviour {

	public float speed = 2f;
	public float sensitivity = 2f;
	public float clampUp = -60f;
	public float ClampDown = 60f;
	public float jumpDistance = 5f;
	CharacterController player;

	public GameObject eyes;

	float moveFB;
	float moveLR;

	float rotX;
	float rotY;
	float verticalVelocity;
	bool canJump;

	// Use this for initialization
	void Start () {

		player = GetComponent<CharacterController> ();

	}
	
	// Update is called once per frame
	void Update () {

		//Mouse Movement
		moveFB = Input.GetAxis ("Vertical") * speed;
		moveLR = Input.GetAxis ("Horizontal") * speed;

		rotX = Input.GetAxis ("Mouse X") * sensitivity;
		rotY -= Input.GetAxis ("Mouse Y") * sensitivity;

		rotY = Mathf.Clamp (rotY, clampUp, ClampDown);

		Vector3 movement = new Vector3 (moveLR, verticalVelocity, moveFB);
		transform.Rotate (0, rotX, 0);
		eyes.transform.localRotation = Quaternion.Euler(rotY, 0, 0);
		//eyes.transform.Rotate (-rotY, 0, 0);

		//Player Movement
		movement = transform.rotation * movement;
		player.Move (movement * Time.deltaTime);


		//Player Jumping
		if (canJump == true) {
			if (Input.GetButtonDown ("Jump")) {
				verticalVelocity += jumpDistance;
				canJump = false;
			}
		}
	}

	void FixedUpdate(){

		if (canJump == false) {
			if (player.isGrounded == true) {
				canJump = true;
			}
		}

			if (player.isGrounded == false) {
				verticalVelocity += Physics.gravity.y * Time.deltaTime;
			} else {
				verticalVelocity = 0f;
		}
	}

	private void OnControllerColliderHit(ControllerColliderHit hit){
		switch (hit.gameObject.tag) {
		case "Transition":
			transform.position = hit.transform.GetChild (0).position;
			transform.rotation = hit.transform.GetChild (0).rotation;
			break;
		default:
			break;
		}
	}
}
