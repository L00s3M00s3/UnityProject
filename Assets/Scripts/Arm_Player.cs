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
            if (GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>().currentItem.Equals(Inventory.Items.Unarmed))
                {
                GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>().AddItem(itemID);
                gameObject.GetComponent<SpriteRenderer>().enabled = false;
                pickedup = true; }
            else
            {
                Debug.Log("Can't pick up something with a " + GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>().currentItem + " in your hands");
            }
        }
    }
}
