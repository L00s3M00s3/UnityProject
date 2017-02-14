using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sink_Control : Overlap_Generic {
    
    public bool isLeaking;
    [HideInInspector]
    public int position;
    float countdown = 1.0f;


	// Use this for initialization
	void Start()
    {
        if (isLeaking)
        {
            gameObject.GetComponent<Renderer>().material.color = Color.blue;
        }
        else
        {
            gameObject.GetComponent<Renderer>().material.color = Color.yellow;
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (overlap&&countdown<=0)
        {
            GetComponentInParent<Sink_Manager>().SinkChecking(position);
            countdown = 1.0f;
        }
        if (countdown > 0)
        {
            countdown -= Time.deltaTime;
        }
		
	}

    public void FixSink()
    {
        
            Debug.Log("This is sink number: " + position);
            if (isLeaking)
            {
                countdown = 1.0f;
            
                isLeaking = false;
                gameObject.GetComponent<Renderer>().material.color = Color.yellow;
            }
            else
            {
                countdown = 1.0f;
                isLeaking = true;
           
            gameObject.GetComponent<Renderer>().material.color = Color.blue;
            }
        
    }
}
