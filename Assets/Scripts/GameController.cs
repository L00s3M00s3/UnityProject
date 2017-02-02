using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class GameController : MonoBehaviour {

	public static GameController instance = null;
    public static List<string> visitedLevels;

    // Use this for initialization
    void Awake () {
	
		if (instance == null) {
			
			instance = this;
            visitedLevels = new List<string>(1);
		} else if (instance != this) {
		
			Destroy (gameObject);
		}

		DontDestroyOnLoad (gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public static bool HasItBeenLoaded(string level)
    {
        if (!visitedLevels.Contains(level))
        {
            visitedLevels.Add(level);
            return true;
        }
        else
        {
            Application.Quit();
            return false;
        }
    }
}
