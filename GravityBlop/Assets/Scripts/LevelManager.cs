using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LevelManager : MonoBehaviour {

	public float loadNextLevelAfter;
	private int currentScene;
	// Use this for initialization
	void Awake () {
		currentScene = SceneManager.GetActiveScene ().buildIndex;
	}
	void Start () {
		if (loadNextLevelAfter != 0) {
			Invoke ("nextLevel", loadNextLevelAfter);
		}
	}

	public void LoadLevel(string name) {
		SceneManager.LoadScene (name);
	}

	public void QuitRequest() {
		Application.Quit ();
	}

	public void nextLevel() {
		SceneManager.LoadScene (currentScene + 1);
	}
}
