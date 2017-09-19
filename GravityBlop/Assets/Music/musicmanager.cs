using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicmanager : MonoBehaviour {
	
	AudioSource audioS;
	// Use this for initialization
	void Awake () {
		DontDestroyOnLoad(this);
		audioS = this.GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (audioS.volume < 0.5) {
			fadein ();
		}
	}

	void fadein () {
		audioS.volume += (float) 0.001;
	}
}
