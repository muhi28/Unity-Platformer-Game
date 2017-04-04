#pragma strict

public var moveSpeed = 0;

public var faceLeft = true;

function Start () {

	
}

function Update () {

}


function OnCollisionEnter2D(coll : Collision2D){
	
	if(coll.gameObject.tag == "Player"){
	
		Destroy(coll.gameObject);
	}
}