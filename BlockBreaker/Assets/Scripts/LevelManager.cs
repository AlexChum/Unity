using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	private int index;
	public void LoadLevel(string name) {
		SceneManager.LoadScene (name);
	}

	public void QuitRequest() {
		Application.Quit ();
	}

	public void LoadNextLevel() {
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex + 1);
	}

	public void BreakableDestroyed () {
		if (Brick.breakableCount <= 0) {
			LoadNextLevel ();
		}
	}

	public void AutoPlay () {
		Paddle.autoPlay = true;
		LoadNextLevel ();
	}
}
