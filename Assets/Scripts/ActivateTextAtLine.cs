using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateTextAtLine : MonoBehaviour{

	public void ActivateCurrentFile(TextAsset theText,int startLine,int endLine,TextboxManager textBox)
	{
		textBox.ReloadScript(theText);
		textBox.currentLine = startLine;
		textBox.endLine = endLine;
        textBox.freezePlayer = true;
		textBox.EnableText();
	}
}