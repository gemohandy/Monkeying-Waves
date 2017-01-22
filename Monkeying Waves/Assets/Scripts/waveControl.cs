using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waveControl : MonoBehaviour {
	public waveControl[] neighbours;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
		
	public IEnumerator WaveGenerated(int mag, waveControl source){
		if(mag>0){
			this.transform.position += new Vector3(0, Mathf.Pow (3, mag-1.5f), 0);
			yield return new WaitForSeconds (0.5f);
			foreach (waveControl neighbour in neighbours) {
				if (neighbour != source) {
					StartCoroutine(neighbour.WaveGenerated (mag - 1, this));
				}
			}
			this.transform.position += new Vector3(0, -Mathf.Pow (3, mag-1.5f), 0);
		}
	}
}
