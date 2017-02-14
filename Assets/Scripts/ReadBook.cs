using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadBook : Overlap_Generic {

	public TextAsset theText;

	public int startLine, endLine;
	public AudioClip turnPage;

	TextboxManager textBox;

	ActivateTextAtLine textAtLine;

	void Start()
	{
		textBox = FindObjectOfType<TextboxManager>();
		textAtLine = FindObjectOfType<ActivateTextAtLine>();
	}

	// Update is called once per frame
	void Update () {

		if (overlap) {

			GameObject.Find ("Arrow").GetComponent<SpriteRenderer> ().enabled = false;

			textAtLine.ActivateCurrentFile(theText, startLine, endLine, textBox);
			AudioSource.PlayClipAtPoint (turnPage, transform.position);
		}
	}
}