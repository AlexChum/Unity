using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowTime : MonoBehaviour {


	void OnTriggerEnter2D (Collider2D other) {
		if (other.tag == "Player") {
			GameObject gc = GameObject.FindGameObjectWithTag ("GameController");
			Main main = gc.GetComponent<Main> ();
			main.reduceSpeed ();
			Destroy (this.gameObject);
		}
	}

}
