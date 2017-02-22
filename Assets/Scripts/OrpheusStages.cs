using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrpheusStages : MonoBehaviour {


	public Transform[] Stages;
    public TextAsset[] text;
    public static int stage;


	// Use this for initialization
	void Start ()
    {
            Switchingstates();
    }
    
	
	// Update is called once per frame
	void Update () {
        
	}

    void Switchingstates()
    {
        Debug.Log(stageSetter.currentStage);
        switch (stageSetter.currentStage)
        {
            case stageSetter.GameStages.Start:
                gameObject.transform.position = Stages[(int)stageSetter.currentStage].position;
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
                gameObject.GetComponent<MasterDialogue>().ReloadScript(text[(int)stageSetter.currentStage]);
                break;
            case stageSetter.GameStages.Matches:
                gameObject.transform.position = Stages[(int)stageSetter.currentStage].position;
                gameObject.GetComponent<SpriteRenderer>().enabled = true;
                gameObject.GetComponent<MasterDialogue>().ReloadScript(text[(int)stageSetter.currentStage]);
                break;
            case stageSetter.GameStages.DarkRoom:
                gameObject.transform.position = Stages[(int)stageSetter.currentStage].position;
                gameObject.GetComponent<SpriteRenderer>().enabled = true;
                gameObject.GetComponent<MasterDialogue>().ReloadScript(text[(int)stageSetter.currentStage]);
                break;

            default:
                gameObject.transform.position = Stages[1].position;
                gameObject.GetComponent<MasterDialogue>().ReloadScript(text[1]);
                break;
        }
    }

}
