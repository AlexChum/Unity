using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Brick : MonoBehaviour {

	// for future reference if audio is needed
	// public AudioClip crack;
	public Sprite[] hitSprites;
	public SpriteRenderer sr;
	public static int breakableCount = 0;
	public GameObject smoke;

	private int maxHits;
	private int timesHits = 0;
	private LevelManager levelManager;
	private bool isBreakable ;


	// Use this for initialization
	void Start () {
		isBreakable = (this.tag == "Breakable");

		if (isBreakable) {
			breakableCount++;
		}

		levelManager = GameObject.FindObjectOfType <LevelManager> ();
		sr = GetComponent<SpriteRenderer> ();
	}

	void OnCollisionEnter2D(Collision2D collision) {
		// AudioSource.PlayClipAtPoint (crack, transform.position);
		if (isBreakable) {
			HandleHits ();
		}
	}

	//++timeHits and Destroys Object and loadsprites
	void HandleHits () {
		
		timesHits++;
		maxHits = hitSprites.Length + 1;

		if (timesHits >= maxHits) {
			breakableCount--;
			levelManager.BreakableDestroyed ();
			PuffSmoke ();
			Destroy (gameObject);
		} else {
			LoadSprites ();
		}
	}

	void PuffSmoke () {
		GameObject smokepuff = Instantiate (smoke, this.transform.position, Quaternion.identity) as GameObject;
		ParticleSystem sp = smokepuff.GetComponent<ParticleSystem> ();
		var ps = sp.main;
		ps.startColor = sr.color;
	}

	//Change sprite everytime the brick is hit
	void LoadSprites () {
		
		int spriteIndex = timesHits - 1;

		if (hitSprites [spriteIndex] != null) {
			sr.sprite = hitSprites [spriteIndex];
		}
	}

}
