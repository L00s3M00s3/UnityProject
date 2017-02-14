using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Collections;

public class GameController : MonoBehaviour {

	public static GameController instance = null;
	public static List<string> visitedLevels;
    public static List<Vector3> lastPosition;
	public static bool goal;

	// Use this for initialization
	void Awake () {
        lastPosition = new List<Vector3>(SceneManager.sceneCountInBuildSettings-1);
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

	
}