using UnityEngine;
using System.Collections;

public class pickupCoins : MonoBehaviour {

	public int scoreToGive;

	public bool goUp = true;

	private PlayerControll player;

	private Rigidbody2D coin;

	// Use this for initialization
	void Start () {
	
		player = FindObjectOfType<PlayerControll> ();

		coin = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {

		float y = coin.velocity.y;
		
		
		if(goUp){
			
			goUp = false;
			//coin.velocity = new Vector2(0,y + 0.5);
			
			
		}else {
			
			goUp = true;
			coin.velocity = new Vector2(0,-y);
			
		}
	}

	void OnTriggerEnter2D(Collider2D other){

		if (other.gameObject.name == "Player") {

			Debug.Log("PUNKT GEFUNDEN");

			Destroy(GameObject.FindGameObjectWithTag("Coin"));
		}
	}
}
