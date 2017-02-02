using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;


public class WarpScene : MonoBehaviour {
    //public int levelnum = 1; //start level 1

    string[] levelList = {"Combat","FreezerRoom","TrapRoom" };
    static List<string> availableLevels;
    int random;
    bool end;
    string LeveltoLoad;

	//public GameObject sf;
    void Start()
    {
        availableLevels = new List<string>(levelList);
        if (availableLevels.Count >= 0)
        {
            Debug.Log("Levels available: " + availableLevels.Count);
        }
        else
        {
            Application.Quit();
            Debug.Log("Error Loading levels, check the array");
        };

        if (availableLevels.Count != GameController.visitedLevels.Count)
        {
            do
            {
                random = Random.Range(0, availableLevels.Count);
                LeveltoLoad = availableLevels[random];
            } while (!GameController.HasItBeenLoaded(LeveltoLoad));
            
        }
        else
        {
            LeveltoLoad = "FinalRoom";
            end = true;
        }
        Debug.Log(GameController.visitedLevels.Count);
        Debug.Log(LeveltoLoad);
        
    }
	void OnTriggerEnter2D (Collider2D other)
	{
       
        if (other.tag == "Player") {

            //levelnum += 1; //increment to next level
            if (!end)
            {
                SceneManager.LoadScene(LeveltoLoad);
            }
            else
            {
                if(Application.platform.Equals(RuntimePlatform.WindowsEditor))
                UnityEditor.EditorApplication.isPlaying = false;
            }
			
			//screenFading sf = GameObject.FindGameObjectWithTag ("Fader").GetComponent<screenFading> ();
			//yield return StartCoroutine(sf.FadeToBlack());
			//yield return StartCoroutine (sf.FadeToClear ());
		}
	}

}
