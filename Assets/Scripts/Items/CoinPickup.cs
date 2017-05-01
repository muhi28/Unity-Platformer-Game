using UnityEngine;
using System.Collections;

public class CoinPickup : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D coll){

		if (coll.gameObject.tag == "PLAYER") {

			var player = GameObject.FindWithTag("PLAYER");

			PlayerControll playerScript = player.GetComponent<PlayerControll>();

			playerScript.points += 3;

			gameObject.SetActive(false);

			Invoke ("Kill",2);
		}
	}

	void Kill(){

		Destroy (gameObject);
	}
}
