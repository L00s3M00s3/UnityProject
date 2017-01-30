using UnityEngine;
using System.Collections;
//Deactivates bullets once they hit the out destroy trigger within the game
public class DestroyBullet : MonoBehaviour {


    void OnTriggerEnter2D(Collider2D other)
    {
		if(other.tag == "Destroy")
        {
			gameObject.SetActive(false);
		}

	}

}