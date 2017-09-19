using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class Main : MonoBehaviour {

	public GameObject crate;
	public GameObject log;
	public Text crates;
	public static int crateNumber = 10;
	// Use this for initialization
	void Start () {
		StartCoroutine (spawnCrates ());
		StartCoroutine (spawnLogs ());
	}

	void Update () {
		crates.text = crateNumber.ToString ();
	}

	IEnumerator spawnCrates() {
		yield return new WaitForSeconds (2.0f);

		while (true) {
			float rand = Random.value;
			if (rand < 0.2f) {
				Vector2 spawnPosition = new Vector2 (6.0f, Random.Range(-0.7f, 2.89f) );
				float speed = Random.Range (-2.0f, -0.2f);
				GameObject temp = Instantiate( crate, spawnPosition, Quaternion.identity);
				Rigidbody2D rb = temp.GetComponent<Rigidbody2D> ();
				rb.velocity = new Vector2 (speed, 0.0f);
				yield return new WaitForSeconds (4.0f);
			}


		}
			
	}

	IEnumerator spawnLogs () {
	yield return new WaitForSeconds (2.0f);

		while (true) {
			for (int i = 0; i < 10; i++) {
				Vector2 spawnPosition = new Vector2 (6.0f, Random.Range(-0.7f, 2.89f) );
				float speed = Random.Range (-1f, -0.5f);
				GameObject temp = Instantiate (log, spawnPosition, Quaternion.identity);
				temp.transform.Rotate (new Vector3(0.0f, 0.0f, Random.Range(0.0f, 180.0f)));
				Rigidbody2D rb = temp.GetComponent<Rigidbody2D> ();
				rb.velocity = new Vector2 (speed, 0.0f);
				temp.transform.localScale = new Vector3 (Random.Range(0.12f, 0.2f), Random.Range(0.12f, 0.2f), 0.0f);
				yield return new WaitForSeconds (10.0f);
			}
		}
	}



	public void gameOver () {
		SceneManager.LoadScene ("Menu");
	}

	public static void addCrate () {
		crateNumber++;
	}

	public static int getCrate () {
		return crateNumber;
	}

	public static void decCrate (int num) {
		crateNumber -= num;
	}
}
