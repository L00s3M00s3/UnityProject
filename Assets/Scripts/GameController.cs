using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public static GameController instance = null;

	// Use this for initialization
	void Awake () {
	
		if (instance == null) {
			
			instance = this;
		} else if (instance != this) {
		
			Destroy (gameObject);
		}

		DontDestroyOnLoad (gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
