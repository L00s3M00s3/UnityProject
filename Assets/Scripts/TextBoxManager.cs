using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class TextboxManager : MonoBehaviour {

	public GameObject textbox;

	public Text theText;

	public TextAsset textFile;
	public string[] textLines;

	public int currentLine, endLine;

	PlayerMovement playermovement;

	public bool active,freezePlayer,buttonPress;
	bool waitforpress;

	bool isRunning = false;
	private bool isTyping = false;
	private bool cancelTyping = false;
	public float typeSpeed;


	// Use this for initialization
	void Start () {
		playermovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();



		if (textFile != null)
		{
			textLines = (theText.text.Split('\n'));
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
		//theText.text = textLines[currentLine];

		if (Input.GetKeyDown(KeyCode.E))
		{

			if (!isTyping) {

				currentLine += 1;

				if (currentLine > endLine) {

					DisableText ();
				} else {
					if (!isRunning) {
						StartCoroutine (TextScroll (textLines [currentLine]));
					}
				}
			} 

			//else if scrolling, and isnt already cancelled, cancel typing.
			else if(isTyping && !cancelTyping){

				cancelTyping = true;

			}
		}
	}


	private IEnumerator TextScroll (string lineOfText) {
		isRunning = true;
		int letter = 0;
		theText.text = "";
		isTyping = true;
		cancelTyping = false;

		while (isTyping && !cancelTyping && (letter < lineOfText.Length - 1)) {

			theText.text += lineOfText [letter];
			letter += 1;
			yield return new WaitForSeconds (typeSpeed);
		}

		//if cancelled:

		theText.text = lineOfText;
		isTyping = false;
		cancelTyping = false;
		isRunning = false;

	}

	public void EnableText()
	{

		GenericInteraction.engaged = true;
		textbox.SetActive (true);
        

		active = true;
		if (freezePlayer) {
			playermovement.canMove = false;
		}
		if (!isRunning) {
			StartCoroutine (TextScroll (textLines [currentLine]));
		}
        freezePlayer = true;
    }

	public void DisableText()
	{
		GenericInteraction.engaged = false;
        freezePlayer = false;
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