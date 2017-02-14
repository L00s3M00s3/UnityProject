using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericInteraction : MonoBehaviour {

	public static bool engaged;

	private bool interacting = false;
	private float interactionTimer = 0;
	private float cooldown = 0.3f;
	[HideInInspector]
	public Collider2D interactionRange;
	public GameObject interaction;

	// Use this for initialization
	void Awake () {
		
		interactionRange = interaction.GetComponent<Collider2D> ();
		interactionRange.enabled = false;

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