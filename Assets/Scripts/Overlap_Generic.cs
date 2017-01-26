using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Overlap_Generic : MonoBehaviour {

    Transform itempoint;
    public Vector2 boxSize;
    public LayerMask layer;
    [HideInInspector]
    public bool overlap;

    void Awake()
    {
        itempoint = gameObject.transform;
    }

    void FixedUpdate()
    {
        overlap = Physics2D.OverlapBox(itempoint.position,boxSize,90,layer);
    }
}
