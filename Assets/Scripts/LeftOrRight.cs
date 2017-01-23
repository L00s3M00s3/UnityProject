using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftOrRight : MonoBehaviour {
    public Transform point,point2;
    public static bool right,left;
	
    void Update()
    {
        right = Physics2D.OverlapPoint(point.position);
        left = Physics2D.OverlapPoint(point2.position);
    }
}
