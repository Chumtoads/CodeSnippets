using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	//variables
	Animator anim;
	SpriteRenderer sr;

	//free or-operator ||

	public float MoveSpeed = 4.5f;
	public Transform groundCheckIs;
	public float groundCheckRadius;
	public LayerMask whatIsGround;
	public bool grounded;
	public bool picked;

	Rigidbody2D body;
	GameObject targetToFollow;


	void Start () {
		anim = GetComponent<Animator> ();
		body = GetComponent<Rigidbody2D> ();
		targetToFollow = GameObject.Find("Sprite");
		sr = GetComponent<SpriteRenderer> ();

	}
	
	void Update () 
	{
		grounded = Physics2D.OverlapCircle (groundCheckIs.position, groundCheckRadius, whatIsGround);

		movement ();

		if (grounded == false) {
			anim.Play ("falling");
		}
	}


	void movement () 
	{
		if (grounded == true && picked == false) {
			if (Input.GetAxisRaw ("Horizontal") > 0) {
				transform.Translate (Vector2.right * MoveSpeed * Time.deltaTime);
				transform.eulerAngles = new Vector2 (0, 0);
				anim.Play ("run");
			} else if (Input.GetAxisRaw ("Horizontal") < 0) {
				transform.Translate (Vector2.right * MoveSpeed * Time.deltaTime);
				transform.eulerAngles = new Vector2 (0, 180);
				anim.Play ("run");
			} else {
				anim.Play ("idle");
			}
		}
		if (picked == true) {
			gameObject.transform.position = Vector3.MoveTowards (gameObject.transform.position, targetToFollow.transform.position, 10 * Time.deltaTime);
			sr.enabled = false;
//			anim.Play ("falling");
		} else {
			sr.enabled = true;
		}
	}
}