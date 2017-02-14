using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Overlap_Generic : MonoBehaviour {


	public Transform pointA, pointB;

	public LayerMask layer;
	[HideInInspector]
	public bool overlap;


	void FixedUpdate()
	{
		overlap = Physics2D.OverlapArea(pointA.position, pointB.position, layer);
	}
}