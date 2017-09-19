using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour {

	private Rigidbody2D rb;
	private Animator animator;
	public static float maxSpeed = 0.5f;
	public static float strength = 0.6f;
	public static int speedlvl = 1;
	public static int strlvl = 1;
	public Text wind;
	private float windStrength;

	void Start () {
		windStrength = Random.Range (0.0f, 30.0f);
		rb = this.GetComponent<Rigidbody2D> ();
		animator = GameObject.FindGameObjectWithTag ("Person").GetComponent<Animator> ();
		wind.text = windStrength.ToString ();
	}

	void Update() 
	{
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		if (moveHorizontal < 0.0f) {
			animator.SetBool ("Paddling", false);
			animator.SetBool ("Backward", true);
		} else if ((moveHorizontal > 0.0f) | (moveVertical != 0.0f)) {
			animator.SetBool ("Paddling", true);
			animator.SetBool ("Backward", false);
		} else {
			animator.SetBool ("Paddling", false);
			animator.SetBool ("Backward", false);
		}
		Vector2 movement = new Vector2 (moveHorizontal , moveVertical);
		rb.AddForce(movement * strength );
		rb.AddForce (new Vector2 (1.0f, 0.0f) * (-windStrength * 0.01f));
		rb.velocity = new Vector2 
			(
				Mathf.Clamp (rb.velocity.x, -maxSpeed/2.0f, maxSpeed),
				Mathf.Clamp (rb.velocity.y, -maxSpeed, maxSpeed)
			);

			
		rb.position = new Vector3 
			(
				Mathf.Clamp (rb.position.x, -3.3f , 3.9f), 
				Mathf.Clamp (rb.position.y, -1.5f , 2.8f),
				0.0f
			);

	}

	public static void SetSpeed (float speed) {
		maxSpeed += speed;
	}

	public static void SetStrength (float str) {
		strength += str;
	}

	public static int getStrlvl () {
		return strlvl;
	}

	public static int getSpeedlvl () {
		return speedlvl;
	}

	public static void incSpeedlvl () {
		speedlvl++;
		maxSpeed += 0.15f;
	}	

	public static void incStrlvl () {
		strlvl++;
		strength += 0.15f;
	}

}
