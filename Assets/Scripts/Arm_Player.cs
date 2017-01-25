using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arm_Player : Overlap_Generic {

    

    void Update()
    {
        if (overlap && Input.GetKeyDown(KeyCode.E))
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerShooting>().poweredup = true;
            GameObject.FindGameObjectWithTag("Gun").GetComponent<SpriteRenderer>().enabled = false;
        }
    }
}
