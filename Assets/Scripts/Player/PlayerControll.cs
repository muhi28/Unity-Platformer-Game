using UnityEngine;
using System.Collections;

public class PlayerControll : MonoBehaviour {

	private int life = 3;

	private int numJumps = 0;
	
	public int maxJump = 0;
	private int coins;
	private int possible = 5;

	public float moveSpeed;
	public float jumpHeight;
	
	public KeyCode left;
	public KeyCode right;
	
	public KeyCode jump;
	public KeyCode shoot;
	
	private Rigidbody2D playerBody;
	
	public bool grounded;
	
	public Transform groundCheck;
	public float groundCheckRadius;
	public LayerMask whatsGround;

	public GameObject CurrentCheckpoint;
	
	private Animator animator;
	
	
	// Use this for initialization
	void Start () {
		
		playerBody = GetComponent<Rigidbody2D> ();
		
		animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, whatsGround);
		
		
		if (Input.GetKey(left)) {
			
			playerBody.velocity = new Vector2(-moveSpeed, playerBody.velocity.y);
			
		}else if(Input.GetKey(right)){
			
			playerBody.velocity = new Vector2(moveSpeed, playerBody.velocity.y);
			
		}else {
			
			playerBody.velocity = new Vector2(0, playerBody.velocity.y);

		}
		
		if (Input.GetKeyDown (jump) && (numJumps < maxJump)) {
			
			playerBody.velocity = new Vector2(playerBody.velocity.x, jumpHeight);
			numJumps++;
		}
		
		if (playerBody.velocity.x < 0) {
			
			transform.localScale = new Vector3 (-1, 1, 1);
			
		} else if (playerBody.velocity.x > 0) {
			
			transform.localScale = new Vector3 (1, 1, 1);
		}
		
		animator.SetFloat ("Speed", Mathf.Abs(playerBody.velocity.x));
		animator.SetBool ("Grounded", grounded);
		
	}


	void OnCollisionEnter2D(Collision2D col){

		//Debug.Log ("Life: " + life);
		//Debug.Log ("Coins: " + coins);

		if(col.gameObject.tag == "Coin"){
			coins += 1;

			Debug.Log("Coins: " + coins);
			Destroy(col.gameObject);

		}

		if (col.gameObject.name == "BOX" && possible != 0) {
			coins += 1;
			
			Debug.Log("Coins: " + coins);

			possible--;
		}

		if (col.gameObject.tag == "Enemies" && life != 0) {

			playerBody.transform.position = CurrentCheckpoint.transform.position;
			life--;

			Debug.Log("Life: " + life);

		} else if(life == 0){

			Destroy(GameObject.FindGameObjectWithTag("PLAYER"));
			Debug.Log("GAME OVER");
		}

		if(col.gameObject.CompareTag("Ground")){
			
			numJumps = 0;
		}
		if(col.gameObject.tag == "FALLDETECTOR"){
			
			playerBody.transform.position = CurrentCheckpoint.transform.position;
			
		}
	}

}
