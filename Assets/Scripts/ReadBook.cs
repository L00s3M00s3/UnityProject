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
            switch (Inventory.currentItem){
                case Inventory.Items.Duster:
                case Inventory.Items.Unarmed:
                    GameObject.Find("Arrow").GetComponent<SpriteRenderer>().enabled = false;
                    textAtLine.ActivateCurrentFile(theText, startLine, endLine, textBox);
                    AudioSource.PlayClipAtPoint(turnPage, transform.position);
                    Debug.Log("Hands");
                    break;
                default:
                    Debug.Log("Broken");
                    break;
            }
			
		}
	}
}