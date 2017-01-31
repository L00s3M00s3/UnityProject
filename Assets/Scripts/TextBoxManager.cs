using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TextBoxManager : MonoBehaviour {

    public GameObject textbox;

    public Text theText;

    public TextAsset textFile;
    public string[] textLines;

    public int currentLine, endLine;

    PlayerMovement playermovement;

    public bool active,freezePlayer,buttonPress;
    bool waitforpress;

	// Use this for initialization
	void Start () {
        playermovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();

        

        if (textFile != null)
        {
            textLines = (textFile.text.Split('\n'));
        }

        if(endLine == 0)
        {
            endLine = textLines.Length - 1;
        }

        if (active)
        {
            EnableText();
        }
        else
        {
            DisableText();
        }
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (!active)
        {
            return;
        }
        theText.text = textLines[currentLine];

        if (Input.GetKeyDown(KeyCode.Space))
        {
            currentLine++;
        }

        if(currentLine > endLine)
        {
            DisableText();
        }
		
	}

    public void EnableText()
    {
        textbox.SetActive(true);
        active = true;
        if (freezePlayer)
        {
            playermovement.canMove = false;
        }
    }

    public void DisableText()
    {
        textbox.SetActive(false);
        active = false;
        playermovement.canMove = true;
    }

    public void ReloadScript(TextAsset theText)
    {
        if(theText != null)
        {
            textLines = new string[1];
            textLines = (theText.text.Split('\n'));
        }
    }
}
