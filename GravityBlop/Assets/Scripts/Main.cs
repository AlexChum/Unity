using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Main : MonoBehaviour {

	public static bool gameOver= false;
	public static bool rotation = false;
	public static int level = 0;

	public GameObject fallen;
	public GameObject gameoverText;
	public GameObject restartText;
	public GameObject[] powerUps;

	public Text scoreText;
	public Text levelindicator;

	private float startWait = 3.0f;

	private int score;

	private bool restart;

	private bool reducedSpeed;
	private float timeReducedSpeed;

	//Level Data
	private int fallenNumber = 15;
	private float fallenProportion = 1.0f;
	private float spawnWait = 0.7f;

	void Start () {
		Time.timeScale = 1.0f;
		restart = false;
		gameOver = false;
		rotation = false;
		reducedSpeed = false;

		Physics2D.gravity = new Vector2 (0.0f, -9.8f);
		Physics2D.IgnoreLayerCollision (8, 8, true);

		GameObject safetyBar = GameObject.FindGameObjectWithTag ("SafetyBar");
		Destroy (safetyBar, startWait + 1.5f);

		level = 1;
		score = -3;
		StartCoroutine (spawnFallens());
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("escape")) {
			SceneManager.LoadScene ("Menu");
		}
		if (gameOver) {
			gameoverText.SetActive (true);
			restart = true;
		} else {
			updateScore ();
		}
		if (restart) {
			restartText.SetActive (true);
			if (Input.GetKeyDown ("r") | Input.touches.Length != 0) {
				SceneManager.LoadScene ("Main");
			}
		}

		if (reducedSpeed) {
			if (Time.timeSinceLevelLoad > (timeReducedSpeed + 4.0f)) {
				Time.timeScale = 1.0f;
			}
		}
	}

	void FixedUpdate () {

	}

	IEnumerator spawnFallens() {
		yield return new WaitForSeconds (startWait);
		StartCoroutine (spawnPowerUps ());

		while (true) {
			// Last level or else
			if (level == 5) {
				for (int i = 0; i < fallenNumber; i++) {
					float rand = Random.value;
					if (rand <= fallenProportion) {
						scaleFallen (unmovableFallen (randomSpeed(), randomPosition()));
					} else {
						scaleFallen( movableFallen (randomPosition()));
					}
					yield return new WaitForSeconds (spawnWait);
				}
			} else {
				updateLevelData ();
				for (int i = 0; i < fallenNumber; i++) {
					float rand = Random.value;
					if (rand < fallenProportion) {
						scaleFallen (unmovableFallen (randomSpeed(), randomPosition()));
					} else {
						scaleFallen (movableFallen (randomPosition()));
					}
					yield return new WaitForSeconds (spawnWait);
				}
				if (!gameOver) {
					level++;
					updateLevelData ();
				}
			}
		}
	}
		

	GameObject movableFallen (Vector2 pos) {
		GameObject normal = Instantiate (fallen, pos, Quaternion.identity);
		Renderer rend = normal.GetComponent<Renderer> ();
		rend.material.color = Color.green;
		return normal;
	}

	/*
	 * unmovable objects always needs a velocity 
	 * speed has to be negative
	*/
	GameObject unmovableFallen (float speed, Vector2 pos) {
		GameObject unmovable = Instantiate (fallen, pos, Quaternion.identity);
		Rigidbody2D rb = unmovable.GetComponent<Rigidbody2D> ();
		Renderer rend = unmovable.GetComponent<Renderer> ();
		rend.material.color = Color.black;
		rb.isKinematic = true;
		rb.velocity = new Vector2 (0.0f, speed);
		return unmovable;
	}

	Vector2 randomPosition () {
		return new Vector2 (Random.Range(-16.0f, 16.0f) , 13.0f);
	}

	float randomSpeed () {
		return Random.Range (-5.0f, -2.0f);
	}

	public static void GameOver () {
		gameOver = true;
	}

	void updateLevelData () {
		if (level == 1) {
			fallenProportion = 1.0f;
			fallenNumber = 20;
			spawnWait = 0.7f;
		} else if (level == 2) {
			fallenNumber = 25;
			fallenProportion = 0.7f;
		} else if (level == 3) {
			fallenProportion = 0.5f;
			spawnWait = 0.7f;
		} else if (level == 4) {
			rotation = true;
		} else if (level == 5) {
			fallenNumber = 40;
			fallenProportion = 0.3f;
			spawnWait = 0.6f;
		}
		levelindicator.text = "Level :" + level;
	}

	void updateScore () {
		int time = (int) Mathf.Floor(Time.timeSinceLevelLoad);
		scoreText.text = "Score :" + Mathf.Max(0.0f, (time + score)).ToString() ;
	}
		
	void scaleFallen (GameObject fallen) {
		Rigidbody2D rb = fallen.GetComponent<Rigidbody2D> ();

		if (rb.isKinematic) {
			fallen.transform.localScale += new Vector3 (Random.Range (-0.5f, 1.5f), Random.Range (-0.5f, 1.5f), 0.0f);
		} else {
			fallen.transform.localScale += new Vector3 (Random.Range (-0.2f, 2.0f), Random.Range (-0.5f, 1.5f), 0.0f);
		}

		float xValue = fallen.transform.localScale.x;
		float yValue = fallen.transform.localScale.y;
		rb.mass = 8 * xValue * yValue;
	}
		
	IEnumerator spawnPowerUps () {
		while (true) {
			yield return new WaitForSeconds (3.0f);
			float rand = Random.value;
			if (rand <= .1f) {
				int item = Random.Range (0, powerUps.Length - 1);
				GameObject powerUp = Instantiate (powerUps [item], randomPosition(), Quaternion.identity);
				Rigidbody2D rb = powerUp.GetComponent<Rigidbody2D> ();
				rb.velocity = new Vector2 (0.0f, Random.Range(-10.0f, -5.0f));
			}
		}
	}

	public void reduceSpeed () {
		Time.timeScale = 0.6f;
		reducedSpeed = true;
		timeReducedSpeed = Time.timeSinceLevelLoad;
	}

	//darkholes
}
