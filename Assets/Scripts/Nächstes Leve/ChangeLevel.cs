using UnityEngine;
using System.Collections;

public class ChangeLevel : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D coll){
		
		if (coll.gameObject.tag == "PLAYER") {
			
			Application.LoadLevel("Level_2");
		}
	}
}
