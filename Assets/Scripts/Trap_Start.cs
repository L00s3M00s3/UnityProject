using UnityEngine;
using System.Collections;

public class Trap_Start : MonoBehaviour {

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            Trap_Control.triggered = true;
        }

    }
    
    
    
}
