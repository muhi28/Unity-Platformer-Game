#pragma strict

public var moveSpeed = 0;

function Start () {

}

function Update () {

	var x = GetComponent(Rigidbody2D).velocity.x;
	//var y = GetComponent(Rigidbody2D).velocity.y;

		
		GetComponent(Rigidbody2D).velocity = new Vector2(-moveSpeed,0);
}