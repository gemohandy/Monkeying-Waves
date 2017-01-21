using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cannonBallHit : MonoBehaviour {

	public AudioClip splash;

	// Use this for initialization
	void Start () {
		
	}

	void OnCollisionEnter(Collision hit){
		Debug.Log (hit.collider.gameObject.layer);
		if (hit.collider.gameObject.layer == 4) {
			AudioSource soundMaker = this.gameObject.AddComponent<AudioSource>();
			soundMaker.clip = splash;
			soundMaker.volume = 0.3f;
			soundMaker.Play ();
			this.GetComponents<Rigidbody>()[0].isKinematic = true;
			StartCoroutine (destroySelf());
		}
	}

	IEnumerator destroySelf(){
		yield return new WaitForSeconds(2);
		Destroy (this.gameObject); 
	}

	// Update is called once per frame
	void Update () {
		
	}
}
