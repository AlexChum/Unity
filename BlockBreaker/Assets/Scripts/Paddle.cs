using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour {

	public static bool autoPlay = false;

	private Ball ball;
	// Use this for initialization

	void Start () {
		ball = GameObject.FindObjectOfType<Ball> ();
	}
	// Update is called once per frame
	void Update () {
		if (!autoPlay) {
			MoveWithMouse ();
		} else {
			AutoPlay ();
		}
	}

	void MoveWithMouse () {
		float mousePosInBlocks = (Input.mousePosition.x / Screen.width * 16.0f);
		Vector3 paddlePos = new Vector3 (8.0f, this.transform.position.y , 0.0f);
		paddlePos.x = Mathf.Clamp(mousePosInBlocks, 1.05f, 14.95f);
		this.transform.position = paddlePos;
	}

	void AutoPlay () {
		Vector3 paddlePos = new Vector3 (ball.transform.position.x, this.transform.position.y, 0.0f);
		this.transform.position = paddlePos;
	}
}
