using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomColor : MonoBehaviour {

	private float timeAtLastChange = 0.0f;
	private float timeBetweenChange;
	private Image arrow;

	void Start () {
		arrow = this.GetComponent<Image> ();
		timeBetweenChange = Random.Range (0.5f, 1.5f);
	}
	// Update is called once per frame
	void Update () {
		if ((Time.timeSinceLevelLoad - timeAtLastChange) > timeBetweenChange) {
			arrow.color = new Color(Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f), 1.0f);
			timeAtLastChange = Time.timeSinceLevelLoad;
			timeBetweenChange = Random.Range (0.5f, 1.5f);
		}
	}
}
