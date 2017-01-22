using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ButtonFunctions : MonoBehaviour {

	public string function = "NewGame";
	public bool run = false;

	// Update is called once per frame
	void Update () {
		if (run) {
			switch (function) {
			case "NewGame":
				SceneManager.LoadScene (1);
				break;
			case "Exit":
				Application.Quit ();
				break;
			case "Credits":
				SceneManager.LoadScene ("Credits");
				break;
			case "Menu":
				SceneManager.LoadScene ("Menu");
				break;
			}
		}
	}
}
