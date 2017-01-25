using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderMove : Enemy
{

    // Use this for initialization
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {

        if (!GetComponentInChildren<Pattern_Control>().vulnerable)
        {
            switch (GetComponentInChildren<Pattern_Control>()._state)
            {
                case Pattern_Control.State.relaxed:
                    MoveTowards();
                    break;
                case Pattern_Control.State.worried:
                    MoveAway();
                    break;
            }
        }
        else
        {
            Idle();
        }
    }


}
