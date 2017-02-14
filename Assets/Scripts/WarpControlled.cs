using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;


public class WarpControlled : Overlap_Generic {
	//public int levelnum = 1; //start level 1
	public string LeveltoLoad;
	public AudioClip openDoor;
    GameObject Player;

    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
    }


    void Update()
    {
        if (overlap)
        {
            //AudioSource.PlayClipAtPoint (openDoor, transform.position);
            //screenFading sf = GameObject.FindGameObjectWithTag ("Fader").GetComponent<screenFading> ();
            //yield return StartCoroutine(sf.FadeToBlack());
            SceneManager.LoadScene(LeveltoLoad);
            GameController.lastPosition[SceneManager.GetActiveScene().buildIndex] = Player.transform.position;

            //yield return StartCoroutine (sf.FadeToClear ());
        }
    }

    /*
	IEnumerator OnTriggerEnter2D(Collider2D other)
	{
		
		if (other.tag == "Player")
		{
			//AudioSource.PlayClipAtPoint (openDoor, transform.position);
			//screenFading sf = GameObject.FindGameObjectWithTag ("Fader").GetComponent<screenFading> ();
			//yield return StartCoroutine(sf.FadeToBlack());
			SceneManager.LoadScene(LeveltoLoad);
            GameController.lastPosition[SceneManager.GetActiveScene().buildIndex] = other.transform.position;
            
            //yield return StartCoroutine (sf.FadeToClear ());
            yield return null;
		}

        
	}
    */

}