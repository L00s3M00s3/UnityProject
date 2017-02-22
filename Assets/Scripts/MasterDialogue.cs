using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterDialogue : Overlap_Generic {

	public TextAsset theText;

	public int startLine, endLine;


    Parser parser;
    DialogueSystem dialogueSystem;

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
			textAtLine.ActivateCurrentFile(theText, startLine, endLine, textBox);
	
		}
	}

    public void ReloadScript(TextAsset newText)
    {
        if (newText != null)
        {
            parser.LoadDialogue(newText);
            dialogueSystem.endLine = parser.count;
        }
    }
}