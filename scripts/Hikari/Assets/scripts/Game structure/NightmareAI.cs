using UnityEngine;
using System.Collections;

public class NightmareAI : MonoBehaviour {

	public GameObject target;						//assign target to look and move towards.
	public float moveSpeed;					
	public float fieldOfView;						//how far is the monster view distance.
	public GameObject whatIsMonster;
	public GameObject[] Waypoints;					//determine active level waypoints.
	public GameObject vanishParticle;
	public GameObject spawnParticle;				

	private float teleportRatio;					//How often nightmare changes location between active waypoints.
	private float pickRandomTeleport;				//Pick a random waypoint.
	private bool presenceCheck;						//define whether a monster has spawned or not. If so, don't spawn another monster.
	private bool monsterTeleportCheck = false;		//Check to see if monster teleports.
	private bool hasTarget = false;					//Monster aquired target. if target aquired, teleport to nearest waypoint and start advancing to the player.


	void Start () {
//		Waypoints = GameObject.FindGameObjectWithTag<"MonsterTeleport">();		//check active waypoints.
		moveSpeed = 5f;
	}

	void Update () {

		target = GameObject.Find("Child");

		if (Vector3.Distance (target.transform.position, gameObject.transform.position) < 20) {
		
			PlayerInSight ();
			Movement();
		} 
	}


	void Movement (){
//		Toggle Animations
	}


	void PlayerInSight () {
//		if (RaycastHit  && Vector3.Distance (whatIsMonster, Target) <= fieldOfView){
//			transform.Translate(Vector2.right * moveSpeed * Time.deltaTime);
//		}

		gameObject.transform.position = Vector3.MoveTowards (gameObject.transform.position, target.transform.position, moveSpeed * Time.deltaTime);

		Debug.Log (target);
	}

//	void RandomTeleportation(){
//		teleportRatio += Time.deltaTime;
//		
//		if (Mathf.Floor (teleportRatio) >= pickRandomTeleport) {
//			float possibility = Mathf.Floor(Random.Range(0,100));
//			if(teleportRatio>possibility)
//			{
//				print ("Changed location")
//			}
//			print (possibility);
//			pickRandomTeleport +=5;
//		}
//	}
}