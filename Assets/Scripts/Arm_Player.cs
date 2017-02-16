using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arm_Player : Overlap_Generic {

	bool pickedup = false;
	public int itemID;


	void Update()
	{
		if (overlap &&!pickedup)
		{
			
				GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>().AddItem(itemID);
				gameObject.GetComponent<SpriteRenderer>().enabled = false;
				pickedup = true; 
                
			
		}
	}
}