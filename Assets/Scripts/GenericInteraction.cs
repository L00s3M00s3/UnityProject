using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericInteraction : MonoBehaviour {

	
	private bool interacting = false;
	private float interactionTimer = 0;
	private float cooldown = 0.3f;
	[HideInInspector]
	public Collider2D interactionRange;
	public GameObject interaction;
    public static bool engaged;

    // Use this for initialization
    void Awake () {
		
		interactionRange = interaction.GetComponent<Collider2D> ();
        interactionRange.enabled = false;


    }

    void Update()
    {
        if (engaged||Inventory.currentItem.Equals(Inventory.Items.Gun))
        {
            interactionRange.enabled = false;
        }
    }

	public void Interaction()
	{
		if (!engaged) {


			if (Input.GetKeyDown (KeyCode.E) && !interacting) {
				interacting = true;
				interactionTimer = cooldown;
                interactionRange.enabled = true;
            }
			if (interacting) {//Interaction cool-down
				if (interactionTimer > 0) {
					interactionTimer -= Time.deltaTime;
				} else {
					//Disables the interaction box
					interacting = false;
                    interactionRange.enabled = false;
				}

			}
		} else {
            
            interactionRange.enabled = false;
		}
	}

}