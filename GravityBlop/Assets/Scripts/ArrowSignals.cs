using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrowSignals : MonoBehaviour {

	private float timeAtLastChange = 0.0f;
	private Image arrow;

	void Start () {
		arrow = this.GetComponent<Image> ();
		Destroy (this.gameObject, 5.0f);
	}
	// Update is called once per frame
	void Update () {
		if ((Time.timeSinceLevelLoad - timeAtLastChange) > 0.5f) {
			
			timeAtLastChange = Time.timeSinceLevelLoad;
			if (arrow.color == Color.white) {
				arrow.color = Color.green;
			} else {
				arrow.color = Color.white;
			}
		}
	}
}
