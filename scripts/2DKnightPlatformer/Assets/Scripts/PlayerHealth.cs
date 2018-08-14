using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour {

	private GameObject Player;
	public bool hasDied;

	public int health;
	public int numOfHearts;

	public Image[] hearts;
	public Sprite fullHeart;
	public Sprite emptyHeart;

	void Start(){

		Player = GameObject.FindGameObjectWithTag ("Player");
		hasDied = false;
	}

	void Update(){

	//Fell to abyss
		if (Player.transform.position.y < -10){
			hasDied = true;
		}

	//Dying
		if (hasDied == true) {
			StartCoroutine ("Death");
		}

	//Heart system
		if (health > numOfHearts) {
			health = numOfHearts;
		}

	//If no hearts, player is dead
		if (health == 0) {
			StartCoroutine ("Death");
		}

		for (int i = 0; i < hearts.Length; i++) {

			if (i < health) {
				hearts [i].sprite = fullHeart;
			} else {
				hearts [i].sprite = emptyHeart;
			}

			if (i < numOfHearts) {
				hearts [i].enabled = true;
			} else {
				hearts [i].enabled = false;
			}
		}
	}

	public void TakeDamage(){
		health -= 1;
	}

	//Death
	IEnumerator Death(){
		Debug.Log ("Dead");
		SceneManager.LoadScene ("Level1");
		yield return null;
	}
}
