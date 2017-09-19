using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCollider : MonoBehaviour {

	private LevelManager levelManager;
	void OnTriggerEnter2D (Collider2D trigger) {
		levelManager = GameObject.FindObjectOfType<LevelManager> ();
		Brick.breakableCount = 0;
		Paddle.autoPlay = false;
		levelManager.LoadLevel ("Lose");
	}
		
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
