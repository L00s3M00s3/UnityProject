using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuseBox : Overlap_Generic {

	public static bool repaired = false;
	AudioSource audio;

	// Use this for initialization
	void Start () {
		audio = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frames
	void Update () {

		if (overlap && Input.GetKeyDown (KeyCode.E)) {

			repaired = true;
			audio.mute = true;
			Debug.Log ("Lights Repaired");
			GetComponent<Animator> ().SetBool ("isRepaired", true);
			//GameObject.FindGameObjectsWithTag ("Light").GetComponent<LightFlicker> ().enabled = false;
		}
	}
}
