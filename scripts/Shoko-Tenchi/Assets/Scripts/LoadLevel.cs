using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour {

	public GameObject guiText;
	public string levelToLoad;

	// Use this for initialization
	void Start () {
		guiText.SetActive (false);
	}
	
	void OnTriggerStay (Collider other){
		if (other.gameObject.tag == "Player") {
			guiText.SetActive (true);
			if (guiText.activeInHierarchy == true && Input.GetButtonDown ("Use")) {
				//SceneManager.LoadScene("River Village", LoadSceneMode.Additive);
				Application.LoadLevel(levelToLoad);

			}
		}
	}

	void OnTriggerExit(){
		guiText.SetActive (false);
	}
}
