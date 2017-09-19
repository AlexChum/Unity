using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGScroller : MonoBehaviour {

	private float scrollSpeed;
	public float tileSizeZ;
	private Vector3 startPosition;

	// Use this for initialization
	void Start () {
		scrollSpeed = 0.5f;
		startPosition = transform.position;
	}

	// Update is called once per frame
	void Update () {
		float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSizeZ);
		transform.position = startPosition + Vector3.right * -newPosition;

	}


}
