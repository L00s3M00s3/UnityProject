using UnityEngine;
using System.Collections;

public class Splat2D : MonoBehaviour {

	private Color color;
	public float FadeSpeed = 0.2f;


	// Use this for initialization
	void Start () {
	
		color = GetComponent<SpriteRenderer> ().color;
	}
	
	// Update is called once per frame
	void Update () {
	

		GetComponent<SpriteRenderer> ().color = new Color (color.r, color.g, color.b, color.a -= FadeSpeed * Time.deltaTime);

		if (color.a <= 0)
		{
			Destroy(gameObject);

		}

	}


}
