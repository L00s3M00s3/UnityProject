using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dusting : MonoBehaviour {

    public Transform pointA, pointB;
    public LayerMask layer;
    bool overlap;

    void FixedUpdate()
    {
        overlap = Physics2D.OverlapArea(pointA.position, pointB.position, layer);
    }

    void Update()
    {
        if (overlap && Input.GetKeyDown(KeyCode.E))
        {
            gameObject.GetComponent<SpiderManager>().cleaned = true;
        }
    }
}
