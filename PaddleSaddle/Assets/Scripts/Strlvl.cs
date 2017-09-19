using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Strlvl : MonoBehaviour {

	public Text strlvl;
	public Text crate;

	
	// Update is called once per frame
	void Update () {
		strlvl.text = "lv. " + Player.getStrlvl().ToString();
		crate.text = Main.getCrate().ToString ();
	}

	public void addStr () {
		int lvl = Player.getStrlvl ();
		if (Main.getCrate() == lvl * 10) {
			Player.incStrlvl ();
			Main.decCrate (lvl * 10);
		}
	}
}
