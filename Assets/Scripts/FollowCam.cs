using UnityEngine;
using System.Collections;

public class FollowCam : MonoBehaviour {

	public static FollowCam S;
	public GameObject poi;
	private float camZ;


	void Awake(){
		S = this;
		camZ = transform.position.z;
	}

	void Update(){
	
		if (poi == null) {
			return;
		}

		Vector3 destination = poi.transform.position;
		destination = Vector3.Lerp (transform.position, destination, 0.05f); 
		destination.z = camZ;

		transform.position = destination;
	}

}

