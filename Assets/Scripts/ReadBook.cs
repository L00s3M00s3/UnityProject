using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReadBook : MonoBehaviour {

	public Transform pointA, pointB;
	public LayerMask layer;
	bool overlap;

	// Use this for initialization
	void Start () {
		
	}

	void FixedUpdate()
	{
		overlap = Physics2D.OverlapArea(pointA.position, pointB.position, layer);
	}

	
	// Update is called once per frame
	void Update () {

		if (overlap && Input.GetKeyDown(KeyCode.E)) {
			Debug.Log ("Overlapping");
			//open book text
		
		}
	}
}
