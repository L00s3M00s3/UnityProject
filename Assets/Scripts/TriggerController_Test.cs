using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
//This is part of the magic 
public class TriggerController_Test : MonoBehaviour {
    public bool[][] Triggers;
    
	// Use this for initialization
	void Awake () {
        Triggers = new bool[SceneManager.sceneCountInBuildSettings-1][];
        
        
        
	}
    void Start()
    {
        InitializeArray();
    }
	

    /*
	public static void setTrigger(int sceneNumber,bool[] numberofTriggers)
    {
        if (!alreadySet[sceneNumber])
        {
            Triggers[sceneNumber] = new bool[numberofTriggers.Length];
            for (int i = 0; i < numberofTriggers.Length; i++)
            {
                Triggers[sceneNumber][i] = numberofTriggers[i];
            }
            alreadySet[sceneNumber] = true;
        }
    }
    */

    void InitializeArray()
    {
        for(int i = 0; i < Triggers.Length; i++)
        {
            Triggers[i] = new bool[10];
        }
        
    }
}
