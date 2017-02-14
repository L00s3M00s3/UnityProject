using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sink_Manager : MonoBehaviour {

    public  GameObject[] Sinks;
    bool finished;
    int count = 0;
    int Things;
    // Use this for initialization
    void Start () {
        Sinks = GameObject.FindGameObjectsWithTag("Sink");
        for(int i = 0; i < Sinks.Length; i++)
        {
            Sinks[i].GetComponent<Sink_Control>().position = i;
        }
       
	}
	
	// Update is called once per frame
	void Update () {
        
		
	}

    public  void SinkChecking(int position)
    {
        if (finished)
        {
            Debug.Log("Better not touch anything incase I screw it up again");
            return;
        }
        int before, after;
        Sinks[position].GetComponent<Sink_Control>().FixSink();
        before = position -1;
        if (before < 0)
        {
            before = Sinks.Length-1;
        }
        Sinks[before].GetComponent<Sink_Control>().FixSink();
        after = position+1;
        if (after > Sinks.Length-1)
        {
            after = 0;
        }
        Sinks[after].GetComponent<Sink_Control>().FixSink();
        SinkFinish();
        if (Things >= Sinks.Length)
        {
            finished = true;
        }
        
        

    }
    void SinkFinish()
    {
        int fixedSinks = 0;
        for(int i = 0; i < Sinks.Length; i++)
        {

            if (Sinks[i].GetComponent<Sink_Control>().isLeaking)
            {
                fixedSinks = fixedSinks - 1;
                if (fixedSinks < 0)
                {
                    fixedSinks = 0;
                }
            }
            else
            {
                fixedSinks = fixedSinks + 1;
            }
        }
        Things = fixedSinks;
        Debug.Log(Things);
    }
}
