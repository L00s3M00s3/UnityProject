using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreCollision : MonoBehaviour {

	public GameObject bullet;

	// Use this for initialization
	void Start () {
		Physics2D.IgnoreCollision (bullet.GetComponent<Collider2D>(), GetComponent<Collider2D> ());
	}
	

}
