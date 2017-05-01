using UnityEngine;
using System.Collections;

public class FollowPlayer : MonoBehaviour {

	public GameObject player;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		Vector3 cam = player.transform.position;

		transform.position = new Vector3 (cam.x, cam.y, transform.position.z);
	}
}
