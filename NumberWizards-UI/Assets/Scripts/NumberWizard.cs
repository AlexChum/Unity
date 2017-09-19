using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class NumberWizard : MonoBehaviour {

	int max;
	int min;
	int guess;
	int maxGuesses;

	public Text text;
	// Use this for initialization
	void Start () {
		StartGame ();
	
	}

	void StartGame () {
		maxGuesses = Random.Range (6, 9);
		max = 1000;
		min = 1;
		guess = Random.Range ((max/2 - 100), (max/2 + 100));
		text.text = guess.ToString ();
		max = max + 1;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("up")) {
			GuessHigher ();
		} else if (Input.GetKeyDown ("down")) {
			GuessLower ();
		}
	}

	public void GuessLower (){
		max = guess;
		NextGuess ();
	}

	public void GuessHigher (){
		min = guess;
		NextGuess ();
	}

	void NextGuess () {
		guess = (max + min) / 2;
		text.text = guess.ToString ();
		maxGuesses = maxGuesses - 1;
		if (maxGuesses <= 0) {
			SceneManager.LoadScene("Win"); 
		}
	}
}
