using UnityEngine;
using System.Collections;

public class updateOrderInLayer : MonoBehaviour {

	private SpriteRenderer tempRend;


	void Start () {
		tempRend = GetComponent<SpriteRenderer>();
	}


	void LateUpdate () {

		tempRend.sortingOrder = (int)Camera.main.WorldToScreenPoint (tempRend.bounds.min).y * -1;
	}
}
