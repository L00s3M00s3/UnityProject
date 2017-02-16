using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;
using System.Collections;

public class GameController : MonoBehaviour {

	public static GameController instance = null;
	public static List<string> visitedLevels;
    
    public static Vector3[] lastPosition;
	public static bool goal;

	// Use this for initialization
	void Awake () {
        

		if (instance == null) {
            lastPosition = new Vector3[SceneManager.sceneCountInBuildSettings - 1];

            for (int i = 0; i < lastPosition.Length; i++)
            {
                lastPosition[i] = Vector3.zero;
            }
            SpawnInventory();
            instance = this;
			visitedLevels = new List<string>(1);
		} else if (instance != this) {

			Destroy (gameObject);
		}
        
        DontDestroyOnLoad (gameObject);
	}

    void SpawnInventory()
    {
        Inventory.inventory = new bool[System.Enum.GetValues(typeof(Inventory.Items)).Length];
    }

	

	
}