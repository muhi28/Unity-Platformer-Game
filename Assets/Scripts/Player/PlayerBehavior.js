#pragma strict

private var numJumps = 0;

public var maxJump = 0;
public var moveSpeed = 0;
public var jheight = 0;

public var faceRight = true;

public var respawnpoint : Vector3;
public var CurrentCheckpoint : GameObject;

function Start () {

}

function Update () {

	var x;
	var y;
	
	
	if(Input.GetKeyDown(KeyCode.Space) && (numJumps < maxJump)){
	
		x = GetComponent(Rigidbody2D).velocity.x;
		
	GetComponent(Rigidbody2D).velocity = new Vector2(x,jheight);
	
	numJumps++;
	
	}
	
	if(Input.GetKey(KeyCode.LeftArrow)){
		
		y = GetComponent(Rigidbody2D).velocity.y;
		
		GetComponent(Rigidbody2D).velocity = new Vector2(-moveSpeed,y);
		
		if(faceRight){
		
			Flip();
		}
	}
	
	if(Input.GetKey(KeyCode.RightArrow)){
		
		y = GetComponent(Rigidbody2D).velocity.y;
		GetComponent(Rigidbody2D).velocity = new Vector2(moveSpeed,y);
		
		
		if(!faceRight){
		
			Flip();
		}
	}
}

function OnCollisionEnter2D(coll : Collision2D){

	if(coll.gameObject.tag == "Coin"){
	
		Destroy(coll.gameObject);
	}
	
	if(coll.gameObject.CompareTag("Ground")){
	
		numJumps = 0;
	}
	
	if(coll.gameObject.tag == "FALLDETECTOR"){
	
	 	GetComponent(Rigidbody2D).transform.position = CurrentCheckpoint.transform.position;
		
	}
	
}



function Flip(){

	var flipScale : Vector2;
	var rgbd : Rigidbody2D;
	
	rgbd = GetComponent(Rigidbody2D);
	
	flipScale = rgbd.transform.localScale;
	flipScale.x *= -1; //horizontal rotieren
	
	rgbd.transform.localScale = flipScale;
	
	faceRight = !faceRight;
}






