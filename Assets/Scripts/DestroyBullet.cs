using UnityEngine;
using System.Collections;

public class DestroyBullet : MonoBehaviour {


    void OnTriggerEnter2D(Collider2D other)
    {
		if(other.tag == "Destroy")
        {
			gameObject.SetActive(false);
		}

	}

}