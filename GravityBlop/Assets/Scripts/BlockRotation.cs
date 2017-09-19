using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockRotation : MonoBehaviour {

	private float rotationFactor;
	private Rigidbody2D rb;
	// Use this for initialization
	void Start () {
		rotationFactor = Random.Range (-15.0f, 15.0f);
		rb = GetComponent<Rigidbody2D> ();
	}

	// Update is called once per frame
	void Update () {
		if (!rb.isKinematic && Main.rotation) {
			this.transform.Rotate (0, 0, rotationFactor * Time.deltaTime);
		}
	}
}
