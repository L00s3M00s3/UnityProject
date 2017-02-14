using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System.Collections.Generic;


public class WarpControlled : MonoBehaviour {
	//public int levelnum = 1; //start level 1
	public string LeveltoLoad;
	public AudioClip openDoor;


	IEnumerator OnTriggerEnter2D(Collider2D other)
	{
		
		if (other.tag == "Player")
		{
			//AudioSource.PlayClipAtPoint (openDoor, transform.position);
			//screenFading sf = GameObject.FindGameObjectWithTag ("Fader").GetComponent<screenFading> ();
			//yield return StartCoroutine(sf.FadeToBlack());
			SceneManager.LoadScene(LeveltoLoad);
            GameController.lastPosition[SceneManager.GetActiveScene().buildIndex] = other.transform.position;
            Debug.Log(GameController.lastPosition[SceneManager.GetActiveScene().buildIndex]);
            //yield return StartCoroutine (sf.FadeToClear ());
            yield return null;
		}

        
	}

}