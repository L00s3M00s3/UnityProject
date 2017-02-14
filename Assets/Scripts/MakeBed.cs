using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeBed : Overlap_Generic {



	bool isMade;
	public AudioClip BedMaking;
	private Animator anim;
	float cooldown = 1.0f;

	// Use this for initialization
	void Start () {

		anim = gameObject.GetComponent<Animator> ();
		isMade = false;

	}



	// Update is called once per frame
	void Update () {
		if (overlap) {
			Makebed();
		}
		if (cooldown > 0)
		{
			cooldown -= Time.deltaTime;
		}

	}

	void Makebed()
	{
		if (cooldown <= 0)
		{
			if (isMade)
			{
				anim.SetTrigger("unmakeBed");
				AudioSource.PlayClipAtPoint(BedMaking, transform.position);
				cooldown = 1.0f;
				isMade = false;
			}
			else
			{
				anim.SetTrigger("makeBed");
				AudioSource.PlayClipAtPoint(BedMaking, transform.position);
				cooldown = 1.0f;
				isMade = true;
			}
		}

	}
}