using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class floatPreserve : MonoBehaviour {

	public float goal;
	public waveControl wave;
	public GameObject monkey;
	Vector3 curPos;
	float start;
	int grabTime = 0;
	public bool grabbed;
	public bool testing;

	// Use this for initialization
	void Start () {
		curPos = wave.transform.position;
		curPos.y += 44;
		this.transform.position = curPos;
		start = this.transform.position.y;
	}
	
	// Update is called once per frame
	void Update () {
		if (grabTime < 5) {
			curPos = wave.transform.position;
			curPos.y += 44;
			this.transform.position = curPos;
			if (Mathf.Abs (this.transform.position.y - start - goal) <= 0.01) {
				grabTime++;
			}
			if (this.transform.position.y != start) {
				Debug.Log (this.transform.position.y - start);
			}
		} else {
			grabbed = true;
			curPos = monkey.transform.position;
			curPos.y += -0.6f;
			this.transform.position = curPos;
			this.transform.localScale = new Vector3 (1, 3, 1);
		}
	}
}
