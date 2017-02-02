using UnityEngine;
using System.Collections;

public class Disarm_Trap : MonoBehaviour {
    public Transform pointA, pointB;
    public LayerMask layer;
    bool overlap;

    void FixedUpdate()
    {
        overlap = Physics2D.OverlapArea(pointA.position, pointB.position, layer);
    }

    void Update()
    {
        if (overlap&&Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Overlap");
			Trap_Control.triggered = false;
            GameController.goal = true;
        }
    }
    
}
