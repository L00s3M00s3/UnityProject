using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ice_Detection : MonoBehaviour {
    [HideInInspector]
    public bool IceDetection,OnIce = false;
	void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Ice")
        {
            OnIce = true;
            IceDetection = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Ice")
        {
            OnIce = false;
            IceDetection = false;
        }
    }
}
