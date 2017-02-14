using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class UIInventory_Controller : MonoBehaviour {


	private Image UIItem;
	public Inventory currentItem;
	public Sprite[] inHand;	

	void Awake()
	{
		UIItem = GameObject.FindGameObjectWithTag ("UIItem").GetComponent<Image> ();

	}
	// Update is called once per frame
	void Update () {
		InventorySpriteChoice();
	}

	void InventorySpriteChoice()
	{
		switch (currentItem.currentItem)
		{
		case Inventory.Items.Unarmed:
			UIItem.sprite = inHand[0];
			break;
		case Inventory.Items.Gun:
			UIItem.sprite = inHand[1];
			break;
		case Inventory.Items.Duster:
			UIItem.sprite = inHand[2];
			break;
		default:
			UIItem.sprite = inHand[0];
			break;
		}
	}
}