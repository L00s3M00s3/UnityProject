﻿using UnityEngine;
using System.Collections;

public class Turret_Control : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(GameObject.FindGameObjectWithTag("Player").transform);
	
	}
}
