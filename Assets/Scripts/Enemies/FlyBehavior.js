#pragma strict

public var moveSpeed = 0;

public var faceLeft = true;

public var y;

public var currentPoint : Transform;
public var points : Transform[];
public  var pointSelection = 0;;
public var flipScale : Vector2;


function Start () {

	currentPoint = points[pointSelection];
}

function Update () {
	
	
	this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, currentPoint.position, Time.deltaTime * moveSpeed);
	
	if(this.gameObject.transform.position == currentPoint.position){
	
	
		pointSelection++;
	
		if(!faceLeft){

				Flip();
			}
		
		
		if(pointSelection == points.Length){
		
			pointSelection = 0;
			
			if(faceLeft){

					Flip();
				}
		}
		
		currentPoint = points[pointSelection];
	}
	
}


function OnCollisionEnter2D(coll : Collision2D){
	
	if(coll.gameObject.tag == "PLAYER"){
	
		Destroy(coll.gameObject);
	}
}

function Flip(){

	var flipScale : Vector2;
	var rgbd : Rigidbody2D;
	
	rgbd = GetComponent(Rigidbody2D);
	
	flipScale = rgbd.transform.localScale;
	flipScale.x *= -1; //horizontal rotieren
	
	rgbd.transform.localScale = flipScale;
	
	faceLeft = !faceLeft;
}
