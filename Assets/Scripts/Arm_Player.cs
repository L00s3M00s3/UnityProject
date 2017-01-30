using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Script inherates from the generic overlap script and mainly deals with allowing the player to pick up things

public class Arm_Player : Overlap_Generic {

    //Bool to determine if the items have been picked up
    bool pickedup = false;
    //Public in allowing us to assign Item ID in the inspector dependent on its location in the inventory
    public int itemID;
    

    void Update()
    {
        //If the boolean within the parent script is true and the item is available run this
        if (overlap &&!pickedup)
        {
            //Checking to see if the player in unarmed
            if (GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>().currentItem.Equals(Inventory.Items.Unarmed))
                {
                //Adds the item to the inventory
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
