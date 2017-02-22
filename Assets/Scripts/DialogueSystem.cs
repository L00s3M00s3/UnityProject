using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class DialogueSystem: MonoBehaviour {



	Parser parser;

	public GameObject textbox;
	public Text theText,name;
	public TextAsset textFile;
	public string[] textLines;
	public string dialogue, characterName,position;
	int pose;
	Image[] characterimages;
	public int currentLine, endLine;
	public GameObject portraits;
	PlayerMovement playermovement;
	public bool active, freezePlayer, buttonPress;
	bool waitforpress;
	bool isRunning = false;
	private bool isTyping = false;
	private bool cancelTyping = false;
	public float typeSpeed;


	// Use this for initialization
	void Start()
	{
		dialogue = "";
		characterName = "";
		pose = 0;
		position = "";
		parser = GameObject.Find("DialogueManager").GetComponent<Parser>();

		playermovement = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>();



		if (textFile != null)
		{
			textLines = (theText.text.Split('\n'));

		}

		if (endLine == 0)
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
	void Update()
	{

		if (!active)
		{
			return;
		}
		//theText.text = textLines[currentLine];

		if (Input.GetKeyDown(KeyCode.E))
		{

			if (!isTyping)
			{

				ResetImage();
				currentLine += 1;
				ParseLines();
				SetSpritePositions(position);   
				UpdateUI();
				DisplayImages();

				if (currentLine > endLine)
				{

					DisableText();
				}
				else {
					if (!isRunning)
					{
						StartCoroutine(TextScroll(dialogue));
					}
				}
			}

			//else if scrolling, and isnt already cancelled, cancel typing.
			else if (isTyping && !cancelTyping)
			{

				cancelTyping = true;

			}
		}
	}


	private IEnumerator TextScroll(string lineOfText)
	{
		isRunning = true;
		int letter = 0;
		theText.text = "";
		isTyping = true;
		cancelTyping = false;

		while (isTyping && !cancelTyping && (letter < lineOfText.Length - 1))
		{

			theText.text += lineOfText[letter];
			letter += 1;
			yield return new WaitForSeconds(typeSpeed);
		}

		//if cancelled:

		theText.text = lineOfText;
		isTyping = false;
		cancelTyping = false;
		isRunning = false;

	}

	public void EnableText()
	{
		endLine = parser.count;
		GenericInteraction.engaged = true;
		textbox.SetActive(true);
		active = true;

		ParseLines();
		SetSpritePositions(position);
		UpdateUI();
		DisplayImages();

		playermovement.canMove = false;
		playermovement.anim.SetBool("isWalking", false);

		if (!isRunning)
		{
			StartCoroutine(TextScroll(dialogue));
		}

	}

	public void DisableText()
	{
		GenericInteraction.engaged = false;
		freezePlayer = false;
		textbox.SetActive(false);
		active = false;
		playermovement.canMove = true;
		currentLine = 0;
		characterimages = portraits.GetComponentsInChildren<Image>();
		for(int i = 0; i < characterimages.Length; i++)
		{
			characterimages[i].enabled = false;
		}

	}

	public void ReloadScript(TextAsset theText)
	{

		if (theText != null)
		{
			textLines = new string[1];
			textLines = (theText.text.Split('\n'));
		}
	}

	void DisplayImages()
	{
		if (characterName != "")
		{
			GameObject character = portraits.transform.Find(characterName).gameObject;

			Image currImage = character.GetComponent<Image>();
			currImage.enabled = true;
			currImage.sprite = character.GetComponent<Character_Portrait>().characterPose[pose];
		}
	}

	void SetSpritePositions(string pos)
	{
		Debug.Log(pos);
		switch (pos)
		{
		case "L":
			theText.rectTransform.localPosition = Vector3.left * 10;
			break;
		case "R":
			theText.rectTransform.localPosition = -Vector3.left * 10;
			break;
		default:
			theText.rectTransform.Translate(Vector3.zero);
			break;
		}

	}

	void UpdateUI()
	{
		name.text = characterName;
	}

	void ResetImage()
	{

		if (characterName != "")
		{
			GameObject character = portraits.transform.Find(characterName).gameObject;
			Image currImage = character.GetComponent<Image>();
			currImage.enabled = false;
		}

	}
	void ParseLines()
	{
		characterName = parser.GetName(currentLine);
		dialogue = parser.GetContent(currentLine);
		pose = parser.GetPose(currentLine);

	}
}
