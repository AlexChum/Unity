using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JetPack : MonoBehaviour {

	private GameObject player;
	private Vector3 adjustment;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
		adjustment = new Vector3 (0.0f, 0.1f, 0.0f);
	}

	// Update is called once per frame
	void Update () {
		if (player != null) {
			this.transform.position = player.transform.position + adjustment;
		} else {
			Destroy (this);
		}
	}
}
