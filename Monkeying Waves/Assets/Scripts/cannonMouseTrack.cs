using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cannonMouseTrack : MonoBehaviour {

	Transform[] cannonHead;
	Vector3 mousePosition;
	float xDist;
	float zDist;
	float lineDist;
	float curRot = 0;
	float cannonPitch = 0;
	float launchMagnitude = 10;
	float correctionConst = 2f;
	public Rigidbody cannonball;
	RaycastHit Hit;

	// Use this for initialization
	void Start () {
		cannonHead = this.gameObject.GetComponentsInChildren<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
		mousePosition = Input.mousePosition;
		mousePosition.z = 2;
		mousePosition = Camera.main.ScreenToWorldPoint (mousePosition);
		Physics.Raycast (Camera.main.transform.position, mousePosition - Camera.main.transform.position, out Hit, Mathf.Infinity, 1<<4);
		xDist = Hit.point.x - this.transform.localPosition.x;
		zDist = Hit.point.z - this.transform.localPosition.z;
		lineDist = Mathf.Min (Mathf.Sqrt (xDist * xDist + zDist * zDist), 98f);;
		this.transform.Rotate (new Vector3 (0,0, Mathf.Rad2Deg * Mathf.Acos(-xDist/lineDist) - curRot));
		curRot = this.transform.rotation.eulerAngles.y;
		cannonHead[1].Rotate(new Vector3(0, Mathf.Rad2Deg * Mathf.Asin(lineDist/launchMagnitude/Physics.gravity.magnitude)/2-cannonPitch, 0));
		cannonHead[2].Rotate(new Vector3(0, Mathf.Rad2Deg * Mathf.Asin(lineDist/launchMagnitude/Physics.gravity.magnitude)/2-cannonPitch, 0));
		cannonPitch = Mathf.Rad2Deg * Mathf.Asin (lineDist / launchMagnitude / Physics.gravity.magnitude) / 2;
		if (Input.GetMouseButtonDown(0)) {
			Debug.Log ("Test");
			Rigidbody ballClone = Instantiate (cannonball, new Vector3(transform.position.x, 0, transform.position.z), transform.rotation);
			ballClone.velocity = new Vector3 (-Mathf.Cos (Mathf.Deg2Rad * (360-cannonHead[1].rotation.eulerAngles.x)) * Mathf.Cos (Mathf.Deg2Rad * this.transform.rotation.eulerAngles.y) * launchMagnitude,
				Mathf.Sin (Mathf.Deg2Rad * (360-cannonHead[1].rotation.eulerAngles.x)) * launchMagnitude* correctionConst,
				Mathf.Cos (Mathf.Deg2Rad * (360-cannonHead[1].rotation.eulerAngles.x)) * Mathf.Sin (Mathf.Deg2Rad * this.transform.rotation.eulerAngles.y) * launchMagnitude)* correctionConst;
		}
		Debug.Log (cannonHead [1].rotation.eulerAngles);
	}
}
