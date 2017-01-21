using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class monkeyHit : MonoBehaviour {

	public AudioClip monkeySound;

	// Use this for initialization
	void Start () {
		
	}

	void OnCollisionEnter(){
		AudioSource chatter = this.gameObject.GetComponent<AudioSource> ();
		if (chatter == null) {
			chatter = this.gameObject.AddComponent<AudioSource> ();
		}
		chatter.clip = monkeySound;
		chatter.Play();
	}

	// Update is called once per frame
	void Update () {
		
	}
}
