using UnityEngine;
using System.Collections;

public class Slingshot : MonoBehaviour {

	public GameObject prefabProjectile;
	public float velocityMult = 4.0f;
	private GameObject LaunchPoint;
	private bool aimingMode;
	private GameObject projectile;
	private Vector3 launchPos;

	void Awake (){
		Transform LaunchPointTrans = transform.Find("LaunchPoint"); //only searches children
		LaunchPoint = LaunchPointTrans.gameObject;
		LaunchPoint.SetActive (false);
		launchPos = LaunchPointTrans.position;
	}

	void OnMouseEnter()	{
	LaunchPoint.SetActive (true);
	}
		
	void OnMouseExit()	{
	LaunchPoint.SetActive (false);
	}


	void OnMouseDown(){
	// set the game to aiming mode 
		aimingMode = true;
	//initiate a projectile at launchpoint
		projectile = Instantiate (prefabProjectile) as GameObject;
		projectile.transform.position = launchPos;
	//Switch off gravity 
		projectile.GetComponent<Rigidbody> ().isKinematic = true;
	}

	void Update(){
		if (!aimingMode)return;

		Vector3 mousePos2D = Input.mousePosition;
		mousePos2D.z = - Camera.main.transform.position.z;
		Vector3 mousePos3D = Camera.main.ScreenToWorldPoint (mousePos2D);

		Vector3 mouseDelta = mousePos3D - launchPos;

		float maxMagnitude = this.GetComponent<SphereCollider> ().radius;
		mouseDelta = Vector3.ClampMagnitude (mouseDelta, maxMagnitude);

		projectile.transform.position = launchPos + mouseDelta;
	
		if (Input.GetMouseButtonUp (0)) {
				aimingMode = false;
				projectile.GetComponent<Rigidbody> ().isKinematic = false;
				projectile.GetComponent<Rigidbody> ().velocity = - mouseDelta*velocityMult;
				FollowCam.S.poi = projectile;
		}
	
	}


}
















