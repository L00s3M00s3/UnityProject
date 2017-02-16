using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

	public static bool[] inventory;

	static int currentItemIndex;
	[HideInInspector]
	public static Items currentItem;


	public enum Items
	{
		Unarmed,//0
		Gun,//1
		Duster,//2
	};

	void Start()
	{
        
        inventory[(int)Items.Unarmed] = true;
        

	}

	public void AddItem(int entry)
	{
		inventory[entry] = true;
		currentItemIndex = entry;
		PickupItem(entry);
		Debug.Log("Current item is: " + entry);
	}

	void Update()
	{
		SwitchItem();
		SwitchStates();

	}

	void SwitchStates()
	{
		if (!GetComponentInParent<PlayerMovement>().canMove)
		{
			return;
		}
		switch (currentItem)
		{
		case Items.Unarmed:

			GetComponentInChildren<GenericInteraction>().Interaction();
			break;
		case Items.Gun:
			GetComponentInChildren<PlayerShooting>().DirectionalShooting();
			break;
		case Items.Duster:
			GetComponentInChildren<GenericInteraction>().Interaction();
			break;
		default:
			GetComponentInChildren<GenericInteraction>().Interaction();
			break;
		}
	}

	void PickupItem(int item)
	{
		if (inventory[item])
		{
			currentItem = (Items)item;
		}
	}

	void SwitchItem()
	{
		if (Input.GetKeyDown(KeyCode.Q))
		{
			NextItem();
			Debug.Log("Current item is: " + currentItem);
		}
	}

	void NextItem()
	{
		currentItemIndex++;
		if (currentItemIndex >= inventory.Length)
		{
			currentItemIndex = 0;
			currentItem = (Items)currentItemIndex;
		}

		for (int i = currentItemIndex; i < inventory.Length; i++)
		{
			if (inventory[i])
			{
				currentItem = (Items)i;
				break;
			}
			while (!inventory[i])
			{
				currentItemIndex++;
				if (currentItemIndex >= inventory.Length)
				{
					currentItemIndex = 0;
					currentItem = (Items)currentItemIndex;
				}
				break;
			}
		}
	}

}