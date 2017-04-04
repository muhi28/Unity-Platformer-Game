#pragma strict

public var goUp = true;

function Start () {

}

function Update () {


	var y = GetComponent(Rigidbody2D).velocity.y;
	
	
	if(goUp){
	
	goUp = false;
	GetComponent(Rigidbody2D).velocity = new Vector2(0,y + 0.5);
	
	
	}else {
	
	goUp = true;
	GetComponent(Rigidbody2D).velocity = new Vector2(0,-y);
	
	}

}