using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Speedlvl : MonoBehaviour {

	public Text speedlvl;
	public Text crate;


	// Update is called once per frame
	void Update () {
		speedlvl.text = "lv. " + Player.getSpeedlvl().ToString ();
	}

	public void addSpeed () {
		int lvl = Player.getSpeedlvl ();
		if ((Main.getCrate()) == (lvl * 10)) {
			Player.incSpeedlvl ();
			Main.decCrate (lvl * 10);
		}
		speedlvl.text = "lv. " + Player.getStrlvl().ToString();
		crate.text = Main.getCrate().ToString ();
	}
}
