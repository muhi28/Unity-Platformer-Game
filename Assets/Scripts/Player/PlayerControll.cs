using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerControll : MonoBehaviour {



	private int numJumps = 0; // Anzahl der durchgeführten Sprünge
	
	public int maxJump = 0; // maximale Anzahl der möglichen Sprünge
	private int coins;      // Anzahl der im Spiel gesammelten Coins

	public float moveSpeed; // gibt die Geschwindigkeit an, mit der sich der Spieler fortbewegt
	public float jumpHeight; // gibt die Sprunghoehe an
	
	public KeyCode left; // Taste mit der sich der Spieler nach links bewegt
	public KeyCode right; // Taste mit der sich der Spieler nach rechts bewegt
	
	public KeyCode jump; // Taste zum Springen

	private Rigidbody2D playerBody; //Rigidbody der Spielers
	
	public bool grounded;
	
	public Transform groundCheck; //Punkt welcher dazu verwendet wird, um zu prüfen, ob sicher der Spieler in der Luft, oder am Boden befindet
	public float groundCheckRadius; // Radius des Punktes
	public LayerMask whatsGround;

	public GameObject CurrentCheckpoint; //Startpunkt des Spielers
	
	private Animator animator; //Animator, welcher die Animationen des Spielers verwaltet

	// Punktezahl anzeigen
	public int points;
	public GameObject pointsText;
	private Text pointsObj;

	//Leben des Spielers
	public int health = 3;
	public GameObject healthText;

	private Text healthObj;

	public DeathMenu deathScreen;


	

	// Use this for initialization
	void Start () { 
		
		playerBody = GetComponent<Rigidbody2D> (); // hier wird der Rigidbody des Spielers initialisiert
		animator = GetComponent<Animator> (); // Initialisierung des Animators

		pointsObj = pointsText.GetComponent<Text> ();
		healthObj = healthText.GetComponent<Text> ();
	}
	
	// Update is called once per frame
	void Update () {
		
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, whatsGround); //Initialisierung der grounded Variable
		

		//BEWEGUNG DES SPIELERS
		if (Input.GetKey(left)) { // solange die left-Taste gedrückt wird
			
			playerBody.velocity = new Vector2(-moveSpeed, playerBody.velocity.y); // wird die Velocity des Spielers in negativer X-Richtung erhöht
			
		}else if(Input.GetKey(right)){ //wird die right-Taste gedrückt,
			
			playerBody.velocity = new Vector2(moveSpeed, playerBody.velocity.y); //so wird die Velocity in pos. X-Richtung erhöht.
			
		}else { //wird der Spieler nicht bewegt, so wird die Velocity in X auf null und die in Y auf die Velocity des Spielers gesetzt
			
			playerBody.velocity = new Vector2(0, playerBody.velocity.y);

		}

		//SPRINGEN
		if (Input.GetKeyDown (jump) && (numJumps < maxJump)) { //solange die jump-Taste gedrückt und die Anzahl der Sprünge kleiner als maxJumps ist
			
			playerBody.velocity = new Vector2(playerBody.velocity.x, jumpHeight); //Ändere die Velocity in Y-Richtung
			numJumps++; //numJumps wird dabei pro Sprung um eines erhöht
		}
		
		if (playerBody.velocity.x < 0) { // ist nun die Velocity des Spielers kleiner als 0
			
			transform.localScale = new Vector3 (-1, 1, 1); // so wird das Sprite des Spielers in X-Richtung gedreht
			
		} else if (playerBody.velocity.x > 0) { //gleiches Vorgehen !!!
			
			transform.localScale = new Vector3 (1, 1, 1);
		}
		
		animator.SetFloat ("Speed", Mathf.Abs(playerBody.velocity.x)); //initialisierung von Speed mittels der Spieler Velocity 
		animator.SetBool ("Grounded", grounded); // Initialisierung von Grounded mittels der grounded Variable

		pointsObj.text = points.ToString ();
		healthObj.text = health.ToString ();

		checkHealth ();
	}
	

	void OnCollisionEnter2D(Collision2D col){ // Der Inhalt dieser Methode dient dazu, um das Verhalten 
											  // bei der Kollision mit anderen Objekten zu Beschreiben


		//Kollision mit einem Gegner
		if (col.gameObject.tag == "Enemies") {

			if(health != 0){
				
				health -= 1;
			}

			playerBody.transform.position = CurrentCheckpoint.transform.position; //teleportiere Spieler an Startpunkt

		} 
		if(col.gameObject.CompareTag("Ground") || col.gameObject.CompareTag("MovingPlatform")){ //hiermit wird geprüft, ob sich der Spieler am Boden befindet
			
			numJumps = 0; // ist dies der Fall, so wird der Wert der durchgeführten Sprünge auf null gesetzt

		}

		//hier wird geprüft, ob der Spieler aus dem Level gefallen ist
		if(col.gameObject.tag == "FALLDETECTOR"){

			if(health != 0){
				
				health -= 1;
			}

			playerBody.transform.position = CurrentCheckpoint.transform.position;
		}

		if (col.transform.tag == "MovingPlatform") {


		}
		//Szenenwechsel
		if (col.gameObject.tag == "Finish" && coinsCollected()) { //

			Application.LoadLevel("Level_2");
		}
	}

	public void checkHealth(){

		if (health == 0) {

			deathScreen.gameObject.SetActive(true);
		}
	}
	bool coinsCollected(){ //Diese Methode prüft, ob die alle im Level vorhandenen Coins eingesammelt wurden
		
		bool collected = false;
		
		if (points == 39) { // Wurden die 13 Coins eingesammelt, so wird collected auf true gesetzt und es erfolgt
							// der Szenenwechsel zu Level 2
			collected = true;
		}
		
		return collected;
	}
	
}
