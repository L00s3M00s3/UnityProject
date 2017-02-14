using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirCondition : Overlap_Generic {

	private Color[] colour;
	public float fadeSpeed;
	bool interacted;
	private Ice_Detection Ice;
	AudioSource audio;
	private GameObject[] frost;


	// Use this for initialization
	void Start () {

		audio = GetComponent<AudioSource> ();
		Ice = GameObject.FindGameObjectWithTag ("Player").GetComponent<Ice_Detection> ();

		frost = GameObject.FindGameObjectsWithTag ("Frost");
		colour = new Color[frost.Length];
		for(int i = 0; i < frost.Length; i++)
		{
			colour[i] = frost[i].GetComponent<SpriteRenderer>().color;
		}



	}

	void Update()
	{
		Debug.Log(frost.Length);
		Debug.Log(colour.Length);
		if (overlap) {

			interacted = true;
			audio.Play();

		}
		if (interacted)
		{
			
			StartCoroutine("FrostFade");
			Ice.IceDetection = false;

			GameObject.FindGameObjectWithTag("Ice").GetComponent<BoxCollider2D>().enabled = false;
		}

	}

	IEnumerator FrostFade()
	{
		for (int i = 0; i < frost.Length; i++)
		{


			frost[i].GetComponent<SpriteRenderer>().color = new Color(colour[i].r, colour[i].g, colour[i].b, colour[i].a -= fadeSpeed * Time.deltaTime);



		}
		return null;
	}
}