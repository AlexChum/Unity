using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottomCollider : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D other) {
		if (other.tag == "Player") {
			Destroy (other.gameObject);
			Main.GameOver ();
		}
	}

	void OnTriggerExit2D (Collider2D other) {
		Destroy (other.gameObject);
	}
}
