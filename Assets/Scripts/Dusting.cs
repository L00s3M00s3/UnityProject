using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dusting : Overlap_Generic {

	private Color color;
	public float FadeSpeed;

    


	void Start()
	{
		color = GetComponent<SpriteRenderer> ().color;
	}

    void Update()
    {
		if (overlap && Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine("Cleaning");
        }

		if(gameObject.GetComponent<SpiderManager>().cleaned){
			gameObject.GetComponent<SpriteRenderer> ().color = new Color (color.r, color.g, color.b, color.a -= FadeSpeed * Time.deltaTime);

			if (color.a <= 0)
			{
				Destroy(gameObject);

			}
    }
}

    IEnumerator Cleaning()
    {
        gameObject.GetComponent<SpiderManager>().cleaned = true;
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().iscleaning = true;
        /*Set Some form of animation trigger here*/
        yield return new WaitForSeconds(1.0f);
        GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerMovement>().iscleaning = false;
    }
}
