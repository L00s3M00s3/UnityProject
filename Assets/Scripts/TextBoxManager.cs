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
    bool istyping,cancelTyping;
    public float typeSpeed;

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

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (!istyping)
            {
                currentLine++;

                if (currentLine > endLine)
                {
                    DisableText();
                }
                else
                {
                    StartCoroutine(TextScroll(textLines[currentLine]));
                }
            }
            else if(istyping&&!cancelTyping)
            {
                cancelTyping = true;
            }
        }

        
		
	}

    IEnumerator TextScroll(string lineOfText)
    {
        int letter = 0;
        theText.text = "";
        istyping = true;
        cancelTyping = false;
        while(istyping&&!cancelTyping&&(letter<lineOfText.Length - 1))
        {
            theText.text += lineOfText[letter];
            letter += 1;
            yield return new WaitForSeconds(typeSpeed);
        }
        theText.text = lineOfText;
        istyping = false;
        cancelTyping = false;
    }

    public void EnableText()
    {
        
        textbox.SetActive(true);
        active = true;
        GenericInteraction.engaged = true;
        if (freezePlayer)
        {
            playermovement.canMove = false;
        }
        StartCoroutine(TextScroll(textLines[currentLine]));
    }

    public void DisableText()
    {
        textbox.SetActive(false);
        active = false;
        playermovement.canMove = true;
        GenericInteraction.engaged = false;

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
