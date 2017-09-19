using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treetrunk : MonoBehaviour {

	private Main main;
	// Use this for initialization
	void Start () {
		main = GameObject.FindGameObjectWithTag ("GameController").GetComponent<Main> ();;
	}
	
	// Update is called once per frame
	void OnCollisionEnter2D (Collision2D other) {
		if (other.gameObject.tag == "Player") {
			main.gameOver ();
		}
	}
}
