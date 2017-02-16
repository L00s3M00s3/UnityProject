using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastingRays : MonoBehaviour {

    GameObject encountered;
	// Update is called once per frame
	void Update () {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, Mathf.Infinity, 1<<LayerMask.NameToLayer("Mirror"));
        Debug.DrawRay(transform.position, -Vector2.up, Color.red);

        if (hit)
        {
            if (hit.collider.tag == "Mirror")
            {
                hit.collider.gameObject.GetComponent<MirrorShuffle>().shinning = true;
                hit.collider.gameObject.GetComponent<MirrorShuffle>().origin = gameObject.transform.position;
                encountered = hit.collider.gameObject;
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
