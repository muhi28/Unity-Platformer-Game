using UnityEngine;
using System.Collections;

public class CoinBoxScript : MonoBehaviour {

	private int possible = 3;

	void OnCollisionEnter2D(Collision2D coll){

		//Kollision mit der Coin Box
		if (coll.gameObject.tag == "PLAYER" && possible != 0) {

			var player = GameObject.FindWithTag("PLAYER");
			
			PlayerControll playerScript = player.GetComponent<PlayerControll>();
			
			playerScript.points += 5;
			
			possible--;
		}
	}
}
