using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterFade : MonoBehaviour {

	private Color colorDown,colorUp;
	public float fadeTime;


	void Start () {

        colorDown = GetComponent<SpriteRenderer>().color;
        colorUp = GetComponent<SpriteRenderer> ().color;
        colorUp.a = 1.0f;
        colorDown.a = 0.0f;
	}

    void Update()
    {
        Fade(fadeTime);
    }


    void Fade(float fadeTime)
    {
        if (LightFlicker.fade)
        {
            GetComponent<SpriteRenderer>().color = new Color(colorDown.r, colorDown.g, colorDown.b, colorDown.a += 0.5f * Time.deltaTime);
            if (colorUp.a < 1.0f)
            {
                colorUp.a = 1.0f;
            }
        }
        else
        {
            GetComponent<SpriteRenderer>().color = new Color(colorUp.r, colorUp.g, colorUp.b, colorUp.a -= fadeTime * Time.deltaTime);
            if (colorDown.a > 1.0f)
            {
                colorDown.a = 0.0f;
            }
        }
    }

    

	
}
