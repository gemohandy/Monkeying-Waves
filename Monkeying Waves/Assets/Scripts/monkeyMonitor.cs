using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class monkeyMonitor : MonoBehaviour {

	public GameObject[] all;
	public List<floatPreserve> preservers;
	bool win;

	// Use this for initialization
	void Start () {
		all = SceneManager.GetActiveScene().GetRootGameObjects();
		foreach (GameObject thing in all) {
			if (thing.GetComponentsInChildren<floatPreserve> () != null) {
				preservers.AddRange(thing.GetComponentsInChildren<floatPreserve> ());
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		win = true;
		foreach (floatPreserve hoop in preservers) {
			win = win && hoop.grabbed;
		}
		if (win) {
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex + 1);
		}
	}
}
