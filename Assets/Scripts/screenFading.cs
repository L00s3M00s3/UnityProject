using UnityEngine;
using System.Collections;

public class screenFading : MonoBehaviour {

	Animator anim;
	bool isFading = false;


	void Start () {

		anim = GetComponent<Animator> ();
        StartCoroutine("FadeToClear");
        


	}

	public IEnumerator FadeToClear() {
		isFading = true;
		anim.SetTrigger ("FadeIn");

		while (isFading)
			yield return null;



	}

	public IEnumerator FadeToBlack() {

		isFading = true;
		anim.SetTrigger("FadeOut");

		while(isFading)
			yield return null;




	}


	void AnimationComplete () {

		isFading = false;
        Debug.Log("Fade Finished");
	}
}