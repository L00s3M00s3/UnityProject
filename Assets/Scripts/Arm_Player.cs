using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arm_Player : MonoBehaviour {

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
            GameObject.FindGameObjectWithTag("Player").GetComponent<Player_Shooting>().poweredup = true;
            GameObject.FindGameObjectWithTag("Gun").GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
