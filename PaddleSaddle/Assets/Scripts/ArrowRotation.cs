using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowRotation : MonoBehaviour {

	private Quaternion startPos = new Quaternion (0.0f, 0.0f, -0.05f, 1.0f);
	private Quaternion endPos = new Quaternion (0.0f, 0.0f, -1.0f, 0.05f);

	private float strokeSpeed;
	private float recoverySpeed;

	private bool forward;

	void Start () {
		forward = true;
		strokeSpeed = 120.0f;
		recoverySpeed = 60.0f;
//		Debug.Log (this.transform.rotation.ToString ("F4"));
	}

	// Update is called once per frame
	void Update () {
		if (this.transform.rotation == startPos) {
			forward = true;
		}
		if (this.transform.rotation == endPos | Input.GetKeyDown ("space")) {
			forward = false;
		}
		arrowRotate ();
	}

	void arrowRotate () {
		if (forward) { 		
			this.transform.Rotate(new Vector3 (0.0f, 0.0f, -strokeSpeed * Time.deltaTime));
		} else {
			this.transform.Rotate(new Vector3 (0.0f, 0.0f, recoverySpeed * Time.deltaTime));
		}
	}
}
