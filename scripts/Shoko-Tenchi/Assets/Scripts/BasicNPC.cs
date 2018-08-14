using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicNPC : MonoBehaviour {

	public GameObject npcName;
	public string dialogue;
	private DialogueManager dMan;

	// Use this for initialization
	void Start () {
		npcName.SetActive (false);
		dMan = FindObjectOfType<DialogueManager> ();
	}
	
	void OnTriggerStay(Collider other){
		if (other.gameObject.tag == "Player") {
			npcName.SetActive (true);

			if (other.gameObject.tag == "Player") {
				if(Input.GetButtonDown("Use")){
					dMan.ShowBox (dialogue);
				}
			}
		}
	}

	void OnTriggerExit(){
		npcName.SetActive (false);
	}
}
