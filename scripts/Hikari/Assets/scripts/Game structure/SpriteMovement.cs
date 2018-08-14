using UnityEngine;
using System.Collections;

public class SpriteMovement : MonoBehaviour {

	private Vector3 mouseposition;
	public float stopDistance;
	public float movespeed = 1f;
	public Vector3 cursorPosi;

	Animator spriteanim;

	void Start() {
		spriteanim = GetComponent<Animator> ();
	}

	void Update () {

		//sprite movement, sprite will follow the cursor.

		cursorPosi = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		mouseposition = Input.mousePosition;
		mouseposition = Camera.main.ScreenToWorldPoint (mouseposition);

		if (Vector3.Distance (cursorPosi, gameObject.transform.position) >= stopDistance) {
			transform.position = Vector2.Lerp (transform.position, mouseposition, movespeed * Time.deltaTime);
		}
		if (cursorPosi.x >= gameObject.transform.position.x) {
			transform.eulerAngles = new Vector2 (0, 0);
		} 

		else if (cursorPosi.x <= gameObject.transform.position.x) {
			transform.eulerAngles = new Vector2(0, 180);
		}
	}
}