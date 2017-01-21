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
	RaycastHit Hit;

	// Use this for initialization
	void Start () {
		cannonHead = this.gameObject.GetComponentsInChildren<Transform>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Physics.Raycast (Camera.main.ScreenPointToRay(Input.mousePosition), out Hit)) {
			Debug.Log ("Hello!");
		};
		Debug.Log (mousePosition);
		mousePosition = Input.mousePosition;
		mousePosition.z = Hit.distance;
		mousePosition = Camera.main.ScreenToWorldPoint (mousePosition);
		xDist = mousePosition.x - this.transform.localPosition.x;
		zDist = mousePosition.z - this.transform.localPosition.z;
		lineDist = Mathf.Sqrt (xDist * xDist + zDist * zDist);
		this.transform.Rotate (new Vector3 (0,0, Mathf.Rad2Deg * Mathf.Acos(-xDist/lineDist) - curRot));
		curRot = Mathf.Rad2Deg * Mathf.Acos(-xDist/lineDist);
		cannonHead[1].Rotate(new Vector3(0, Mathf.Rad2Deg * Mathf.Asin(lineDist/launchMagnitude/Physics.gravity.magnitude)/2-cannonPitch, 0));
		cannonHead[2].Rotate(new Vector3(0, Mathf.Rad2Deg * Mathf.Asin(lineDist/launchMagnitude/Physics.gravity.magnitude)/2-cannonPitch, 0));
		cannonPitch = Mathf.Rad2Deg * Mathf.Asin (lineDist / launchMagnitude / Physics.gravity.magnitude) / 2;

		Debug.Log (Mathf.Asin((lineDist/launchMagnitude)/Physics.gravity.magnitude));
	}
}
