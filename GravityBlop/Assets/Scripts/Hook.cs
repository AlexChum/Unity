using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hook : MonoBehaviour {
	
	private GameObject player;
	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag ("Player");
	}

	// Update is called once per frame
	void Update () {
		if (player != null) {
			this.transform.position = player.transform.position;
			transform.Rotate (0,0,50*Time.deltaTime);
		} else {
			Destroy (this);
		}
	}
}
