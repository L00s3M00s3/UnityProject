using UnityEngine;
using System.Collections;
using UnityEditor;
using System.Text;
using System.IO;
using System.Text.RegularExpressions;
using System.Collections.Generic;

public class Parser : MonoBehaviour {
	struct DialogueLine
	{
		public string name;
		public string content;
		public int pose;



		public DialogueLine(string Name, string Content, int Pose)
		{
			name = Name;
			content = Content;
			pose = Pose;


		}
	}
	public int count;
	List<DialogueLine> LINES;
	public string[] lines;
	// Use this for initialization

	public void LoadDialogue(TextAsset textfile)
	{
		LINES = new List<DialogueLine>();
		if (textfile != null)
		{

			lines = (textfile.text.Split('\n'));

            count = lines.Length-1;

            for (int i = 0; i < lines.Length; i++)
			{


				string dialougueChunk = lines[i];
				string[] dialogue = dialougueChunk.Split(';');
				DialogueLine lineEntry = new DialogueLine(dialogue[0], dialogue[1], int.Parse(dialogue[2]));
				Debug.Log(dialogue[0]);
				LINES.Add(lineEntry);
			}
			

		}
	}




	public string GetName(int linenumber)
	{
		if (linenumber < LINES.Count)
		{
			return LINES[linenumber].name;
		}
		return "";
	}

	public string GetContent(int linenumber)
	{
		if (linenumber < LINES.Count)
		{
			return LINES[linenumber].content;
		}
		return "";
	}

	public int GetPose(int linenumber)
	{
		if (linenumber < LINES.Count)
		{
			return LINES[linenumber].pose;
		}
		return 0;
	}
	/*
    public string GetPosition(int linenumber)
    {
        if (linenumber < LINES.Count)
        {
            return LINES[linenumber].position;
        }
        return "";
    }
    */



}