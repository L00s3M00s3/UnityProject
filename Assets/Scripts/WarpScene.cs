using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;


public class WarpScene : MonoBehaviour {
    //public int levelnum = 1; //start level 1

    string[] availableLevels = {"Combat","FreezerRoom","Slide","TrapRoom" };
    int random;
    static List<string> visitedLevels;
    string LeveltoLoad = "";

	//public GameObject sf;
    void Awake()
    {
        do
        {
            random = Random.Range(0, availableLevels.Length-1);
            LeveltoLoad = availableLevels[random];
        } while (visitedLevels.Contains(LeveltoLoad));
        visitedLevels.Add(LeveltoLoad);
        Debug.Log(visitedLevels);
        
    }
	void OnTriggerEnter2D (Collider2D other)
	{
        Debug.Log(visitedLevels);
        if (other.tag == "Player") {

			//levelnum += 1; //increment to next level
			SceneManager.LoadScene(LeveltoLoad);
			
			//screenFading sf = GameObject.FindGameObjectWithTag ("Fader").GetComponent<screenFading> ();

			//yield return StartCoroutine(sf.FadeToBlack());
			//yield return StartCoroutine (sf.FadeToClear ());
		}
	}

}
