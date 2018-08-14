using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {

	private float timeBtwAtk;
	public float startTimeBtwAttack;

	public Transform attackPos;
	public float attackRange;
	public LayerMask whatIsEnemies;

	public int damage;

	Animator anim;

	void Start(){
		anim = GetComponentInChildren<Animator> ();
	}

	// Update is called once per frame
	void Update () {
		if (timeBtwAtk <= 0) {

			//Attacking
			if (Input.GetMouseButton (0)) {
				Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll (attackPos.position, attackRange, whatIsEnemies);
				anim.SetTrigger ("PlayerAttack");
				//Reference Enemy receiving damage
				for (int i = 0; i < enemiesToDamage.Length; i++) {
					enemiesToDamage [i].GetComponent<EnemySimple> ().EnemyTakeDamage (damage);
				}
			} else {
				anim.SetTrigger ("PlayerIdle");
			}
			timeBtwAtk = startTimeBtwAttack;
		} else {
			timeBtwAtk -= Time.deltaTime;
		}
	}

	//Visualize Attack Range
	void OnDrawGizmosSelected(){
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere (attackPos.position, attackRange);
	}
}
