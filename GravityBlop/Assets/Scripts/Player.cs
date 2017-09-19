using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	private Rigidbody2D rb;
	private Vector2 pos;
	private float screenLimit = 18.5f;
	private float acceleration = 20.0f;

	void Start () {
		rb = this.GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void Update () {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		if (Input.touches.Length != 0) {
			if (Input.GetTouch (0).position.x <= Screen.width/2) {
				moveHorizontal = -1.0f;
			} else if (Input.GetTouch (0).position.x >= Screen.width/2) {
				moveHorizontal = 1.0f;
			}
		}
		float movement = moveHorizontal * acceleration;
		rb.velocity = new Vector2 (movement, rb.velocity.y);
		rb.position = new Vector2 (Mathf.Clamp (rb.position.x, -screenLimit, screenLimit), rb.position.y);
	}
		
}
