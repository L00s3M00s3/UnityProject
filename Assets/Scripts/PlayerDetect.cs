using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetect : MonoBehaviour {

	public PlayerMovement PC;


	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag == "Player")
		{
			PC.issafe = true;
			Debug.Log("Enter");
		}

	}
	void OnTriggerExit2D(Collider2D other)
	{
		if (other.tag == "Player")
		{
			PC.issafe = false;
			Debug.Log("Exit");
		}
	}






}