using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ice_Detection : MonoBehaviour {
    [HideInInspector]
    public bool IceDetection = false;
	void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Ice")
        {
            IceDetection = true;
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Ice")
        {
            IceDetection = false;
        }
    }
}
