using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Volume : MonoBehaviour {

	public Sprite[] volumeSprites;
	public Image img;

	private AudioSource audioS;
	static int volumeIndex = 0;

	void Start () {
		img = this.GetComponent<Image> ();
		audioS = GameObject.FindGameObjectWithTag ("MusicPlayer").GetComponent<AudioSource> ();
		if (this.img.sprite == null) {
			img.sprite = volumeSprites [Volume.volumeIndex];
		}
	}
	// Update is called once per frame
	public void ChangeVolume () {
		if (Volume.volumeIndex == 3) {
			Volume.volumeIndex = 0;
		} else {
			Volume.volumeIndex++;
		}

		if (volumeSprites [Volume.volumeIndex] != null) {
			img.sprite = volumeSprites [Volume.volumeIndex];
		}
		if (Volume.volumeIndex == 0) {
			audioS.volume = 0.30f;
		} else if (Volume.volumeIndex == 1) {
			audioS.volume = 0.20f;
		} else if (Volume.volumeIndex == 2) {
			audioS.volume = 0.10f;
		} else if (Volume.volumeIndex == 3) {
			audioS.volume = 0.00f;
		}
			
	}
}
