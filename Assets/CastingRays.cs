using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CastingRays : MonoBehaviour {

    GameObject encountered;
    LineRenderer line;
    // Update is called once per frame

    void Awake()
    {
        line = GetComponent<LineRenderer>();
    }

    void Start()
    {
        line.SetPosition(0, gameObject.transform.position);
        line.SetPosition(1, gameObject.transform.position);
        line.startWidth = 0.1f;
        line.endWidth = 0.1f;


    }
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
                line.SetPosition(1, hit.collider.gameObject.transform.position);
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
