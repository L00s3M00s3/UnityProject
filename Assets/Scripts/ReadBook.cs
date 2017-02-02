using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadBook : Overlap_Generic {

    public TextAsset theText;

    public int startLine, endLine;

    TextBoxManager textBox;

    ActivateTextAtLine textAtLine;

    void Start()
    {
        textBox = FindObjectOfType<TextBoxManager>();   
        textAtLine = FindObjectOfType<ActivateTextAtLine>();
    }

    // Update is called once per frame
    void Update () {

		if (overlap) {
            textAtLine.ActivateCurrentFile(theText, startLine, endLine, textBox);
		}
	}
}
