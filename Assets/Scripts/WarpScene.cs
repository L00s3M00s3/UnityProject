using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class WarpScene : MonoBehaviour {
	//public int levelnum = 1; //start level 1

	public string Level;
	//public GameObject sf;

	IEnumerator OnTriggerEnter2D (Collider2D other)
	{



		if (other.tag == "Player") {

			//levelnum += 1; //increment to next level
			SceneManager.LoadScene(Level);
			
			screenFading sf = GameObject.FindGameObjectWithTag ("Fader").GetComponent<screenFading> ();

		    yield return StartCoroutine(sf.FadeToBlack());
			yield return StartCoroutine (sf.FadeToClear ());


		
		}
	}

}
