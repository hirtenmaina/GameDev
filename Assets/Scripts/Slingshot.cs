using UnityEngine;
using System.Collections;

public class Slingshot : MonoBehaviour {

	private GameObject LaunchPoint;

	void Awake (){
		Transform LaunchPointTrans = transform.Find("LaunchPoint"); //only searches children
		LaunchPoint = LaunchPointTrans.gameObject;
		LaunchPoint.SetActive (false);
	}

	void OnMouseEnter()	{
	LaunchPoint.SetActive (true);
	}
		
	void OnMouseExit()	{
	LaunchPoint.SetActive (false);
	}

}