using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericInteraction : MonoBehaviour {

	
	private bool interacting = false;
	private float interactionTimer = 0;
	private float cooldown = 0.3f;
	[HideInInspector]
	Collider2D interactionRange;
	public GameObject interaction;
    public static bool engaged;

    // Use this for initialization
    void Awake () {
		
		interactionRange = interaction.GetComponent<Collider2D> ();
        interaction.SetActive(false);

	}

	public void Interaction(int layer)
	{
		if (!engaged) {
			if (interaction.layer != layer) {
		
				interaction.layer = layer;
			}


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