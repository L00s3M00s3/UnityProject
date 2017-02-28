using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
//This is a script that Manages when specific triggers need to be activated at which stage in the game
//NOTE: This should not be loaded onto a game manager object as it will prevent that Awake from running
//This should be attached to a PREFAB called trigger manager, which is a parent to all the triggers needed in the scene
public class TriggerManager : MonoBehaviour {
    //Initialization to our required arrays
    public GameObject[] Alltriggers, Stage1, Stage2, Stage3, Stage4;
    
	
    void Awake()
    {
        //Below is probably a very ineffecient way to find triggers, but it is the only way currently found to find tags by partial strong matching
        Alltriggers = FindObjectsOfType < GameObject >() as GameObject[];
        //These are just fine to use as is as they will only be as long as they are required to be
        //NOTE: In testing it was discovered that the unity Find objects with tag will only run when it recognizes a tag within the inspector, so ensure you initialize a tag such as "Stage5" in the inspector before you add it here
        Stage1 = GameObject.FindGameObjectsWithTag("Stage1");
        Stage2 = GameObject.FindGameObjectsWithTag("Stage2");
        Stage3 = GameObject.FindGameObjectsWithTag("Stage3");
        Stage4 = GameObject.FindGameObjectsWithTag("Stage4");
    }

    void Start()
    {
        TriggerManagement();
    }

    void TriggerManagement()
    {
        //Simple switch like we have used for Orpheus Stages and Inventory
        switch (stageSetter.currentStage)
        {
            //Regardeless of what stage the game is in, it will first turn off ALL triggers with the string "Stage in their name"
            case stageSetter.GameStages.Start:
                TurnoffAll();
                TurnemOn(Stage1);
                break;
            case stageSetter.GameStages.Matches:
                TurnoffAll();
                TurnemOn(Stage2);
                break;
            case stageSetter.GameStages.DarkRoom:
                TurnoffAll();
                TurnemOn(Stage3);
                break;
            default:
                TurnoffAll();
                break;
            
        }
    }
    //Simple function that will activate all of the items in the array provided as an argument
    void TurnemOn(GameObject[] stageArray)
    {
        if (stageArray != null)
        {
            for (int i = 0; i < stageArray.Length; i++)
            {
                stageArray[i].SetActive(true);
            }
        }
    }
    //This is why this might be slightly ineffecient, as this is literally an array of all the gameobjects in a scene.
    //It will then search through all of the items tags, and using a comparative string will turn all objects off who's tag contains the string "Stage"
    void TurnoffAll()
    {
        for(int i = 0; i < Alltriggers.Length; i++)
        {
            if (Alltriggers[i].tag.Contains("Stage"))
            {
                Alltriggers[i].SetActive(false);
            }
        }
    }
   
	
}
