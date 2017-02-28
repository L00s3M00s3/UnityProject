using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolidMirror : MirrorShuffle {

	// Use this for initialization
	void Start () {
        if (rightFacing)
        {
            transform.Rotate(-Vector3.forward, 90.0f);
        }
    }
	
	// Update is called once per frame
	void Update () {
        if (overlap)
        {
            return;
        }
        if (shinning)
        {
            //debugReflection(origin);
            if (hit)
            {
                if (hit.collider.tag == "Mirror")
                {
                    hit.collider.gameObject.GetComponent<MirrorShuffle>().shinning = true;
                    hit.collider.gameObject.GetComponent<MirrorShuffle>().origin = gameObject.transform.position;
                    encountered = hit.collider.gameObject;
                }
                if (hit.collider.tag == "Plant")
                {
                    Debug.Log("Plant Growing");
                }
            }
            else
            {
                Debug.Log(gameObject.name + "isn't hitting anything");
                if (encountered != null)
                {
                    encountered.GetComponent<MirrorShuffle>().shinning = false;
                }
            }
        }
        else
        {
            if (encountered != null)
            {
                encountered.GetComponent<MirrorShuffle>().shinning = false;
            }
        }

    }
}
