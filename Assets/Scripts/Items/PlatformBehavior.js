#pragma strict

public var moveSpeed = 0;

public var y;

public var currentPoint : Transform;
public var points : Transform[];
public  var pointSelection = 0;


function Start () {

	currentPoint = points[pointSelection];
}

function Update () {
	
	
	this.gameObject.transform.position = Vector3.MoveTowards(this.gameObject.transform.position, currentPoint.position, Time.deltaTime * moveSpeed);
	
	if(this.gameObject.transform.position == currentPoint.position){
	
	
		pointSelection++;
	
		
		if(pointSelection == points.Length){
		
			pointSelection = 0;
			
		}
		
		currentPoint = points[pointSelection];
	}
	
}



