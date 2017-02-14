using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnLight : Overlap_Generic {

	public bool LightOn;
	// Use this for initialization

	void Start () {
		LightOn = true;

	}
	
	// Update is called once per frame
	void Update () {

		if (LightOn) {
		
			if (overlap && Input.GetKeyDown (KeyCode.E)) {
			
			//deactivate light
				GetComponent<Light>().enabled = false;
				LightOn = false;

			}
		}

		if (!LightOn) {
			
			if (overlap && Input.GetKeyDown (KeyCode.E)) {

				//reactivate light
				GetComponent<Light>().enabled = true;
				LightOn = true;
				return;
		
		}
	}
}
}
