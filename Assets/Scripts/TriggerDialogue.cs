using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
//This is a script that allows us to activate text or dialogue after certain triggers have been activated
public class TriggerDialogue : MonoBehaviour {
    //Slot for us to put the required dialogue in as a .txt format
	public TextAsset theText;
    //Allows us to dictate the required start and enline(if none are dictated the default length of the .txt is used
	public int startLine, endLine;
    //bool used to determine if we have already activated the trigger, and will deactiavte the attached game object should it be the case
    public bool alreadytriggered;
    //For now the only way I have discovered to allow us to track the triggers is to manually enter ID's for them that correspond to entries in a multidimensional array
    public int number;
    //Call to the text box manager that holds the text box and name box
	TextboxManager textBox;
    //Call to the trigger controller which holds a jagged array to manage trigger activation through out scenes(found on the game manager)
    TriggerController_Test Controller;
    //Call to the activate text at line file which allows us to reload scripts loaded onto the Textbox Manger during runtime
	ActivateTextAtLine textAtLine;
    
    
    
	void Start()
	{
        //Assigning them
        textBox = FindObjectOfType<TextboxManager>();
        textAtLine = FindObjectOfType<ActivateTextAtLine>();
        //This method is invoked 0.1 seconds after that start method, the reason for this is that as the Trigger controller isn't active in the scene and is carried over with the game manger, it takes a fraction of a second more for it to be found, so we wait for it to load before we try to assign it
        Invoke("LateStart", 0.1f);
        
        
    }

	// Update is called once per frame
	void OnTriggerEnter2D (Collider2D other) {

		if (other.tag == "Player")
		{

            //GameController.hasbeenActivated[SceneManager.GetActiveScene().buildIndex][number] = true;
            textAtLine.ActivateCurrentFile(theText, startLine, endLine, textBox);

		}
	}

	void OnTriggerExit2D (Collider2D other)
	{
		if (other.tag == "Player") {
            //Debug.Log(GameController.hasbeenActivated[SceneManager.GetActiveScene().buildIndex][number]);
            //Call to the controller script to let them know this entry has now been activated
            Controller.Triggers[SceneManager.GetActiveScene().buildIndex][number] = true;
            gameObject.SetActive(false);
            

        }

	}

    void LateStart()
    {
        //Assigninment
        Controller = FindObjectOfType<TriggerController_Test>();
        //Sets the local bool already triggered to the entry stored in the Controller script(if it has never been assigned it will default to false)
        alreadytriggered = Controller.Triggers[SceneManager.GetActiveScene().buildIndex][number];
        //Should we have already triggered this we weill switch it off
        if (alreadytriggered)
        {
            gameObject.SetActive(false);
        }
    }
    }



