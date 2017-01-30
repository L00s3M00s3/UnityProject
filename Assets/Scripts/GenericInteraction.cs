using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenericInteraction : MonoBehaviour {

    private bool interacting = false;
    private float interactionTimer = 0;
    private float cooldown = 0.3f;
    public GameObject interaction;
    Collider2D interactionRange;

	// Use this for initialization
	void Awake () {
        interactionRange = interaction.GetComponent<Collider2D>();
        interactionRange.enabled = false;
	}
	
	public void Interaction(int layer)
    {
        if (interaction.layer != layer)
        {
            interaction.layer = layer;
        }
        if (Input.GetKeyDown(KeyCode.E) && !interacting)
        {
            interacting = true;
            interactionTimer = cooldown;
            interactionRange.enabled = true;
        }
        if (interacting)
        {//Interaction cool-down
            if (interactionTimer > 0)
            {
                interactionTimer -= Time.deltaTime;
            }
            else
            {
                //Disables the interaction box
                interacting = false;
                interactionRange.enabled = false;
            }

        }
    }

}
