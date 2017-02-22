using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arm_Player : Overlap_Generic
{

    bool pickedup = false;
    public bool important;
    public int itemID, stageID;

    void Start()
    {
        if (Inventory.inventory[itemID])
        {
            gameObject.SetActive(false);
        }
    }

    void Update()
    {
        if (overlap && !pickedup)
        {
            if (important)
            {
                stageSetter.setState(stageID);
            }
            GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>().AddItem(itemID);
            gameObject.GetComponent<SpriteRenderer>().enabled = false;
            pickedup = true;
        }
    }
}