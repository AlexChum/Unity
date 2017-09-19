using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

	public Rigidbody2D rb;
	// public AudioSource audio;

	private Paddle paddle;
	private bool hasStarted = false;
	private Vector3 paddleToBallVector;
	// Use this for initialization
	void Start () {
		paddle = GameObject.FindObjectOfType<Paddle> ();
		paddleToBallVector = transform.position - paddle.transform.position;
		rb = GetComponent<Rigidbody2D> ();
		// audio = GetComponent<AudioSource> ();
	}

	void OnCollisionEnter2D (Collision2D collision) {
		if (collision.gameObject.tag == "Paddle") {
			Vector3 relpos = paddle.transform.position - transform.position;
			if (relpos.x < 0) {
				rb.velocity = new Vector3 (Mathf.Abs (rb.velocity.x), rb.velocity.y, 0.0f);
			} else if (relpos.x > 0) {
				rb.velocity = new Vector3 (- Mathf.Abs (rb.velocity.x), rb.velocity.y, 0.0f);
			}
		} else{
			Vector2 tweak = new Vector2 (Random.Range (-0.2f, 0.2f), Random.Range(-0.2f, 0.2f));
			rb.velocity += tweak;
		}
		//Clamping the final velocity such that it doesn't go too fast
		rb.velocity = new Vector3 (rb.velocity.x, Mathf.Clamp (rb.velocity.y, -9.5f, 9.5f), 0.0f);

		/* if we ever need audio
		if (hasStarted) {
			audio.Play ();
		}
		*/
	}

	// Update is called once per frame
	void Update () {
		if (!hasStarted) {
			this.transform.position = paddleToBallVector + paddle.transform.position;
		}
		if (Input.GetMouseButtonDown (0)) {
			hasStarted = true;
			rb.velocity = new Vector2 (Random.Range(-1.0f, 1.0f), 9.5f);
		}
	}
		
}

